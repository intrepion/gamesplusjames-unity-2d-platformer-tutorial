using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour
{
	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;

	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
		this.player = FindObjectOfType<PlayerController> ();

		if (this.player.transform.localScale.x < 0) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {
			Instantiate (this.enemyDeathEffect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints(this.pointsForKill);
		}

		Instantiate (this.impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
