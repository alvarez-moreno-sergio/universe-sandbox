using System.Linq.Expressions;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{
    public double mass;
    public double density;
    public Body body;
    public Rigidbody rb;
    public GravityNode gravityNode;

    public bool grounded = false;

    void Start()
    {
        body = new Body(mass, density);
        rb = GetComponent<Rigidbody>();
        if (rb != null) rb.mass = (float) mass;
        gravityNode = GetComponentInChildren<GravityNode>();
        transform.localScale = new Vector3((float) body.radius*2, (float) body.radius*2, (float) body.radius*2);
    }
    public void apply_gravitational_force(CelestialObject obj){
        if (rb == null) return;

        Vector3 direction = obj.transform.position - transform.position;
        float distance = direction.magnitude - (float) obj.body.radius;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit)){
            if (hit.collider != null) {
                Debug.DrawRay(transform.position, hit.point - transform.position, Color.red); // Draw the ray in the scene view
                double gravitationalForce = UniverseConstants.CalculateGravitationalForce(distance, body.mass, obj.body.mass);
                Vector3 force = ENV_VAR.FORCE_MULTIPLIER * (float) gravitationalForce * direction.normalized;

                rb.AddForce(force, ForceMode.Force);
                Debug.Log("applying gravitational force: " +  force);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
