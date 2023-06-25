using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject MenuCanvas;
    private static Menu instance;
    public static Menu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Menu();
            }
            return instance;
        }
    }
    private void Start()
    {
        MenuCanvas.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))//µ÷ÓÃEsc¼ü
        {
            MenuCanvas.SetActive(true);
        }
    }
    public void  Exit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ReStart()
    {
        player.Health = 3;
        player.count = 0;
        SceneManager.LoadScene("roll-a-ball");
    }
    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }
}
