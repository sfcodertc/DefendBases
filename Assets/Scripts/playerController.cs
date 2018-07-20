using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
	public float speed = 4f;
	public int health = 100;
	public GameObject Laser;
	public GameObject healthText;
	public GameObject transition;
	Vector3 pos;
	int score = 0;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		score = 0;
		health = 100;
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (health > 0) {
			score ++;
			Move();
			Shoot();
		} else {
			transition.GetComponent<sceneController>().changeScene(1);
			transition.GetComponent<sceneController>().score = score;
			Debug.Log(score);
		}

		healthText.GetComponent<Text>().text = "Health: " + health.ToString();
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
			laser.transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
		}
	}
}
