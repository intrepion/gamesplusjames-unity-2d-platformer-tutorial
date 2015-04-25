using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour
{
	private PlayerController thePlayer;

	// Use this for initialization
	void Start ()
	{
		this.thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			this.thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "Player") {
			this.thePlayer.onLadder = false;
		}
	}
}
