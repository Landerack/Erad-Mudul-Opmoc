using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool run = true;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("CrouchOff"))
		{
			if (run == true)
			{
				run = false;
			}
			else if (run == false)
			{
				run = true;
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