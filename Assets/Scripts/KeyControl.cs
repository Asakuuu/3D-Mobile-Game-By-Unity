using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyControl : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject buttunFind;
    public GameObject PauseWindow;
    public GameObject FlowChat; 
    public GameObject FlowChat1;
    private bool isPause;
    int FindNum = 4;

    public void Button_Pause()
     {
         PauseGame();
     }

    public void Button_Find()
    {
        if (FindNum == 0)
        {
            buttunFind.gameObject.SetActive(false);
            FindOut();
        }
        else
        {
            Find();
            buttunFind.gameObject.SetActive(false);
            Invoke("Act", 7f);
            FindNum--;
        }
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

    void Find()
    {
        FlowChat.gameObject.SetActive(true);
    }

    void Act()
    {
        buttunFind.gameObject.SetActive(true);
    }

    void FindOut()
    {
        FlowChat1.gameObject.SetActive(true);
    }
}
