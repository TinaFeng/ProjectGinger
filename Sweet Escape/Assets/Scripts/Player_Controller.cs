using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float speed = 5f;
	public List<string> items = new List<string>();
    float current_speed_x, current_speed_y;

    BoxCollider2D self;
	// Use this for initialization
	void Start () {
        
        self = this.GetComponent<BoxCollider2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(collision.collider, self);
		if (collision.gameObject.tag == "Item") {
			items.Add (collision.gameObject.name);
			Destroy (collision.gameObject);
		}
		if (collision.gameObject.tag == "Door" && items.Contains ("Key")) {
			items.Remove ("Key");
			Destroy (collision.gameObject);
		}
    }

    // Update is called once per frame
    void Update () {
        current_speed_x = Input.GetAxis("Horizontal") * speed;
        current_speed_y = Input.GetAxis("Vertical") * speed;

	}

    private void FixedUpdate()
    {

        this.transform.Translate(Time.deltaTime * current_speed_x * Vector2.right);
        this.transform.Translate(Time.deltaTime * current_speed_y * Vector2.up);
    }
}
