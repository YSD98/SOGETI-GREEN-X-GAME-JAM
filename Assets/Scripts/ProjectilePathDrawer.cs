using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Draws the path of the projectile 
/// </summary>
public class ProjectilePathDrawer : MonoBehaviour
{
    public LayerMask colliadableLayers;

    public int numberOfPoints = 50;
    public float timeBetweenPoints = 0.1f; 


    PlayerInteractivity playerInteraction;
    LineRenderer pathRenderer;


    private void Awake()
    {
        playerInteraction = GetComponentInParent<PlayerInteractivity>();
        pathRenderer = GetComponentInParent<LineRenderer>();
    }

    private void Update()
    {
        DrawPath();
    }

    /// <summary>
    /// draws the path of the projectile
    /// </summary>
    private void DrawPath()
    {
        pathRenderer.positionCount = numberOfPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = playerInteraction.shotPoint.position;
        Vector3 startingVelocity = playerInteraction.shotPoint.forward * playerInteraction.throwPower;

        for (float t = 0; t < numberOfPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y * t * t * 0.5f;
            points.Add(newPoint);

            /*if(Physics.OverlapSphere(newPoint,2,ColliadableLayers).Length > 0)
            {
                pathRenderer.positionCount = points.Count;
                break;
            }*/
        }

        pathRenderer.SetPositions(points.ToArray());
    }
}
