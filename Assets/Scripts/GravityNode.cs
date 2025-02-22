using UnityEngine;

public class GravityNode : MonoBehaviour
{
    public Planet planet;
    void Start()
    {
        planet = GetComponentInParent<Planet>();
        RefreshGravityRadius();
    }

    public void RefreshGravityRadius(){
        double radius = UniverseConstants.FindNegligibleGravityDistance(planet.mass);
        GetComponent<SphereCollider>().radius = (float) radius;
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb == null) return;
    }
}
