using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //move
    public float speed = 1000;
    public Joystick joyStick;
    private CharacterController controller;

    //focus enemy
    private GameObject focusEnemy;

    //fire
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool isKeepShooting = false;

    //animation
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        //StartCoroutine(KeepShooting());
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        FindEnemy();
        
        FireControll();

        if (isKeepShooting == true)
        {
            StartCoroutine(KeepShooting());
        }

    }
    public void PlayerMove()
    {
        // 取得虛擬搖桿輸入
        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;
        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        // 調整角色面對方向
        // 判斷方向向量長度是否大於 0.1（代表有輸入）
        if (dir.magnitude > 0.1f)
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        // 移動角色位置
        controller.Move(dir * speed * Time.deltaTime);
        
        //播放移動動畫
        animator.SetTrigger("Run");

        // 地心引力 (y)
        if (!controller.isGrounded)
        {
            dir.y = -98f * 1000 * Time.deltaTime;
        }

    }

    public void FindEnemy()
    {
        // find target
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
        //focus enemy
    
        if (focusEnemy)
        {
            var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
    }
    
    public void FireControll()
    {
        //switch K
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(isKeepShooting == false)
            {
                Debug.Log("f>t");
                isKeepShooting = true;
            }
            else if(isKeepShooting == true)
            {
                Debug.Log("t>f");
                isKeepShooting = false;
            }
        }
    }

    IEnumerator KeepShooting()
    {
        if (isKeepShooting == true)
        {
        while(true)
        {
            if (isKeepShooting == true)
            {
                Fire();
                Debug.Log("Fire");
            }
            yield return new WaitForSeconds(1f);
            Debug.Log("0.5f");
        
        }
        }
    
    }
    
    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
        animator.SetTrigger("Attack");
    }
}
