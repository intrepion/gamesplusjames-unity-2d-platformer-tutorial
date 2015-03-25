using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{

	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public Transform edgeCheck;
	
	private new Rigidbody2D rigidbody2D;
	private bool hittingWall;
	private bool notAtEdge;

	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.hittingWall = Physics2D.OverlapCircle (this.wallCheck.position, this.wallCheckRadius, this.whatIsWall);
		this.notAtEdge = !Physics2D.OverlapCircle (this.edgeCheck.position, this.wallCheckRadius, this.whatIsWall);

		if (this.hittingWall || this.notAtEdge) {
			this.moveRight = !this.moveRight;
		}

		if (this.moveRight) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			this.rigidbody2D.velocity = new Vector2 (moveSpeed, this.rigidbody2D.velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			this.rigidbody2D.velocity = new Vector2 (-moveSpeed, this.rigidbody2D.velocity.y);
		}
	}
}
