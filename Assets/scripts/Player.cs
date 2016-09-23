using UnityEngine;

public class Player : MonoBehaviour
{
	public Vector2 jumpForce = new Vector2(0, 300);
	public GameObject particleEffect;

	private AudioSource clickSound;
	private new Rigidbody2D rigidbody;
	private bool collided = false;
	private int score = 0;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		clickSound = (AudioSource) GameObject.Find("ClickSound").GetComponent<AudioSource>();
	}

	void Update ()
	{
		if (Input.GetKeyDown("space") && !collided)
		{
			rigidbody.velocity = Vector2.zero;
			rigidbody.AddForce(jumpForce);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!collided) {
			collided = true;
			rigidbody.AddForce(new Vector2(200, 0));
		}

		foreach(ContactPoint2D contactPoint in collision.contacts) {
			Vector2 hitPoint = contactPoint.point;
			GameObject effect = (GameObject) Instantiate(particleEffect, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
			Destroy(effect, 1);
		}
		clickSound.Play();
	}

	public bool IsCollided()
	{
		return collided;
	}

	public int GetScore()
	{
		return score;
	}

	public void SetScore(int score)
	{
		this.score = score;
	}
}