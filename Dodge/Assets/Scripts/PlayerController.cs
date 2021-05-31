﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    public float speed = 8f;
    public int hp = 100;
    public HpBar hpbar;

    private float spawnRate = 0.2f;
    private float timerAfterSpawn;
    public GameObject playerBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput=Input.GetAxis("Horizontal");
        float zInput=Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        playerRigidbody.velocity = newVelocity;
        timerAfterSpawn += Time.deltaTime;
        if(Input.GetButton("Fire1")&&timerAfterSpawn>=spawnRate)
        {
            timerAfterSpawn = 0;
            GameObject bullet = Instantiate(playerBulletPrefab, transform.position, transform.rotation);
        }
    }
    
    public void GetDamage(int damage)
    {
        hp -= damage;
        hpbar.SetHP(hp);
        if(hp<=0)
        {
            Die();
        }
    }
    public void GetHeal(int heal)
    {
        hp += heal;
        if (hp > 100) 
        {
            hp = 100;
        }
        hpbar.SetHP(hp);
    }
    void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
