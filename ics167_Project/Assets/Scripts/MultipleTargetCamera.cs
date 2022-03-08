using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Mindy Jun

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    //This is a list of what the camera should be following
    public List<Transform> targets;
    
    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 0f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;

    void Start() 
    {
        cam = GetComponent<Camera>();

    }
    
    //The camera should move after everything else has moved, hence LateUpdate not Update.
    //Controlls zooming by editing field of view
    void LateUpdate()
    {
        //This if statement is to prevent an error if there are no targets.
        if (targets.Count == 0) 
        {
            return;
        }

        Move();
        Zoom();
    }

    //Lerp() interpolates between two numbers depending on the third value
    //this doesn't work :( bc projection is in orthographic
    void Zoom() 
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        //cam.fieldOfView = Mathf.SmoothDamp()*
        cam.orthographicSize = newZoom;
    }

    //Instead of having the camera's position be the centerpoint, there is an offset to account for zoom.
    void Move() 
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;
        Vector3 rawPosition = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

        //transform.position = new Vector3(rawPosition.x, rawPosition.y, -1);
        transform.position = new Vector3(rawPosition.x, rawPosition.y, rawPosition.z);
    }

    float GetGreatestDistance() 
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
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
