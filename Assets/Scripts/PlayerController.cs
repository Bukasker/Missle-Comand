using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera Camera;
    public Rigidbody2D rb;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        if (!GameMenagerScript.GameOver && !GameMenagerScript.isGamePaused)
        {
            Vector2 lookDirection = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
