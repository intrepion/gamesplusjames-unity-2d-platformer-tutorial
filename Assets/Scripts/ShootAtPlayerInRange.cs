using UnityEngine;
using System.Collections;

public class ShootAtPlayerInRange : MonoBehaviour
{
	public float playerRange;
	public GameObject enemyStar;
	public PlayerController player;
	public Transform launchPoint;
	public float waitBetweenShots;

	private float shotCounter;

	// Use this for initialization
	void Start ()
	{
		this.player = FindObjectOfType<PlayerController> ();
		this.shotCounter = this.waitBetweenShots;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.DrawLine (new Vector3 (transform.position.x - this.playerRange, transform.position.y, transform.position.z), new Vector3 (transform.position.x + this.playerRange, transform.position.y, transform.position.z));
		this.shotCounter -= Time.deltaTime;

		if (this.shotCounter < 0) {
			if (transform.localScale.x < 0 && this.player.transform.position.x > transform.position.x && this.player.transform.position.x < transform.position.x + this.playerRange) {
				this.Shoot ();
			}

			if (transform.localScale.x > 0 && this.player.transform.position.x < transform.position.x && this.player.transform.position.x > transform.position.x - this.playerRange) {
				this.Shoot ();
			}
		}
	}

	void Shoot ()
	{
		Instantiate (this.enemyStar, this.launchPoint.position, this.launchPoint.rotation);
		this.shotCounter = this.waitBetweenShots;
	}
}
