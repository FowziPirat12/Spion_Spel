using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(1);
    }
}
