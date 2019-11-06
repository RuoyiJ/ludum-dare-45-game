using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridView : MonoBehaviour
{
    [SerializeField]
    Transform GridLayout;
    [SerializeField]
    Transform tilePrefab;
    bool showGrid;
   
    public void Initialise()
    {
        EventHandler.OnMovingBlock += UpdateGridPosition;
        //Construct a 3 * 3 grid around player
        InitialiseTiles(new Vector2Int(3, 3));
        ShowGrid = true;
    }
    void OnDestroy()
    {
        EventHandler.OnMovingBlock -= UpdateGridPosition;

    }
    //Instantiate tiles
    public void InitialiseTiles(Vector2Int size)
    {
        //move grid to the center
        Vector2 offset = new Vector2(
            (size.x - 1) * 10 * 0.5f, (size.y - 1) * 10 * 0.5f
        );
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                //do not draw at the 4 corners and center of the grid
                if (y == 0 || y == size.y - 1)
                {
                    if (x == 0 || x == size.x - 1)
                        continue;
                }
                else if (x == (size.x - 1) / 2 && y == (size.y - 1) / 2)
                    continue;
                Transform tile = Instantiate(tilePrefab);
                tile.transform.SetParent(GridLayout, false);
                tile.transform.localPosition = new Vector3(
                    x*10 - offset.x, 0f, y*10 - offset.y
                );
            }
        }
    }
    //if true show GridLayout game object, else hide it
    public bool ShowGrid
    {
        get { return showGrid; }
        set
        {
            showGrid = value;
            if (showGrid)
            {
                UpdateGridPosition();
                GridLayout.gameObject.SetActive(true);
            }
            else
            {
                GridLayout.gameObject.SetActive(false);
            }
        }
    }
    //update the position of grid layout to player's position
    void UpdateGridPosition()
    {
        //get the position of the block player is on
        Vector3 newPos = Player.instance.CurrentBlock.position;
        GridLayout.position = newPos;
    }
    // if grid is shown turn it off, else turn it off
    public void ShowGridView()
    {
        ShowGrid = !ShowGrid;
    }
}