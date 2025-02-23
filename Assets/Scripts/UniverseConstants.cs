using System;
using UnityEngine;

public static class UniverseConstants
{
    public static double GRAVITATIONAL_CONSTANT = 0.00000000006674f;

    public static double CalculateGravitationalForce(double distance, double massA, double massB){
        double force = GRAVITATIONAL_CONSTANT * massA * massB / (distance * distance);
        return Utils.Truncate(force, ENV_VAR.TRUNCATE_PHYSICS);
    }
    public static double FindNegligibleGravityDistance(double mass, double minForce = 1e-5){
        double radius = Math.Sqrt(GRAVITATIONAL_CONSTANT * mass / minForce);
        return Utils.Truncate(radius, ENV_VAR.TRUNCATE_PHYSICS);
    }
    public static Double CalculateBodyRadius(double mass, double density){
        double volume = mass / density;
        double radius = Math.Pow((3 * volume) / (4 * Math.PI), 1.0 / 3.0);
        return Utils.Truncate(radius, ENV_VAR.TRUNCATE_PHYSICS);
    }
}
