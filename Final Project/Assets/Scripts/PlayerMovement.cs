using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] string m_HorizontalKey;
	[SerializeField] string m_JumpKey;
	[SerializeField] string m_CrouchKey;
	[SerializeField] CharacterController2D controller;
	[SerializeField] Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw(m_HorizontalKey) * runSpeed;

		animator.SetFloat ("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown(m_JumpKey))
		{
			jump = true;
			animator.SetBool ("IsJumping", true);
		}

		if (Input.GetButtonDown(m_CrouchKey))
		{
			crouch = true;
		} else if (Input.GetButtonUp(m_CrouchKey))
		{
			crouch = false;
		}

	}

	public void OnLanding ()
	{
		animator.SetBool ("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool ("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
