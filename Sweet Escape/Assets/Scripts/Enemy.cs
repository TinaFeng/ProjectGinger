using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy: MonoBehaviour {

	public float speed;
    public GameObject Player1;
    public GameObject Player2;

    // Use this for initialization
    void Start () {
		
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
                Destroy(collision.gameObject);
                Instantiate(Player1);
            }

            else
            {

                Destroy(collision.gameObject);
                Instantiate(Player2);
            }
        }
        gameObject.transform.localScale = new Vector2 (-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
		
	}
}
