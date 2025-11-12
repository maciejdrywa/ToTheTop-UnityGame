using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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


    private int maxLives = 3;
    private int lives;

    public Image[] livesTab;

    public Canvas inGameCanvas;

    public Canvas pausedMenuCanvas;

    private float timer = 0f;
    private int minutes;
    private int seconds;
    public TMP_Text timerText;



    

    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogError("Duplicated Game Manager", gameObject);
        }

        lives = maxLives;
        scoreText.text = score.ToString();

        foreach (Image image in keysTab)
        {
            image.color = Color.gray;
        }

        

        pausedMenuCanvas.enabled = false;
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

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

        if (currentGameState == GameState.GAME)
        {
            timer += Time.deltaTime;
            minutes = (int)timer / 60;
            seconds = (int)timer % 60;
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }

    void SetGameState(GameState newState)
    {
        currentGameState = newState;
        if (currentGameState == GameState.GAME)
        {
            inGameCanvas.enabled = true;
            pausedMenuCanvas.enabled = false;
        }
        else
        {
            inGameCanvas.enabled = false;
            pausedMenuCanvas.enabled = true;
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
        
        int newLives = Mathf.Clamp(lives + livesNumber, 0, maxLives);

        
        if (newLives == lives) return;

        lives = newLives;

        for (int i = 0; i < livesTab.Length; i++)
        {
            livesTab[i].enabled = (i < lives);
        }

        Debug.Log("Lives: " + lives);
    }

    public void OnResumeButtonPressed()
    {
        InGame();
    }

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
