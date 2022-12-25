using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// example
public class Enemy : MonoBehaviour
{
    
    private float hp = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // collision by "Bullet"
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();


            hp -= bullet.atk;

            
            if (hp <= 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    // please give it back
}
