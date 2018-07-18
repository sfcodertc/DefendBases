using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public float speed = 4f;
	public GameObject Laser;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Shoot();
	}

	void Move() {
		transform.position = pos;
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) && pos.x < 6.6) {
			pos.x += speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && pos.x > -6.6) {
			pos.x -= speed * Time.deltaTime;
		}
	}

	void Shoot() {
		if (Input.GetMouseButtonDown(0)) {
			GameObject laser = Instantiate(Laser);
			laser.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
			
		}
	}
}
