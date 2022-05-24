using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Rocket"))
        {
            GameMenagerScript.Score += 10;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
