using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float atk = 30f;
    float lifeTime = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (other.tag == "Tree")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
