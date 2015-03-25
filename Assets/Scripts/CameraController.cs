using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public PlayerController player;
	public bool isFollowing;
	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start ()
	{
		this.player = FindObjectOfType<PlayerController> ();

		this.isFollowing = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.isFollowing) {
			transform.position = new Vector3(player.transform.position.x + this.xOffset, player.transform.position.y + this.yOffset, transform.position.z);
		}
	}
}
