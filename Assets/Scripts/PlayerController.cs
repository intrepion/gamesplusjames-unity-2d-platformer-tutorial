using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public Transform firePoint;
	public GameObject ninjaStar;
	public float shotDelay;
	public float knockback;
	public float knockbackLength;
	public bool knockFromRight;
	public float knockbackCount;

	private new Rigidbody2D rigidbody2D;
	private bool grounded;
	private bool doubleJumped;
	private Animator anim;
	private float moveVelocity;
	private float shotDelayCounter;

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

		if (Input.GetButtonDown ("Jump") && this.grounded) {
			this.Jump ();
		}

		if (Input.GetButtonDown ("Jump") && !this.doubleJumped && !this.grounded) {
			this.Jump ();
			this.doubleJumped = true;
		}

		this.moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");

		if (this.knockbackCount <= 0) {
			this.rigidbody2D.velocity = new Vector2 (this.moveVelocity, this.rigidbody2D.velocity.y);
		} else {
			if (this.knockFromRight) {
				this.rigidbody2D.velocity = new Vector2 (-this.knockback, this.knockback);
			} else {
				this.rigidbody2D.velocity = new Vector2 (this.knockback, this.knockback);
			}
			this.knockbackCount -= Time.deltaTime;
		}

		this.anim.SetFloat ("Speed", Mathf.Abs(this.rigidbody2D.velocity.x));

		if (this.rigidbody2D.velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (this.rigidbody2D.velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (Input.GetButtonDown ("Fire1")) {
			Instantiate(this.ninjaStar, this.firePoint.position, this.firePoint.rotation);
			this.shotDelayCounter = this.shotDelay;
		}

		if (Input.GetButton ("Fire1")) {
			this.shotDelayCounter -= Time.deltaTime;

			if (this.shotDelayCounter <= 0) {
				this.shotDelayCounter = this.shotDelay;
				Instantiate(this.ninjaStar, this.firePoint.position, this.firePoint.rotation);
			}
		}

		if (this.anim.GetBool ("Sword")) {
			this.anim.SetBool ("Sword", false);
		}

		if (Input.GetButtonDown ("Fire2")) {
			this.anim.SetBool ("Sword", true);
		}
	}

	public void Jump()
	{
		this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, this.jumpHeight);
	}
}
