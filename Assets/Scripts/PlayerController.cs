using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		this.rigidbody2D = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, jumpHeight);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			this.rigidbody2D.velocity = new Vector2(moveSpeed, this.rigidbody2D.velocity.y);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.rigidbody2D.velocity = new Vector2(-moveSpeed, this.rigidbody2D.velocity.y);
		}
		
	}
}
