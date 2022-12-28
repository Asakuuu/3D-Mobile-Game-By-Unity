using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        esc_to_close();
    }

    private void esc_to_close()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    
    public void ButtonStart()
    {
        SceneManager.LoadScene(3);
        inGameUI.guilty = 0;
    }

    public void ButtonSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void ButtonBack()
    {
        SceneManager.LoadScene(0);
    }
}
