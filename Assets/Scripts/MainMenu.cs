using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public void Play()
    {
        SceneManager.LoadScene("roll-a-ball");
    }
   
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }
}
