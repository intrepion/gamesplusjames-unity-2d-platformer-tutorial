using UnityEngine;
using System.Collections;

public class FlyerEnemyMove : MonoBehaviour
{
	public float moveSpeed;
	public float playerRange;
	public LayerMask playerLayer;
	public bool playerInRange;
	public bool facingAway;
	public bool followOnLookAway;

	private PlayerController thePlayer;

	// Use this for initialization
	void Start ()
	{
		this.thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((this.thePlayer.transform.position.x < this.transform.position.x && this.thePlayer.transform.localScale.x < 0)
			|| (this.thePlayer.transform.position.x > this.transform.position.x && this.thePlayer.transform.localScale.x > 0)) {
			this.facingAway = true;
		} else {
			this.facingAway = false;
		}

		if ((this.followOnLookAway && this.facingAway) || (!this.followOnLookAway)) {
			this.playerInRange = Physics2D.OverlapCircle (this.transform.position, this.playerRange, this.playerLayer);
			if (this.playerInRange) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, this.thePlayer.transform.position, this.moveSpeed * Time.deltaTime);
			}
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.DrawSphere (this.transform.position, this.playerRange);
	}
}
