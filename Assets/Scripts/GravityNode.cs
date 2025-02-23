using UnityEngine;

public class GravityNode : MonoBehaviour
{
    public CelestialObject planet;
    void Start()
    {
        planet = GetComponentInParent<CelestialObject>();
        RefreshGravityRadius();
    }

    public void RefreshGravityRadius(){
        double radius = UniverseConstants.FindNegligibleGravityDistance(planet.mass);
        GetComponent<SphereCollider>().radius = (float) radius;
    }

    void OnTriggerStay(Collider other)
    {
        CelestialObject co = other.GetComponent<CelestialObject>();
        if (co == null) return;

        Debug.Log("object enter SOI");
        co.apply_gravitational_force(planet);
    }
}
