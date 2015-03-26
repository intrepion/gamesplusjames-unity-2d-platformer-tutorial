using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
	public int enemyHealth;
	public GameObject deathEffect;
	public int pointsOnDeath;

	private AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		this.audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enemyHealth <= 0) {
			Instantiate (this.deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(this.pointsOnDeath);
			Destroy (gameObject);
		}
	}

	public void giveDamage (int damageToGive)
	{
		this.enemyHealth -= damageToGive;
		this.audio.Play ();
	}
}
