using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {

    public Player player { get; private set; }
    void OnEnable()
    {
        player = null;
    }

    // check whether the object collide with player or not
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (enabled && player == null 
            && (player = other.GetComponent<Player>()) != null && !player.enabled)
        {
            player= null;
        }
    }

    //if collided, reset player to null after trigger ends
    protected virtual void OnTriggerExit(Collider other)
    {
        if (player != null && player == other.GetComponent<Player>())
        {
            player = null;
        }
    }
    public abstract void CollisionResolve();

}
