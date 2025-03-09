using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class GravityNode : MonoBehaviour
{
    public CelestialObject planet;
    public float gravityRadius;
    public float gravityApplicationInterval = 0.2f;
    public bool skipCoroutines = false;

    void Awake()
    {
        planet = GetComponent<CelestialObject>();
        RefreshGravityRadius();
    }

    public void RefreshGravityRadius()
    {
        double radius = UniverseConstants.FindNegligibleGravityRadius(planet.mass);
        gravityRadius = (float) radius;
    }

    void FixedUpdate()
    {
        ApplyGravity();
    }
    void ApplyGravity(){
        if (planet != null && planet.body != null){
                Collider[] colliders = Physics.OverlapSphere(transform.position, gravityRadius);
                for (int i = 1; i < colliders.Length; i++)
                {
                    CelestialObject co = colliders[i].GetComponent<CelestialObject>();
                    if (co != null){
                        Attract(co);
                    }
                }
            }
    }
    void Attract(CelestialObject co){
        Vector3 distance = co.transform.position - transform.position;
        float force = (float) UniverseConstants.CalculateGravitationalForce(distance.magnitude, planet.body.mass, co.body.mass);
        Vector3 direction = distance.normalized;
        Vector3 bodyUp = co.transform.up;

        co.transform.rotation = Quaternion.FromToRotation(bodyUp, direction) * co.transform.rotation;
        co.GetComponent<Rigidbody>().AddForce(direction * force);
        co.lastForceApplied = force;
        Debug.Log(force);
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
    private IEnumerator ApplyGravityAtIntervals()
    {
        while (true) // Continuously apply gravity every set interval
        {
            if (!skipCoroutines) ApplyGravity();
            yield return new WaitForSeconds(gravityApplicationInterval); // Wait before applying gravity again
        }
    }
}
