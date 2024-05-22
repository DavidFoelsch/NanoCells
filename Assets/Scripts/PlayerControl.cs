using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour 
{
    public float speed;
    public Rigidbody2D rigidBody2D;

    private Vector2 moveDirection;


    [SerializeField] private InputActionReference moveActionToUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveActionToUse.action.ReadValue<Vector2>();

        //transform.Translate(moveDirection * speed * Time.deltaTime);
        rigidBody2D.AddForce(moveDirection * speed);
    }
}
