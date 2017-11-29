using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public int count = 0;
	public string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 2) {
			SceneManager.LoadScene (scene);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.transform.tag == "Player") {
			count++;
		}
	}
}
