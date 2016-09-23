using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown("space"))
			SceneManager.LoadScene("Game");

		if(Input.GetKeyDown("escape"))
			Application.Quit();
	}
}
