using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    [SerializeField] private float _bulletForce = 15f;
    public static int BulletCounter;

    public AudioSource ShootingSound;
    private void Start()
    {
        ShootingSound = this.GetComponent<AudioSource>();

        BulletCounter = GetBulletsPerRound();
        MenuScript.onNextRound += ResetBulletCounter;
    }

    private void OnDisable()
    {
        MenuScript.onNextRound -= ResetBulletCounter;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameMenagerScript.GameOver && !GameMenagerScript.isGamePaused)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(BulletCounter > 0)
        {
            ShootingSound.Play();
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * _bulletForce, ForceMode2D.Impulse);
            BulletCounter--;
        }        
    }

    public void ResetBulletCounter()
    {
        BulletCounter = GetBulletsPerRound();
    }

    private int GetBulletsPerRound()
    {
        return (int)Math.Ceiling(GameMenagerScript.RoundDuration / SpawnMenagerScript.spawnInterval) + 10;
    }
}
