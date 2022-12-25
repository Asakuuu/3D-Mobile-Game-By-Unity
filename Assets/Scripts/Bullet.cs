using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public float atk = 50f;
    private Rigidbody rb;

    void Start()
    {
        // 往前飛
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 如果碰撞到的是敵人
        if (other.tag == "Enemy")
        {
            // 刪除自己
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("lofi!");
        }
    }

    // am I a tiger or a gazelle ?
}
