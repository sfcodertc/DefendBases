using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {
	public GameObject Laser;
	public int health;
	public Text healthText;
	public Material enemyLaser;

	Vector2 enemyPos;
	int timer = 0;

	// Use this for initialization
	void Start () {
		enemyPos = transform.position;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyPos.y > 5.55 || enemyPos.y < -5.55) {
			Destroy(gameObject);
		}

		if (health <= 0) {
			Destroy(gameObject);
		}

		if (timer >= 60) {
			shoot();
			timer = 0;
		} else {
			timer ++;
		}

		 healthText.GetComponent<Text>().text = "Health: " + health.ToString();
	}

	void shoot() {
		GameObject laser = Instantiate(Laser);
		laser.transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
		laser.GetComponent<laserController>().dir = "down";
		laser.GetComponent<Renderer>().material = enemyLaser;

		enemyPos.y -= 0.1f;

		transform.position = enemyPos;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<playerController>().health -= 20;
			Destroy(gameObject);
		}

		if (col.gameObject.tag == "Base") {
			col.gameObject.GetComponent<baseController>().health -= 30;
		}
	}
}
