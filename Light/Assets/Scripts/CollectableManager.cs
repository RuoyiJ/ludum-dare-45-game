using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {
    float minDistance = 10f;
    int layermask = 1 << 10;
    Vector3 initPiecePos = new Vector3(3, 0, 3);
    Vector3 initFlamePos = new Vector3(-3, 0, 3);
    Vector2 size;

    public void Initialise()
    {
        GetObject(initPiecePos, "RoadPiece");
        GetObject(initFlamePos, "Flame");

        //need to make sure the max number of loop is not too big or it won't find a spawn location and program won't even start
        for (int i = 0; i < 20; i++)
        {
            SpawnCollectable("RoadPiece");
            SpawnCollectable("Flame");
        }
    }

    void SpawnCollectable(string objectTag)
    {
        Vector3 newPos;
        Collider[] neighbours;
        int counter = 0;
        // if there are objects in the min distance, get another position
        do
        {
            size = GameManager.instance.WorldSize;
            newPos = new Vector3(Random.Range(-size.x, size.x), 0, Random.Range(-size.y, size.y));
            neighbours = Physics.OverlapSphere(newPos, minDistance, layermask);
            counter++;  // only loop 5 times, if not found a neighbour, place the object
            if(neighbours.Length == 0)
            {
                GetObject(newPos, objectTag);
            }
        } while (neighbours.Length > 0 && counter < 5);
    }

    //find a collectable object from object pool
	void GetObject(Vector3 position, string tag)
    {
        GameObject newObj = ObjectPool.instance.GetPooledObject(tag);
        newObj.transform.position = position;
        newObj.SetActive(true);
    }
    
}
