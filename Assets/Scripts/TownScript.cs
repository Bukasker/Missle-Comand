using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownScript : MonoBehaviour
{
    public GameObject DestroyedTown;

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameMenagerScript.TownNumber--;
        if (col.tag == "Rocket")
        {
            Instantiate(DestroyedTown,transform.position,transform.rotation);
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
