using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float hp = 100f;
    private Transform player;
    public GameObject bullet;
    private Animator animator;
    public Transform firePoint1;
    public float speed = 3f;
    public AudioSource audioSource;
    public AudioClip hittedSound;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        StartCoroutine(KeepShooting());
    }

    void Update()
    {
        LookAt();
        Chase();
    }

    void LookAt()
    {
        float d = Vector3.Distance(transform.position, player.transform.position);
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
    }

    void Chase()
    {
        Quaternion targtRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targtRotation, speed * Time.deltaTime);
        transform.position += transform.forward * 1f * Time.deltaTime;
    }

    IEnumerator KeepShooting()
    {
        while (true)
        { 
            animator.SetTrigger("Attack");
            Invoke("Fire", 0.5f);
            yield return new WaitForSeconds(1f);
        }
    }

    void Fire()
    {
        audioSource.Play();
        Instantiate(bullet, firePoint1.transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            audioSource.PlayOneShot(hittedSound);
            animator.SetTrigger("Hit");
            Bullet bullet = other.GetComponent<Bullet>();
            hp -= bullet.atk;

            if (hp <= 0)
            {
                animator.SetTrigger("Dead");
                Invoke("Dead", 1f);
            }
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
