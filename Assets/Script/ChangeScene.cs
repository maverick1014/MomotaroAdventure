using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID){
	    SceneManager.LoadScene(sceneID);
    }

    public void GoToMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void Play()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
