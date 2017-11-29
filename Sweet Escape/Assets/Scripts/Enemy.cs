using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy: MonoBehaviour {

	public Player_Controller p1;
	public Player_Controller_P2 p2;
	public float speed;
	public bool had_key1 = false;
	public bool had_key2 = false;
	public Player_Controller Player1;
	public Player_Controller_P2 Player2;

    // Use this for initialization
    void Start () {
		p1 = FindObjectOfType<Player_Controller> ();
		p2 = FindObjectOfType<Player_Controller_P2> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Time.deltaTime * Vector2.right * gameObject.transform.localScale.x * speed);
	}


    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player")
        {
			if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player1(Clone)")
            {
				if (p1.items.Contains ("Key")) {
					had_key1 = true;
				}
                Destroy(collision.gameObject);
                p1 = Instantiate(Player1);
				if (had_key1)
					p1.items.Add ("Key");
            }

            else
            {
				if (p2.items.Contains ("Key")) {
					had_key2 = true;
				}
                Destroy(collision.gameObject);
                p2 = Instantiate(Player2);
				if (had_key2)
					p2.items.Add ("Key");
            }
        }
        gameObject.transform.localScale = new Vector2 (-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
		
	}
}
