using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gaming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        esc_to_close();
        BacktoTitle();
    }

    private void esc_to_close()
    {
        //esc = close
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
