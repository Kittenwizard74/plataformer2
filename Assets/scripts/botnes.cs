using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botnes : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }

    public void retry()
    {
        SceneManager.LoadScene(0);
    }
}
