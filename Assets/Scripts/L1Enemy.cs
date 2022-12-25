using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Enemy : MonoBehaviour
{
    // HP
    private float L1EnemyHP = 100f;

    //find player
    private GameObject focusPlayer;
    public float FindPlayerminiDist = 9999;

    //move
    public float speed = 50000.0f; 
    private Rigidbody rb; 
    public GameObject petObject;
    public List<Vector3> positionList;
    public int distance = 50;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FindPlayer();
        move();
    }

    public void FindPlayer()
    {
        // find target
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        foreach (GameObject Player in players)
        {
            float d = Vector3.Distance(transform.position, Player.transform.position);

            if (d < FindPlayerminiDist)
            {
                FindPlayerminiDist = d;
                focusPlayer = Player;
            }
        }
        //focus enemy
        if (focusPlayer)
        {
            var targetRotation = Quaternion.LookRotation(focusPlayer.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
    }

    void move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 push = new Vector3(h, 0, v) * speed;
        rb.AddForce(push * Time.deltaTime);

        positionList.Add(transform.position);       //紀錄玩家每偵位置
        if (positionList.Count > distance)          //集合的數字超過一定數字後意旨玩家與寵物的距離過遠時 就讓寵物照著玩家軌跡走，並清除先前紀錄的位置
        {
            positionList.RemoveAt(0);               
            petObject.transform.position = positionList[0];
        }
        
    }

    // be hit by bullet
    private void OnTriggerEnter(Collider other)
    {
        // collision by "Bullet"
        if (other.tag == "Bullet")
        {
            Debug.Log("collider");
            Bullet bullet = other.GetComponent<Bullet>();
            gameObject.SetActive(false);
            
            animator.SetTrigger("Die");
            Destroy(gameObject, 5);

            inGameUI.guilty = inGameUI.guilty + 20;

            /*
            L1EnemyHP -= bullet.atk;
            Debug.Log(L1EnemyHP);
            if (L1EnemyHP <= 0)
            {
                Debug.Log("dieee");
                gameObject.SetActive(false);
                Destroy(gameObject);
            }*/
        }

        // collision by "Player"
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    // ;(
}
