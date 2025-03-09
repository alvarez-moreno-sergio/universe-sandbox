using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float smoothTime = 1f;
    public Transform planet;
    Rigidbody rb;
    Vector3 moveAmount;
    Vector3 rotation;
    Vector3 smoothMoveVelocity;
    Vector3 movementDirection = Vector3.zero;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movementDirection = Vector3.forward;
        Vector3 targetMoveAmount = movementDirection * verticalInput * speed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, smoothTime);

        rotation = Vector3.up * rotationSpeed * horizontalInput;
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        transform.Rotate(rotation);
    }
    float AdaptAngle(float angle, float limit = 180f){
        int sign = 1; // positive
        if (Math.Abs(angle) > limit){
            if (angle > limit){
            sign = -1;
            }
            else if (angle < -limit){
                sign = 1;
            }
            angle += limit * sign;
            angle = AdaptAngle(angle, limit);
        }
        return angle;
    }
}
