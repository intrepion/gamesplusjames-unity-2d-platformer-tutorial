using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private bool grounded;
	private bool doubleJumped;
	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		this.grounded = Physics2D.OverlapCircle (this.groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (grounded) {
			this.doubleJumped = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && this.grounded) {
			this.Jump ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !this.doubleJumped && !this.grounded) {
			this.Jump ();
			this.doubleJumped = true;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.rigidbody2D.velocity = new Vector2(moveSpeed, this.rigidbody2D.velocity.y);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.rigidbody2D.velocity = new Vector2(-moveSpeed, this.rigidbody2D.velocity.y);
		}
		
	}

	private void Jump()
	{
		this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, jumpHeight);
	}
}
