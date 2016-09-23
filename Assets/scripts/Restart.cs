using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Restart : MonoBehaviour {
	
	public GameObject scoreText;
	private int delta = 0;

	void Start() {
		GetComponent<Text>().text = "Crashed!\nPress space to restart\n\nScore "
			+ GameObject.Find("ScoreText").GetComponent<Text>().text;
	}

	void Update () {
		if (delta > 13) {
			if(Input.GetKeyDown("space")) {
				SceneManager.LoadScene("Game");
			}
		} else
			delta++;
	}
}
