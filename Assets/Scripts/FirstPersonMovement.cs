using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void OnPlayerMove(InputValue value) 
    { 
    
        Vector2 inputVector = value.Get<Vector2>();

        Debug.Log(message: $"{inputVector}");
        // move in XZ plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;

        Debug.Log(message: $"{direction}");


    }
}
