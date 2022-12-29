using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject PauseWindow;
    private bool isPause;
    
     public void Button_Pause()
     {
         PauseGame();
     }

    public void BacktoGame()
     {
        PauseWindow.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(true);
        Time.timeScale = 1;
         isPause = !isPause;
     }

     public void BacktoMenu()
     {
         isPause = !isPause;
         Time.timeScale = 1;
         SceneManager.LoadScene(0);
     }
     
    void Start()
    {
        PauseWindow.gameObject.SetActive(false);
        isPause = false;
    }

    void Update()
    {
        NextLevel();
    }

    void PauseGame()
    {
        isPause = !isPause;
        
        if (isPause == true)
        {
            PauseWindow.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
   
    public void NextLevel()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemys.Length;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            SceneManager.LoadScene("Not End");
        }
    }
}
