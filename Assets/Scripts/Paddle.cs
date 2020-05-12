using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float clampOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseToUnitPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        float clampedPos = Mathf.Clamp(mouseToUnitPos, clampOffset, screenWidthInUnits - clampOffset);
        Vector2 paddlePos = new Vector2(clampedPos, this.transform.position.y);
        this.transform.position = paddlePos;
    }
}
