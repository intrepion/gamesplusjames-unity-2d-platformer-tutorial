using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour
{
	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;
	public float rotationSpeed;
	public int damageToGive;

	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
		this.player = FindObjectOfType<PlayerController> ();

		if (this.player.transform.localScale.x < 0) {
			this.speed = -this.speed;
			this.rotationSpeed = -this.rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.rigidbody2D.velocity = new Vector2 (this.speed, this.rigidbody2D.velocity.y);
		this.rigidbody2D.angularVelocity = this.rotationSpeed;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyHealthManager> ().giveDamage(this.damageToGive);
		}

		Instantiate (this.impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
