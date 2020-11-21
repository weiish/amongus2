using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void ChooseSampleGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ChooseTheoGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChooseWeiGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ChooseKevinGame()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitTheGame()
    {
        Debug.Log("EXITING GAME");
        Application.Quit();
    }
}
