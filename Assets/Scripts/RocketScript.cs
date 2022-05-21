using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public class RocketScript : MonoBehaviour
{ 
    private float _RocketSpeed = 3f;

    public GameObject townToAim;
    public Vector3 townToAimPosition;

    public event EventHandler<GameObject> onRocketReachedTown;

    void Update()
    {
        townToAimPosition = (townToAim == null) ? townToAimPosition : townToAim.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, townToAimPosition, _RocketSpeed * Time.deltaTime);
        transform.up = townToAimPosition - transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Town"))
        {
            onRocketReachedTown?.Invoke(this, townToAim);
        }

        Destroy(gameObject);
    }
}
