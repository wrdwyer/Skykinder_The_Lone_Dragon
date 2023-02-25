using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blobcreate.Universal;
using Blobcreate.ProjectileToolkit;

namespace Blobcreate.ProjectileToolkit.Demo
{
public class ProjectiondistanceOrEnd : MonoBehaviour
{
   [SerializeField] TrajectoryPredictor tp;
   Vector3 launchPosition;
   Vector3 launchVelocity;
    float distanceOrEnd;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Call Render to update the positions of the line.
        tp.Render(launchPosition, launchVelocity, distanceOrEnd);
    }
}
}