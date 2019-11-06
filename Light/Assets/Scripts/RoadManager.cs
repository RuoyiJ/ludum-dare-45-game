using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour {
    public static RoadManager instance;
    [SerializeField]
    Transform defaultPrefab, pinkPrefab, yellowPrefab, bluePrefab, purplePrefab, greenPrefab;
    
    //Transform currPrefab;
    List<Transform> roads = new List<Transform>();

    public void Initialise()
    {
        instance = this;
    }

    private void Start()
    {
        EventHandler.OnRoadPiecePlaced += PlaceRoadPiece;
        //currPrefab = defaultPrefab;
    }
    void OnDestroy()
    {
        EventHandler.OnRoadPiecePlaced -= PlaceRoadPiece;
    }

    public void PlaceRoadPiece()
    {
        //check if there is a road piece already
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layermask = 1 << 9;

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f,layermask))
        {
            Vector2 size = GameManager.instance.WorldSize;

            if (hit.transform.tag != "RoadPiece")
            {
                Transform road = Instantiate(RandomColorRoad());
                road.SetParent(transform, false);
                road.position = hit.transform.position;
                roads.Add(road);
            }
        }
    }
    
    Transform RandomColorRoad()
    {
        int col = Random.Range(0, 5);
        switch(col)
        {
            case 0:
                return pinkPrefab;
                
            case 1:
                return yellowPrefab;
                
            case 2:
                return bluePrefab;
                
            case 3:
                return purplePrefab;
                
            case 4:
                return greenPrefab;
                
            default:
                return defaultPrefab;
                
        }
    }
    // called by button click, not used anymore
    /*public void GetPinkColor()
    {
        currPrefab = pinkPrefab;
    }
    public void GetYellowColor()
    {
        currPrefab = yellowPrefab;
    }
    public void GetBlueColor()
    {
        currPrefab = bluePrefab;
    }
    public void GetPurpleColor()
    {
        currPrefab = purplePrefab;
    }
    public void GetGreenColor()
    {
        currPrefab = greenPrefab;
    }
    public void GetDefaultColor()
    {
        currPrefab = defaultPrefab;
    }*/
}
