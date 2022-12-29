using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_Bullet : MonoBehaviour
{
        public float speed = 3f;
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
            if (lifeTime > 3f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
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
