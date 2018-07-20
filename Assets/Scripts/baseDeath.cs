using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseDeath : MonoBehaviour {
	public GameObject transition;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount == 0) {
			transition.GetComponent<sceneController>().changeScene(1);
			transition.GetComponent<sceneController>().score = player.GetComponent<playerController>().score;
		}
	}
}
