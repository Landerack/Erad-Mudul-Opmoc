using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool run = true;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (horizontalMove != 0)
		{
			animator.SetBool("Moving", true);
		}
		else {
			animator.SetBool("Moving", false);
		}

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("CrouchOff"))
		{
			if (run == true)
			{
				run = false;
				animator.SetBool("running", false);
			}
			else if (run == false)
			{
				run = true;
				animator.SetBool("running", true);
			}
		}
	}

	void FixedUpdate ()
		{
			// Move our character
			controller.Move(horizontalMove * Time.fixedDeltaTime, run, jump);
			jump = false;
		}
}
