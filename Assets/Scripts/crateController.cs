using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateController : MonoBehaviour {
	public string type;
	public GameObject player;

	Vector2 cratePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cratePos = transform.position;

		cratePos.y -= 0.1f;

		if (cratePos.y <= -5.55) {
			Destroy(gameObject);
		}

		transform.position = cratePos;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			if (type == "Double Shot") {
				player.GetComponent<playerController>().doubleShot = true;
			} else if (type == "Rapid Fire") {
				player.GetComponent<playerController>().rapidFire = true;
			}

			Destroy(gameObject);
		}
	}
}
