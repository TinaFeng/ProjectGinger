using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy: MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Time.deltaTime * Vector2.right * gameObject.transform.localScale.x * speed);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			//killplayer
		}
		if (col.gameObject.tag == "Wall") {
			gameObject.transform.localScale = new Vector2 (-gameObject.transform.localScale.x, gameObject.transform.localScale.y);
		}
	}
}
