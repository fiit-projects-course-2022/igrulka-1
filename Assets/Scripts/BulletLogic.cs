using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 60;
    public GameObject ownShip;
    public float maxDistance = 15000;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        ownShip = GameObject.Find("OwnShip");
    }
    
    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, ownShip.transform.position);
        if (distance > 150)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyBehaviour enemy = hitInfo.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        var target = hitInfo.name;
        if(target == "OwnShip" || target == "bullet(Clone)")
            return;
        Destroy(gameObject);
    }
}
