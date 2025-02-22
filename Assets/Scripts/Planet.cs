using UnityEngine;

public class Planet : MonoBehaviour
{
    public double mass;
    public double density;
    public Body body;
    public GravityNode gravityNode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = new Body(mass, density);
        gravityNode = GetComponentInChildren<GravityNode>();

        double surfaceRadius = UniverseConstants.CalculateRadius(body.mass, body.density);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
