using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnLevel1ButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    #if UNITY_EDITOR
    public void OnExitGameButtonPressed()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    #endif
}
