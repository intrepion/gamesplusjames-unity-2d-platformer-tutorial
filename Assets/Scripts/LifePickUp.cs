using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour
{
	private LifeManager lifeSystem;
	public AudioSource powerupSoundEffect;

	// Use this for initialization
	void Start ()
	{
		this.lifeSystem = FindObjectOfType<LifeManager> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			this.lifeSystem.GiveLife ();
			Debug.Log ("picked up life");
			this.powerupSoundEffect.Play ();
			Destroy (gameObject);
		}
	}
}
