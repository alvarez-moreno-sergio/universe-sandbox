using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{
    public double mass;
    public double density;
    public Body body;
    public Rigidbody rb;
    public float lastForceApplied = 0f;

    void Start()
    {
        body = new Body(mass, density);
        rb = GetComponent<Rigidbody>();
        SetSize();
    }
    void SetSize(){
        if (rb != null) {
            rb.mass = (float)mass;
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        transform.localScale = new Vector3((float)body.radius * 2, (float)body.radius * 2, (float)body.radius * 2);
    }
}
