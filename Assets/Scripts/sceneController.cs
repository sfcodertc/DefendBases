using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneController : MonoBehaviour {
	public int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			scoreText.GetComponent<Text>().text = "Your Score Was: \n" + score.ToString();

			if (Input.GetMouseButtonDown(0)) {
				changeScene(0);
			}
		}
	}

	public void changeScene(int scene) {
		SceneManager.LoadScene(scene);
	}
}
