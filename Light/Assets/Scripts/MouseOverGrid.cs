using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MouseOverGrid : MonoBehaviour{

    MeshRenderer mesh;
    [SerializeField]
    Material grid, hover, disable;
    bool isPlacable;

    private void OnEnable()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = grid;
        isPlacable = true;
    }

    private void OnMouseEnter()
    {
        Vector2 size = GameManager.instance.WorldSize;

        if (Mathf.Abs(transform.position.x) <= size.x  && Mathf.Abs(transform.position.z) <= size.y)
        {
            mesh.material = hover;
            isPlacable = true;
        }
        else
        {
            mesh.material = disable;
            isPlacable = false;
        }
    }
    
    private void OnMouseUp()
    {
        if (Player.instance.CurrentRoadPieces > 0 && isPlacable && !PreventClikingGrid.IsClickingUI)
            EventHandler.PlaceRoadPieceEvent();
    }
    
    private void OnMouseExit()
    {
        mesh.material = grid;
    }

}
