using UnityEngine;

public class Body
{
    public double mass;
    public double radius;
    public double density;

    public Body(double mass, double density){
        this.mass = mass;
        this.density = density;
        this.radius = UniverseConstants.CalculateBodyRadius(mass, density);
    }
}
