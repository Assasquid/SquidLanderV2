using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float swimSpeed = 2000f;
    [SerializeField] float rotationSpeed = 300f;

    float horizontalInput = 0f;

    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal") * rotationSpeed *Time.deltaTime;
        Debug.Log(Input.GetAxisRaw("Horizontal"));

        RespondToRotateInput();
        RespondToSwimInput();
    }

    private void RespondToSwimInput()
    {
        if (Input.GetButton("Swim"))
        {

            if (Input.GetButton("Boost"))
            {
                ApplySwim(swimSpeed * 4);
            }

            else
            {
                ApplySwim(swimSpeed);
            }
        }
    }

    private void ApplySwim(float actualSpeed)
    {
        FreezeRotation(true);
        float speedThisFrame = actualSpeed * Time.deltaTime;
        rigidBody2D.AddRelativeForce(Vector3.up * speedThisFrame);
        FreezeRotation(false);
    }

    private void RespondToRotateInput()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            RotateSquid(horizontalInput);
        }
    }

    private void RotateSquid(float rotationThisFrame)
    {
        FreezeRotation(true);
        transform.Rotate(Vector3.back * rotationThisFrame);
        FreezeRotation(false);
    }

    private void FreezeRotation(bool isFrozen)
    {
        if (isFrozen)
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        else
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.None;
        }    
    }

}
