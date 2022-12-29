using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10;
    public Joystick joyStick;
    private CharacterController cc;

    private GameObject focusEnemy;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bullet;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    int heartNum = 3;

    private Animator animator;
    public AudioSource audioSource;
    public AudioClip hittedSound;
    public AudioClip deadSound;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();

        FireControll();
    }

    public void Move()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }

        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;

        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            if (focusEnemy)
            {
                var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }

        if (!cc.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        cc.Move(dir * speed * Time.deltaTime);
    }

    public void Button_Attack()
    {
        animator.SetTrigger("Attack");
            Invoke("Fire", 0.5f);
    }

    void FireControll()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetTrigger("Attack");
            Invoke("Fire", 0.5f);        
        }
    }

    void Fire()
    {
        audioSource.Play();
        Instantiate(bullet, firePoint1.transform.position,transform.rotation);
        Instantiate(bullet, firePoint2.transform.position,transform.rotation);
        Instantiate(bullet, firePoint3.transform.position,transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            animator.SetTrigger("Dead");
            audioSource.PlayOneShot(deadSound);
            Invoke("Dead", 1f);
        }
        
        if(other.tag == "Dead")
        {
            Debug.Log("Hit");
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hittedSound);
            heartNum--;
            if (heartNum == 2)
            heart1.SetActive(false);
            else if (heartNum == 1)
            heart2.SetActive(false);
            else if (heartNum == 0)
            {
                heart3.SetActive(false);
                audioSource.PlayOneShot(deadSound);
                animator.SetTrigger("Dead");       
                Invoke("Dead", 1f);
            }
        }
    }
    void Dead()
    {
        SceneManager.LoadScene("EnemyDead");
    }
}

    
    

