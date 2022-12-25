using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGameUI : MonoBehaviour
{
    // pet shoot
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ArrowPrefab;

    // score
    public static int guilty = 0;
    public Text textGuilty;
    

    // pause
    public Button PauseButton;
    public GameObject PauseWindow;
    private bool isPause;
    public Text PauseTitle;

    public Animator animator;
    public AudioSource m_audioSource;
    public AudioClip attackSound;

    // pause
    public void Button_Menu()
    {
        Debug.Log("Menu");
        PauseGame();
        
    }
    public void Button_Pet()
    {
        m_audioSource.PlayOneShot(attackSound);
        animator.SetTrigger("Attack");
        Instantiate(ArrowPrefab, firePoint.transform.position, transform.rotation);
    }
    // player shoot
    public void Button_CharacterShot()
    {
        m_audioSource.PlayOneShot(attackSound);
        animator.SetTrigger("Attack");
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
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

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        PauseButton.onClick.AddListener(PauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();
        textGuilty.text = "GUILTY  " + guilty;
        InvokeRepeating("showHide", 0.5f, 0.5f);
    }

    // if no more enemy then next level
    public void NextLevel()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemys.Length;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    void PauseGame()
    {
        isPause = !isPause;
        
        if (isPause == true)
        {
            PauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
            //InvokeRepeating("showHide", 0.5f, 0.5f);
        }
    }
    void showHide()
    {
        if(PauseTitle.text == "Want to ESCAPE ?")
        {
            PauseTitle.text = " ";
        }
        else
        {
            PauseTitle.text = "Want to ESCAPE ?";
        }
    }
    
    // rescue me.
}
