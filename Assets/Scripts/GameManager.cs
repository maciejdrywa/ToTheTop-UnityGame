using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum GameState { GAME, PAUSE_MENU, LEVEL_COMPLETED, GAME_OVER }

public class GameManager : MonoBehaviour
{

    public GameState currentGameState = GameState.GAME;

    public static GameManager instance;

    private int score = 0;
    public TMP_Text scoreText;

    private int keysFound = 0;

    public int maxKeysNumber = 3;

    public bool keysComplited = false;

    public Image[] keysTab;

    private int lives = 3;

    public Canvas inGameCanvas;

    

    


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogError("Duplicated Game Manager", gameObject);
        }

        scoreText.text = score.ToString();

        foreach (Image image in keysTab)
        {
            image.color = Color.gray;
        }

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
        if (currentGameState == GameState.GAME)
        {
            inGameCanvas.enabled = true;
        }
        else
        {
            inGameCanvas.enabled = false;
        }
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
        scoreText.text = score.ToString();
        Debug.Log("Score: " + score);
    }

    public void addKeys(Color color)
    {
        keysTab[keysFound].color = color;
        keysFound += 1;
        if (keysFound == maxKeysNumber)
        {
            keysComplited = true;
            Debug.Log("Zebrano wszytskie klucze");
        }
    }

    public void addLives(int livesNumber)
    {
        lives += livesNumber;
    }
}
