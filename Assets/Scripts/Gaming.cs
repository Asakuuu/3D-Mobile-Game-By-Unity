using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gaming : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        esc_to_close();
        BacktoTitle();
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

    void BacktoTitle()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
    }
}
