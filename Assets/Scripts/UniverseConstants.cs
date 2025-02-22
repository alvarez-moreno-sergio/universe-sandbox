using System;
using UnityEngine;

public static class UniverseConstants
{
    public static double GRAVITATIONAL_CONSTANT = 0.00000000006674f;

    public static double CalculateGravitationalAcceleration(double massA, double massB, double r){
        return GRAVITATIONAL_CONSTANT * massA * massB / (r*r);
    }
    public static double FindNegligibleGravityDistance(double mass, double minForce = 1e-10){
        double radius = Math.Sqrt(GRAVITATIONAL_CONSTANT * mass / minForce);
        return Utils.Truncate(radius, 5);
    }
    public static Double CalculateRadius(double mass, double density){
        double volume = mass / density;
        return Math.Pow((3 * volume) / (4 * Math.PI), 1.0 / 3.0);
    }
}
