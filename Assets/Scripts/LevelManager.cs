using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;
	public HealthManager healthManager;

	private PlayerController player;
	private Renderer playerRenderer;
	private Rigidbody2D playerRigidbody2D;
	private float gravityStore;
	private CameraController camera;

	// Use this for initialization
	void Start ()
	{
		this.player = FindObjectOfType<PlayerController> ();
		this.playerRenderer = this.player.GetComponent<Renderer> ();
		this.playerRigidbody2D = this.player.GetComponent<Rigidbody2D> ();
		this.camera = FindObjectOfType<CameraController> ();
		this.healthManager = FindObjectOfType<HealthManager> ();
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
		this.camera.isFollowing = false;
		ScoreManager.AddPoints (-this.pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (this.respawnDelay);
		this.playerRigidbody2D.velocity = new Vector2 (0, 0);
		this.player.transform.position = this.currentCheckpoint.transform.position;
		this.player.knockbackCount = 0;
		this.player.enabled = true;
		this.playerRenderer.enabled = true;
		this.healthManager.FullHealth ();
		this.healthManager.isDead = false;
		this.camera.isFollowing = true;
		Instantiate (this.respawnParticle, this.currentCheckpoint.transform.position, this.currentCheckpoint.transform.rotation);
	}
}
