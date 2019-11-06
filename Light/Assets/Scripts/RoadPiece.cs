using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPiece : InteractiveObject {
    int amount = 5; //amount of road pieces gained each time when collecting the object
    public override void CollisionResolve()
    {
        if (enabled && player != null)
        {
            player.GainRoadPiece(5);
            EventHandler.RoadPieceCollectingEvent();
            gameObject.SetActive(false);
        }
    }

}
