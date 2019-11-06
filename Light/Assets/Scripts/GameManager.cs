using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start,
    Playing,
    Die
}
public class GameManager : MonoBehaviour {
    //static instance can be called without instantiation
    public static GameManager instance;
    public GameState CurrentState { get; set; }
    public Vector2 WorldSize { get; set; }
    [SerializeField]
    CollectableManager collectables;
    [SerializeField]
    Player player;
    [SerializeField]
    ObjectPool pool;
    [SerializeField]
    RoadManager roadManager;
    [SerializeField]
    RectTransform gameOverPanel;
    [SerializeField]
    HealthPanelUI healthPanel;
    [SerializeField]
    RoadPieceUI roadPieceUI;
    [SerializeField]
    GridView grid;
    private void Awake()
    {
        instance = this;
        WorldSize = new Vector2(5, 5) * 10;
    }
    private void Start()
    {
        Initialise();
    }
    //Initialise level
    void Initialise()
    {
        player.enabled = true;
        player.Initialise();
        pool.Init();
        collectables.Initialise();
        roadManager.Initialise();
        healthPanel.Initialise();
        roadPieceUI.Initialise();
        grid.Initialise();
        gameOverPanel.gameObject.SetActive(false);
        CurrentState = GameState.Playing;

    }

    //Game states : not well implemented
    void Update()
    {
        switch(CurrentState)
        {
            //case GameState.Start:
            //    Initialise();
            //    break;
            case GameState.Playing:
                GameLoop();
                break;
            case GameState.Die:
                GameOver();
                break;
            default:
                break;
        }
    }
	void GameLoop()
    {
        if (player.CurrentHealth < 0)
        {
            CurrentState = GameState.Die;
        }
    }

    void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        player.enabled = false;
        grid.gameObject.SetActive(false);

    }

    public void FinishGame()
    {
        CurrentState = GameState.Die;
        GameOver();
    }

    public void Reset()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
        CurrentState = GameState.Start;
    }
}
