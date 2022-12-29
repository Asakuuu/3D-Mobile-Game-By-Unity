using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGameUI : MonoBehaviour
{
   /* public Button PauseButton;
    public GameObject PauseWindow;
    private bool isPause;
    public Text PauseTitle;
   */
    public Animator animator;
    public AudioSource m_audioSource;
    public AudioClip attackSound;
   /*
    public void Button_Menu()
    {
        PauseGame();
    }

    public void BacktoGame()
    {
        PauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPause = !isPause;
    }

    public void BacktoTitle()
    {
        isPause = !isPause;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    */
    void Start()
    {
      //  isPause = false;
     //   PauseButton.onClick.AddListener(PauseGame);
    }

    void Update()
    {

    }

   
    /*
    void PauseGame()
    {
        isPause = !isPause;
        
        if (isPause == true)
        {
            PauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }*/
}
