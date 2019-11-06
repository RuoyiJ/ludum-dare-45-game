using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour {

    public delegate void CollectingEvent();
    public static event CollectingEvent OnRoadPieceCollected;
    public static event CollectingEvent OnFlameCollected;

    public delegate void RoadPieceEvent();
    public static event RoadPieceEvent OnRoadPiecePlaced;
    public static event RoadPieceEvent OnMovingBlock;

    public static void RoadPieceCollectingEvent()
    {
        OnRoadPieceCollected();
    }
    public static void FlameCollectingEvent()
    {
        OnFlameCollected();
    }
    public static void PlaceRoadPieceEvent()
    {
        OnRoadPiecePlaced();
    }
    public static void MoveBlock()
    {
        OnMovingBlock();
    }
}
