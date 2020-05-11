using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    private Vector2 velocity;
    private float velocityXSmoothing;
    public float movementSpeed = 20f;
    public float accelerationTimeAirborne = .2f;
	public float accelerationTimeGrounded = .1f;
    private float jumpVelocity;
    private float gravity;
    public float jumpHeight = 4f;
    public float timeToJumpApex = 0.4f;
    public bool isGrounded;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController2D>();

        gravity = -(jumpHeight * 2) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.collisions.below)
            velocity.y = 0f;

        isGrounded = controller.collisions.below;

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.UpArrow) && controller.collisions.below)
            velocity.y = jumpVelocity;

        float targetVelocityX = horizontalInput * movementSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
