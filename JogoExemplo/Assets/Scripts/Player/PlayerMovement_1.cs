using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D_1))]
public class PlayerMovement_1 : MonoBehaviour
{
    private CharacterController2D_1 controller;

    public float movementSpeed;
    public float jumpHeight;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController2D_1>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = horizontalInput * movementSpeed;

        controller.Move(horizontalMovement * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Jump(jumpHeight);
        }
    }
}
