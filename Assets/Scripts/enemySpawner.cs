using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
	public GameObject Enemy;

	int enemyTimer = 0;
	int spawnChance;
	int healthChance;
	int health = 10;

	// Use this for initialization
	void Start () {
		enemyTimer = 0;
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyTimer >= 90) {
			spawnChance = Random.Range(1, 3);
			healthChance = Random.Range(0, 20);

			if (healthChance == 8) {
				health ++;
			}

			if (spawnChance == 2) {
				GameObject newEnemy = Instantiate(Enemy);
				newEnemy.transform.position = new Vector2(Random.Range(-6.6f, 6.6f), 4f);

				newEnemy.GetComponent<enemyController>().health = health;
			}

			enemyTimer = 0;
		} else {
			enemyTimer ++;
		}
	}
}
