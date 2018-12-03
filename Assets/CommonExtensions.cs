//Script Purpose: To add custom extensions to the project

using UnityEngine;

public static class CommonExtensions
{

    public static bool TimeHasPassed(this float timeOfAction, float timeToPass)
    {
        if (timeOfAction + timeToPass < Time.time)
            return true;
        else
            return false;
    }

    public static Vector3 Modify(this Vector3 vector, xyz valToChange, float newVal)
    {
        if (valToChange == xyz.x)
            return new Vector3(newVal, vector.y, vector.z);
        if (valToChange == xyz.y)
            return new Vector3(vector.x, newVal, vector.z);
        if (valToChange == xyz.z)
            return new Vector3(vector.x, vector.y, newVal);
        else
        {
            return vector;
        }
    }

}

public enum xyz
{
    x, y, z
}