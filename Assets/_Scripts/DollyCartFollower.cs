using UnityEngine;
using Cinemachine;
using MalbersAnimations;

public class DollyCartFollower : MonoBehaviour
{
    public Transform target;

    //public MalbersAnimations.Scriptables.TransformVar target;
    public CinemachineDollyCart dollyCart;
    public CinemachineSmoothPath dollyTrack;

    public int startPoint;
    public int searchRadius;
    public int stepsPerSegment;
    public float closestPositionOnTrack;

    private void Update()
    {
        if (target != null && dollyCart != null && dollyTrack != null)
        {
            closestPositionOnTrack = dollyTrack.FindClosestPoint(target.position,startPoint,searchRadius,stepsPerSegment);
            dollyCart.m_Position = closestPositionOnTrack;
        }
    }
}
