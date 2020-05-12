using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 startVelocity;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPosition();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
       if(Input.GetMouseButtonDown(0))
       {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = startVelocity;
       }
    }

    private void LockBallToPosition()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);

        // start ball on paddle
        transform.position = paddlePos + paddleToBallVector;
    }
}
