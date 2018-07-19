using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour {
<<<<<<< HEAD
	public float speed = 4f;
	public string dir = "up";

	Vector2 laserPos;

	// Use this for initialization
	void Start () {

=======

	// Use this for initialization
	void Start () {
		
>>>>>>> 5574b5521f5102724accbd3606b603d49964f5f3
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		Move();
	}

	void Move() {
		laserPos = transform.position;

		if (laserPos.y > 5.55 || laserPos.y < -5.55) {
			Destroy(gameObject);
		}

		if (dir == "up") {
			laserPos.y += speed * Time.deltaTime;
		} else if (dir == "down") {
			laserPos.y -= speed * Time.deltaTime;
		}

		transform.position = laserPos;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<playerController>().health -= 5;
			Destroy(gameObject);
		}

		if (other.gameObject.tag == "Laser") {
			if (other.gameObject.GetComponent<laserController>().dir == "down" && dir == "up"
			 || other.gameObject.GetComponent<laserController>().dir == "up" && dir == "down")
				Destroy(gameObject);
		}

		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<enemyController>().health -= 5;
			Destroy(gameObject);
		}
=======
		
>>>>>>> 5574b5521f5102724accbd3606b603d49964f5f3
	}
}
