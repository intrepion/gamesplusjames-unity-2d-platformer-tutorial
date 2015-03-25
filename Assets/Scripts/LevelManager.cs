using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;

	private PlayerController player;
	private Renderer playerRenderer;
	private Rigidbody2D playerRigidbody2D;
	private float gravityStore;

	// Use this for initialization
	void Start ()
	{
		this.player = FindObjectOfType<PlayerController> ();
		this.playerRenderer = this.player.GetComponent<Renderer> ();
		this.playerRigidbody2D = this.player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void RespawnPlayer ()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo ()
	{
		Instantiate (this.deathParticle, this.player.transform.position, this.player.transform.rotation);
		this.player.enabled = false;
		this.playerRenderer.enabled = false;
		this.gravityStore = this.playerRigidbody2D.gravityScale;
		this.playerRigidbody2D.gravityScale = 0f;
		this.playerRigidbody2D.velocity = Vector2.zero;
		ScoreManager.AddPoints (-this.pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (this.respawnDelay);
		this.playerRigidbody2D.gravityScale = this.gravityStore;
		this.player.transform.position = this.currentCheckpoint.transform.position;
		this.player.enabled = true;
		this.playerRenderer.enabled = true;
		Instantiate (this.respawnParticle, this.currentCheckpoint.transform.position, this.currentCheckpoint.transform.rotation);
	}
}
