using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	private bool isClimbing = false;
	private Ladder currentLadder;

	public float climbSpeed = 5f;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private bool isGrounded = false; // Track if the player is grounded
	private int jumpCount = 0;
	public Transform groundCheck;
	public float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	private bool canDoubleJump = false;
	public int extraLives = 3;
	[SerializeField] private Rigidbody2D rb;
	
	// Update is called once per frame
	void Update () {
		bool isSprinting = Input.GetKey(KeyCode.LeftShift);
		float currentRunSpeed = isSprinting ? runSpeed * 2 : runSpeed;
		horizontalMove = Input.GetAxisRaw("Horizontal") * currentRunSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		

		if (isClimbing)
		{
			float verticalInput = Input.GetAxis("Vertical");
			float verticalVelocity = verticalInput * climbSpeed;
			
			animator.SetBool("IsClimbing", true);
		}
		

		if (isGrounded)
		{
			jumpCount = 0; // Reset the jump count when grounded
		}

		if (Input.GetButtonDown("Jump"))
		{
			if (isGrounded || jumpCount < 2)
			{
				jump = true;
				animator.SetBool("IsJumping", true);
				jumpCount++; // Increment the jump count
			}
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}
	
	
	

	public void Onlanding()
    {
		animator.SetBool("IsJumping", false);
    }

	public void OnCrouching(bool isCrouching)
    {
		animator.SetBool("IsCrouching", isCrouching);
    }
	public void SetLadder(Ladder ladder)
	{
		if (!isClimbing)
		{
			currentLadder = ladder;
			isClimbing = true;
			// Additional logic for setting up climbing behavior (e.g., disable gravity)
		}
	}
	public void ExitLadder()
	{
		if (isClimbing)
		{
			currentLadder = null;
			isClimbing = false;
			// Additional logic for exiting climbing behavior (e.g., enable gravity)
		}
	}
	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

		jump = false;
	}
}
