using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RoadPieceUI : MonoBehaviour {
    Text pieceNum;
	// Use this for initialization
    private void Start()
    {
        EventHandler.OnRoadPieceCollected += UpdateRoadPiecesNumber;
        EventHandler.OnRoadPiecePlaced += UpdateRoadPiecesNumber;
    }
    void OnDestroy()
    {
        EventHandler.OnRoadPieceCollected -= UpdateRoadPiecesNumber;
        EventHandler.OnRoadPiecePlaced -= UpdateRoadPiecesNumber;
    }
	public void Initialise () {
        pieceNum = GetComponent<Text>();
        pieceNum.text = 0.ToString();
	}
	
	public void UpdateRoadPiecesNumber()
    {
        pieceNum.text = Player.instance.CurrentRoadPieces.ToString();
    }
}
