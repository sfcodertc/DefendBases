using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateSpawner : MonoBehaviour {
	public GameObject crate;
	public GameObject player;

	int crateTimer = 0;
	int spawnChance;
	int typeChance;

	// Use this for initialization
	void Start () {
		crateTimer = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (crateTimer >= 300) {
			spawnChance = Random.Range(0, 6);
			typeChance = Random.Range(0, 2);

			if (spawnChance == 3) {
				GameObject newCrate = Instantiate(crate);
				newCrate.transform.position = new Vector2(Random.Range(-6.6f, 6.6f), 5.55f);
				newCrate.GetComponent<crateController>().player = player;

				if (typeChance == 0) {
					newCrate.GetComponent<crateController>().type = "Double Shot";
				} else if (typeChance == 1) {
					newCrate.GetComponent<crateController>().type = "Rapid Fire";
				}
			}

			crateTimer = 0;
		} else {
			crateTimer ++;
		}
	}
}
