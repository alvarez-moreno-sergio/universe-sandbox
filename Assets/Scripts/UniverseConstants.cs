using System;
using UnityEngine;

public static class UniverseConstants
{
    public static float GRAVITATIONAL_CONSTANT = -9.8f;

    public static double CalculateGravitationalForce(double distance, double massA, double massB){
        double force = GRAVITATIONAL_CONSTANT * massA * massB / (distance * distance);
        force *= ENV_VAR.FORCE_MULTIPLIER;
        if (Math.Abs(force) < 0.1f) return 0; // Prevent micro-force jittering

        return Utils.Truncate(force, ENV_VAR.TRUNCATE_PHYSICS);
    }
    public static double FindNegligibleGravityRadius(double mass, double minForce = 1e-1){
        double radius = Math.Sqrt(Math.Abs(GRAVITATIONAL_CONSTANT) * mass / minForce);
        return Utils.Truncate(radius, ENV_VAR.TRUNCATE_PHYSICS);
    }
    public static Double CalculateBodyRadius(double mass, double density){
        double volume = mass / density;
        double radius = Math.Pow((3 * volume) / (4 * Math.PI), 1.0 / 3.0);
        return Utils.Truncate(radius, ENV_VAR.TRUNCATE_PHYSICS);
    }
}
