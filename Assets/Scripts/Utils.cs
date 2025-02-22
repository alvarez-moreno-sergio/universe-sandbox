using System;
using UnityEngine;

public static class Utils
{
    public static double Truncate(double value, int decimalPlaces){
        double decimalShift = Math.Pow(10, decimalPlaces);
        return Math.Floor(value * decimalShift) / decimalShift;
    }
}
