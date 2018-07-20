using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baseController : MonoBehaviour {
	public int health = 150;
	public Text healthText;

	// Use this for initialization
	void Start () {
		health = 150;
	}
	
	// Update is called once per frame
	void Update () {
		healthText.GetComponent<Text>().text = "Health: " + health.ToString();
	}
}
