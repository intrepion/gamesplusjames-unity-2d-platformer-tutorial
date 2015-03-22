using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

	private LevelManager levelManager;

	// Use this for initialization
	void Start ()
	{
		this.levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			this.levelManager.RespawnPlayer ();
		}
	}
}
