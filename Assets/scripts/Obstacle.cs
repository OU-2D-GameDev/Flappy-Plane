using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{

	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 4;

	private Text scoreText;
	private Player player;

	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = velocity;
		transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		player = (Player) GameObject.Find("player").GetComponent(typeof(Player));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(!player.IsCollided()) {
			player.SetScore(player.GetScore() + 1);
			scoreText.text = "" + player.GetScore();
			Debug.Log("Triggered");
		}
	}
}