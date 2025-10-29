using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum GameState { GAME, PAUSE_MENU, LEVEL_COMPLETED, GAME_OVER }

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.PAUSE_MENU;

    public static GameManager instance;

    private int score = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogError("Duplicated Game Manager", gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState != GameState.GAME)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                InGame();
            }

        } else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

    }

    void SetGameState(GameState newState)
    {
        currentGameState = newState;
    }

    public void PauseGame()
    {
        SetGameState(GameState.PAUSE_MENU);
    }

    public void InGame()
    {
        SetGameState(GameState.GAME);
    }

    public void LevelCompleted()
    {
        SetGameState(GameState.LEVEL_COMPLETED);
    }

    public void GameOver()
    {
        SetGameState(GameState.GAME_OVER);
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}
