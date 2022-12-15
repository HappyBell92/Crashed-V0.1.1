using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	private float moveSpeed;
	public float walkSpeed;
	public float sprintSpeed;
	public float rotationSpeed;

	

	public float groundDrag;
	public float groundCheck = 0.3f;

	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	bool readyToJump;

	[Header("Keybinds")]
	public KeyCode jumpKey = KeyCode.Space;
	public KeyCode sprintKey = KeyCode.LeftShift;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask WhatIsGround;
	public bool grounded;

	[Header("Slope Handling")]
	public float maxSlopeAngle;
	public float steepSlopeAngle;
	private RaycastHit slopeHit;
	private bool exitingSlope;

	[Header("Sounds")]
	public AudioSource walkSand;
	public AudioSource walkStone;
	public AudioSource jumpSand;
	public AudioSource jumpStone;

	public Camera playerCamera;
	float maxVelocityChange = 10.0f;

	public Transform orientation;

	private float vertical;
	private float horizontal;
	private float rotateAround;

	float horizontalInput;
	float verticalInput;

	public bool flashlightOn;
	public GameObject flashlight;

	public GameObject pauseMenu;
	public Orientationcheck orientationScript;
	public bool isPaused;

	public bool onSand;
	public bool onStone;

	Vector3 movementDirection;

	Rigidbody rb;

	public MovementState state;
	public enum MovementState
	{
		walking,
		sprinting,
		air
	}

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;

		readyToJump = true;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		flashlightOn = true;

		isPaused = false;

		//orientationScript = GameObject.Find("Player").GetComponent<Orientationcheck>();
	}

	private void FixedUpdate()
	{
		MovePlayer();

		//Ray ray = new Ray(transform.position, -transform.up);
		//RaycastHit hit;

		//if (Physics.Raycast(ray, out hit, playerHeight * 0.5f, WhatIsGround))
		//{
		//    Debug.DrawRay(transform.position, -transform.up * playerHeight * 0.5f, Color.yellow);
		//    if (hit.transform.tag == "Sand")
		//    {
		//        onSand = true;
		//    }

		//    else
		//    {
		//        onSand = false;
		//    }

		//    if(hit.transform.tag == "Stone")
		//    {
		//        onStone = true;
		//    }

		//    else
		//    {
		//        onStone = false;
		//    }
		//}
	}

	// Update is called once per frame
	void Update()
	{
		// Ground Check
		grounded = Physics.Raycast(transform.position, -transform.up, playerHeight * 0.5f + groundCheck, WhatIsGround);
		//Debug.DrawRay(transform.position, -transform.up, Color.green, Time.deltaTime);

		// ground material check
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		Debug.DrawRay(transform.position, -transform.up * playerHeight * 0.51f, Color.yellow);
		if (Physics.Raycast(ray, out hit, playerHeight * 0.51f, WhatIsGround))
		{
			Debug.Log("hit: "+hit.transform.tag);
			if (hit.transform.tag == "Sand")
			{
				onSand = true;
			}

			else
			{
				onSand = false;
			}

			if (hit.transform.tag == "Stone")
			{
				onStone = true;
			}

			else
			{
				onStone = false;
			}
		}

		MyInput();
		SpeedControl();
		StateHandler();
		

		// Handle drag
		if (grounded)
			rb.drag = groundDrag;
		else
			rb.drag = 0;

		// If on a steep slope pushes player down
		if (SteepSlope())
		{
			//Debug.Log("Too Steep!");
			rb.AddForce(-transform.up * 150f, ForceMode.Force);
		}

		// Flashlight
		if (Input.GetKeyDown(KeyCode.F) && !flashlightOn)
		{
			flashlightOn = true;
			flashlight.SetActive(true);
		}
		else if (Input.GetKeyDown(KeyCode.F) && flashlightOn)
		{
			flashlightOn= false;
			flashlight.SetActive(false);
		}

		// Pause Menu
		if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
		{
			Cursor.visible = true;
			Time.timeScale = 0;
			pauseMenu.SetActive(true);
			orientationScript.enabled = false;
			isPaused = true;
		}

		else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
		{
			Cursor.visible = false;
			Time.timeScale = 1;
			pauseMenu.SetActive(false);
			orientationScript.enabled = true;
			isPaused = false;
		}

		if (isPaused)
		{
			Cursor.visible = true;
			Cursor.lockState= CursorLockMode.Confined;
			Time.timeScale = 0;
		}
		else
		{
			Cursor.visible = false;
			Cursor.lockState= CursorLockMode.Locked;
			Time.timeScale = 1;
		}


	}

	private void MyInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");

		// when to jump
		if (Input.GetKey(jumpKey) && readyToJump && grounded)
		{
			readyToJump = false;

			Jump();

			Invoke(nameof(ResetJump), jumpCooldown);
		}

	}

	private void StateHandler()
	{
		
		// Mode - sprinting
		if(grounded && Input.GetKey(sprintKey))
		{
			//Debug.Log("Sprinting");
			state = MovementState.sprinting;
			moveSpeed = sprintSpeed;
		}

		// Mode - walking
		else if (grounded)
		{
			state = MovementState.walking;
			moveSpeed = walkSpeed;
		}

		// Mode - air
		else
		{
			state = MovementState.air;
		}
	}

	private void MovePlayer()
	{
		// Calculate movement direction;
		movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
		rotateAround = Input.GetAxis("Mouse X");

		//On slope
		if (OnSlope() && !exitingSlope)
		{
			rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

			if (rb.velocity.y > 0)
				rb.AddForce(Vector3.down * 80f, ForceMode.Force);
		}

		// On ground
		//if (grounded)
		//{
		//    //rb.addforce(movementdirection * movespeed * 10f, forcemode.force);
		//    //rb.velocity = (transform.forward * vertical) * movespeed;
		//    rb.velocity = (movementDirection) * moveSpeed;
		//    //rb.velocity = (transform.right * horizontal) * movespeed;
		//    //transform.rotate((transform.up * rotatearound) * rotationspeed * time.deltatime);


		//}

		Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
		Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
		Vector3 targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")) * moveSpeed;

		Vector3 velocity = transform.InverseTransformDirection(rb.velocity);
		velocity.y = 0;
		velocity = transform.TransformDirection(velocity);
		Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
		velocityChange = transform.TransformDirection(velocityChange);

		rb.AddForce(velocityChange, ForceMode.VelocityChange);

		if(rb.velocity.sqrMagnitude > 2f && grounded)
		{

		}


		//In air
		//else
		//    {
		//    //rb.AddForce(movementDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);
		//    rb.velocity = (movementDirection) * moveSpeed * airMultiplier;
		//    Vector3 v = rb.velocity;
		//    v.y = -5f;
		//    rb.velocity = v;
		//    //transform.Rotate((transform.up * rotateAround) * rotationSpeed * Time.deltaTime);
		//}


		//Turn gravity off on slope
		rb.useGravity = !OnSlope();
	}

	private void SpeedControl()
	{
		// Limit speed on slope
		if (OnSlope() && !exitingSlope)
		{
			if (rb.velocity.magnitude > moveSpeed)
				rb.velocity = rb.velocity.normalized * moveSpeed;
		}

		// Limit speed on ground or in air
		//else
		//{
		Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		// Limit Velocity if needed
		//if (flatVel.magnitude > moveSpeed)
		//{
		//    Vector3 limitedVel = flatVel.normalized * moveSpeed;
		//    rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
		//}
		//}


	}

	private void Jump()
	{
		exitingSlope = true;

		// reset y velocity
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

	private void ResetJump()
	{
		readyToJump = true;

		exitingSlope = false;
	}

	private bool OnSlope()
	{
		if (Physics.Raycast(transform.position, -transform.up, out slopeHit, playerHeight * 0.5f + 0.4f))
		{
			//Debug.Log("I am on a slope!");
			float angle = Vector3.Angle(transform.up, slopeHit.normal);
			return angle < maxSlopeAngle && angle != 0;
		}

		return false;
	}

	private bool SteepSlope()
	{
		if (Physics.Raycast(transform.position, -transform.up, out slopeHit, playerHeight * 0.5f + 0.5f))
		{
			float angle = Vector3.Angle(transform.up, slopeHit.normal);
			return angle > steepSlopeAngle && angle != 0;
		}

		return false;
	}

	private Vector3 GetSlopeMoveDirection()
	{
		return Vector3.ProjectOnPlane(movementDirection, slopeHit.normal).normalized;
	}
}
