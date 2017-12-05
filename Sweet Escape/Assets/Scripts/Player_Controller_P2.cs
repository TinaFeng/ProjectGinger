using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_P2 : MonoBehaviour {
    Animator anim;

    public float speed = 5f;

	public List<string> items = new List<string>();

    public float current_speed_x, current_speed_y;

    BoxCollider2D self;

    bool moving;
    // Use this for initialization
    void Start()
    {

        self = this.GetComponent<BoxCollider2D>();
        anim = this.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(collision.collider, self);
		if (collision.gameObject.tag == "Item") {
            Debug.Log("Key added");
            items.Add (collision.gameObject.name);
			Destroy (collision.gameObject);
		}
		if (collision.gameObject.tag == "Door" && items.Contains ("Key")) {
            Debug.Log("Player hit door");
			items.Remove ("Key");
			Destroy (collision.gameObject);
		}
    }

    // Update is called once per frame
    void Update () {

        current_speed_x = Input.GetAxis("Horizontal2") * speed;
        current_speed_y = Input.GetAxis("Vertical2") * speed;
        if (current_speed_x != 0 || current_speed_y != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

    }

    private void FixedUpdate()
    {
        if (moving)
        {
            anim.SetBool("moving", true);

        }
        else
        {
            anim.SetBool("moving", false);
        }
        this.transform.Translate(Time.deltaTime * current_speed_x * Vector2.right);
        this.transform.Translate(Time.deltaTime * current_speed_y * Vector2.up);
    }
}
