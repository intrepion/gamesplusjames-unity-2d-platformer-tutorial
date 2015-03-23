using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private new Rigidbody2D rigidbody2D;
	private bool grounded;
	private bool doubleJumped;
	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		this.rigidbody2D = GetComponent<Rigidbody2D> ();
		this.anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		this.grounded = Physics2D.OverlapCircle (this.groundCheck.position, this.groundCheckRadius, this.whatIsGround);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (grounded) {
			this.doubleJumped = false;
		}

		this.anim.SetBool ("Grounded", this.grounded);

		if (Input.GetKeyDown (KeyCode.Space) && this.grounded) {
			this.Jump ();
		}

		if (Input.GetKeyDown (KeyCode.Space) && !this.doubleJumped && !this.grounded) {
			this.Jump ();
			this.doubleJumped = true;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.rigidbody2D.velocity = new Vector2(this.moveSpeed, this.rigidbody2D.velocity.y);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.rigidbody2D.velocity = new Vector2(-this.moveSpeed, this.rigidbody2D.velocity.y);
		}

		this.anim.SetFloat ("Speed", Mathf.Abs(this.rigidbody2D.velocity.x));

		if (this.rigidbody2D.velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (this.rigidbody2D.velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}

	public void Jump()
	{
		this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, this.jumpHeight);
	}
}
