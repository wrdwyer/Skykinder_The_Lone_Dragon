using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blobcreate.ProjectileToolkit;

public class TargetObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody myRigid;
    [SerializeField] private TrajectoryPredictor tp;

    [SerializeField] private float distanceOrEnd = 10f;
    [SerializeField] private Transform endPoint;
    [SerializeField] Vector3 velocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tp.Render(transform.position, velocity, distanceOrEnd);
        //tp.Render(myRigid.transform.position, myRigid.velocity, distanceOrEnd);
    }
}
