using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Generate : MonoBehaviour
{


	public GameObject rocks;
	public GameObject restartText;
	public float timeBetweenRocks = 1.35f;
	public float startDelay = 1f;

	private List<GameObject> rockList;
	private Player player;
	private Rigidbody2D playerRigidBody;
	private ParticleSystem smokeSystem;
	private AudioSource planeSound;

	void Start()
	{
		rockList = new List<GameObject>();
		player = (Player) GameObject.Find("player").GetComponent(typeof(Player));
		playerRigidBody = player.GetComponent<Rigidbody2D>();
		smokeSystem = (ParticleSystem) GameObject.Find("Smoke System").GetComponent<ParticleSystem>();
		InvokeRepeating("CreateObstacle", startDelay, timeBetweenRocks);
		planeSound = (AudioSource) GameObject.Find("PlaneSound").GetComponent<AudioSource>();
	}

	void Update()
	{
		if(Input.GetKeyDown("escape"))
			Application.Quit();

		if(rockList.Count > 0) {
			if(rockList[0].transform.position.x < -24) {
				Destroy(rockList[0]);
				rockList.RemoveAt(0);
			}
		}

		if(player.IsCollided()) {
			for (int i = 0; i < rockList.Count; i++) {
				rockList[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}
			CancelInvoke();
			GameObject textObject = (GameObject) Instantiate(restartText, new Vector3(0, 0, 0f), Quaternion.identity);
			textObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
			var emission = smokeSystem.emission;
			emission.enabled = false;
			planeSound.Stop();
			Destroy(this);
		} else
			smokeSystem.emissionRate = 25 + Mathf.Abs(playerRigidBody.velocity.y * 6);
	}

	void CreateObstacle()
	{
		GameObject clone = (GameObject) Instantiate(rocks);
		rockList.Add(clone);
	}
}