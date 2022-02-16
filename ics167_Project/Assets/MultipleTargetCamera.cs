using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Mindy Jun

public class MultipleTargetCamera : MonoBehaviour
{
    //This is a list of what the camera should be following
    public List<Transform> targets;
    
    public Vector3 offset;
    
    //The camera should move after everything else has moved, hence LateUpdate not Update.
    //Instead of having the camera's position be the centerpoint, there is an offset to account for zoom.
    void LateUpdate()
    {
        //This if statement is to prevent an error if there are no targets.
        if (targets.Count == 0) 
        {
            return;
        }

        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;
    }

    //To follow multiple targets, the camera should be focused on the center of all the targets.
    //This returns a Vector3 with the center position using the Bounds class.
    Vector3 GetCenterPoint() 
    {
        //If there's only one target to follow, return that position
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        //The Bounds class that essentially creates a rectangle around all the objects it encapsulates.
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++) 
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
