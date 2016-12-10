using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour {
    public float acceleration = 1;
    public float maxSpeed = 1;
    public float rotationSpeed = 1;
    private bool isMoving = false;
    private float currentSpeed = 0;
    private float currentRotation = 0;
    private float targetRotation = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float delta = Time.deltaTime;
        updateRotation(delta);
        updateSpeed(delta);
        updateSegments(delta);
	}

    private void updateRotation(float delta)
    {
        float difference = Mathf.DeltaAngle(currentRotation, targetRotation);
        float maxChange = delta * rotationSpeed;
        if (Math.Abs(difference) < maxChange)
        {
            currentRotation = targetRotation;
        } else if (difference < 0)
        {
            currentRotation -= maxChange;
        } else if (difference > 0)
        {
            currentRotation += maxChange;
        }
    }

    private void updateSpeed(float delta)
    {
        if (isMoving)
        {
            currentSpeed += acceleration * delta;
        } else
        {
            currentSpeed -= acceleration * delta;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void updateSegments(float delta)
    {
        Transform head = null;
        foreach (Transform child in transform)
        {
            if (head == null)
                head = child;

        }
    }

    public void turnTowards(float target)
    {
        targetRotation = target;
    }
    public void move()
    {
        isMoving = true;
    }
    public void stop()
    {
        isMoving = false;
    }
}
