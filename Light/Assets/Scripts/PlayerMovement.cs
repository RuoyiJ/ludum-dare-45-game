using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 0.2f;
    Rigidbody m_rigid;
    float maxDistance = 1f;
    Vector3 move = Vector3.zero;

    public bool IsMovingBlock { get; private set; }

    // Use this for initialization
    public void Initialise () {
        m_rigid = GetComponent<Rigidbody>();
        Player.instance.CurrentBlock = GetCurrentBlock();
        IsMovingBlock = false;
	}

    public void Move()
    {
        //Get input : using unity standalone input module
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, v);
        move = move.normalized * speed * Time.deltaTime;
        if (h > 0)
        {
            if (CheckIfRightEdgeReach()) // can move left
                move = new Vector3(Mathf.Min(move.x, 0), 0, move.z);
        }
        else if (h < 0)
        {
            if (CheckIfLeftEdgeReach()) // can move right
                move = new Vector3(Mathf.Max(move.x, 0), 0, move.z);
        }
        if (v > 0)
        {
            if (CheckIfFrontEdgeReach()) // can move back
                move = new Vector3(move.x, 0, Mathf.Min(move.z, 0));
        }
        else if (v < 0)
        {
            if (CheckIfBackEdgeReach()) // can move front
                move = new Vector3(move.x, 0, Mathf.Max(move.z, 0));
        }
        if(h != 0 || v != 0)
        {
            IsMovingToAnotherBlock();
        }
        m_rigid.MovePosition(transform.position + move);
    }

    void IsMovingToAnotherBlock()
    {
        if (GetCurrentBlock() != Player.instance.CurrentBlock && (Player.instance.CurrentBlock = GetCurrentBlock()) != null)
        {
            IsMovingBlock = true;
            EventHandler.MoveBlock();
        }
        else IsMovingBlock = false;
    }

    //Find the current road piece that player is on
    Transform GetCurrentBlock()
    {
        int layermask = 1 << 9;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance, layermask))
        {
            if (hit.transform.tag == "RoadPiece")
                return hit.transform;
        }
        return null;
    }

    //if raycast does not hit road pieces, return true
    bool CheckIfFrontEdgeReach()
    {
        int layermask = 1 << 9;
        RaycastHit hit;
        if(Physics.Raycast((transform.position+transform.forward * 0.1f),Vector3.down,out hit,maxDistance,layermask))
        {
            if (hit.transform.tag == "RoadPiece")
                return false;
        }
        return true;
    }
    bool CheckIfBackEdgeReach()
    {
        int layermask = 1 << 9;
        RaycastHit hit;
        if (Physics.Raycast((transform.position - transform.forward * 0.1f), Vector3.down, out hit, maxDistance, layermask))
        {
            if (hit.transform.tag == "RoadPiece")
                return false;
        }
        return true;
    }
    bool CheckIfRightEdgeReach()
    {
        int layermask = 1 << 9;
        RaycastHit hit;
        if (Physics.Raycast((transform.position + transform.right * 0.1f), Vector3.down, out hit, maxDistance, layermask))
        {
            if (hit.transform.tag == "RoadPiece")
                return false;
        }
        return true;
    }
    bool CheckIfLeftEdgeReach()
    {
        int layermask = 1 << 9;
        RaycastHit hit;
        if (Physics.Raycast((transform.position - transform.right * 0.1f), Vector3.down, out hit, maxDistance, layermask))
        {
            if (hit.transform.tag == "RoadPiece")
                return false;
        }
        return true;
    }
}
