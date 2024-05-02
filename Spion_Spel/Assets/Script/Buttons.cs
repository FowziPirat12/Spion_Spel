using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void EndGame()
    {
        Application.Quit();
        Debug.Log("quit");    
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Lobby Map");
    }
    public void Continue()
    {
        SceneManager.LoadScene("Hidden Bunker Map1");
    }
}
