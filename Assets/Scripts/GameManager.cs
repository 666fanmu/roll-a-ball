using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject Player;
    public Text WinText;
    public GameObject Menu;
    public player m_player;
    private Enemy Enemy;
    public GameObject enemy;
    public Text EnemyHealthText;

    // Start is called before the first frame update
   


    // Update is called once per frame
    void Update()
    {
        CountSet();
    }
    private void CountSet()
    {
        EnemyHealthText.text="µÐÈËÑªÁ¿: "+Enemy.EnemyHealth.ToString();
        if (player.Health > 0)
        {
            if (player.count >= 16|| Enemy.EnemyHealth == 0)
            {
                GameEnd(true);
            }
           
            
        }
        else
        {  
             GameEnd(false);   
        }
       

    }
    public void GameEnd(bool gamestate)
    {
        if(gamestate)
        {

            WinText.text = "YOU WIN";
            Menu.SetActive(true);

        }
        else
        {
            WinText.text = "YOU LOSE";
            Menu.SetActive(true);
        }
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
   
}
