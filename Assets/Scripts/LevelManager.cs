using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;

	private PlayerController player;
	private Renderer playerRenderer;

	// Use this for initialization
	void Start ()
	{
		this.player = FindObjectOfType<PlayerController> ();
		this.playerRenderer = this.player.GetComponent<Renderer> ();
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
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (this.respawnDelay);
		this.player.transform.position = this.currentCheckpoint.transform.position;
		this.player.enabled = true;
		this.playerRenderer.enabled = true;
		Instantiate (this.respawnParticle, this.currentCheckpoint.transform.position, this.currentCheckpoint.transform.rotation);
	}
}
