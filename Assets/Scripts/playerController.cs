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
	public int score = 0;
	public bool doubleShot;
	public bool rapidFire;
	int rapidTimer = 0;
	// Use this for initialization
	void Start () {
		pos = transform.position;
		score = 0;
		health = 100;
		speed = 5f;
		doubleShot = false;
		rapidFire = false;
		rapidTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (health > 0) {
			score ++;
			Move();
			if (Input.GetMouseButtonDown(0)) {
				Shoot();
			}

			if (rapidTimer >= 3 && rapidFire) {
				rapidTimer = 0;
				Shoot();
			} else if (rapidFire) {
				rapidTimer ++;
			} else if (rapidTimer > 0) {
				rapidTimer = 0;
			}
		} else {
			transition.GetComponent<sceneController>().changeScene(1);
			transition.GetComponent<sceneController>().score = score;
		}

		if (doubleShot || rapidFire) {
			StartCoroutine("ResetPowerup");
		}

		healthText.GetComponent<Text>().text = "Health: " + health.ToString();
	}

	IEnumerator ResetPowerup() {
		 yield return new WaitForSeconds(5);
		 if (doubleShot) doubleShot = false;
		 if (rapidFire) rapidFire = false;
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
		if (doubleShot) {
			GameObject laser = Instantiate(Laser);
			laser.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 0.8f);

			GameObject laser2 = Instantiate(Laser);
			laser2.transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y + 0.8f);
		} else {
			GameObject laser = Instantiate(Laser);
			laser.transform.position = new Vector2(transform.position.x, transform.position.y + 0.8f);
		}
	}
}
