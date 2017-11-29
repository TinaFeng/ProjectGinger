using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotFudge : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			if (collision.gameObject.name == "Player1") {
				Destroy (collision.gameObject);
				Instantiate (Player1);
			} else {

				Destroy (collision.gameObject);
				Instantiate (Player2);
			}
		}
	}
}
