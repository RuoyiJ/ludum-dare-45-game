using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //global instance
    public static Player instance;
    int maxHealth = 6;

    public int CurrentRoadPieces { get; private set; }
    public int CurrentHealth { get; private set; }
    public int RoadPlaced { get; private set; }
    public Transform CurrentBlock { get; set; } //current road piece player stands on
    private InteractiveObject interactiveObject;
    private PlayerMovement movement;

    void Start()
    {

        EventHandler.OnRoadPiecePlaced += UseRoadPiece;
        EventHandler.OnMovingBlock += LoseHealth;
    }
    void OnDestroy()
    {
        EventHandler.OnRoadPiecePlaced -= UseRoadPiece;
        EventHandler.OnMovingBlock -= LoseHealth;
    }
        public void Initialise()
    {
        instance = this;

        movement = GetComponent<PlayerMovement>();
        movement.Initialise();

        transform.position = Vector3.zero;
        CurrentHealth = 0;
        CurrentRoadPieces = 0;
        RoadPlaced = 0;
        interactiveObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(enabled && interactiveObject==null && (interactiveObject = other.GetComponent<InteractiveObject>())!=null
            &&!interactiveObject.enabled)
        {
            interactiveObject = null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(interactiveObject!=null)
        {
            interactiveObject = null;

        }
    }
    //Fix update is used for rigidbody movement
    private void FixedUpdate()
    {
        movement.Move();
    }
    void Update()
    {
        HandleCollision();
    }
    void HandleCollision()
    {
        //if collided, resolve collision
        if(interactiveObject!=null && interactiveObject.gameObject.activeInHierarchy)
        {
            interactiveObject.CollisionResolve();
            interactiveObject = null;
        }
    }
    public void GainRoadPiece(int amount)
    {
        CurrentRoadPieces += amount;
    }
    void UseRoadPiece()
	{
        CurrentRoadPieces--;
        RoadPlaced++;
	}
    public void RecoverHealth()
    {
        CurrentHealth = maxHealth;
    }
    void LoseHealth()
    {
        CurrentHealth--;
    }
}
