using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_P2 : MonoBehaviour {

    public float speed = 5f;


    public float current_speed_x, current_speed_y;

    BoxCollider2D self;
    // Use this for initialization
    void Start()
    {

        self = this.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(collision.collider, self);
    }

    // Update is called once per frame
    void Update () {

        current_speed_x = Input.GetAxis("Horizontal2") * speed;
        current_speed_y = Input.GetAxis("Vertical2") * speed;

    }

    private void FixedUpdate()
    {

        this.transform.Translate(Time.deltaTime * current_speed_x * Vector2.right);
        this.transform.Translate(Time.deltaTime * current_speed_y * Vector2.up);
    }
}
