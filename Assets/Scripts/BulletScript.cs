using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject Rocket;
    private float _bulletPosX;
    private float _bulletPosY;

    private void Update()
    {
        _bulletPosX = transform.position.x;
        _bulletPosY = transform.position.y;

        if (_bulletPosX >= 10.0f || _bulletPosX <= -10.0f || _bulletPosY >= 10.0f || _bulletPosY <= -10.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreCountScript.score += 10; 
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect,0.2f);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
