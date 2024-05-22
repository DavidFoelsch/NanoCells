using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleConstantVolume : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;

    public float wiggleFactor;
    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    // Start is called before the first frame update
    void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = transform.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            // targetPos the position of the last element plus distance between the last point and the curent point
            //Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            Vector3 targetPos = segmentPoses[i - 1] + (1.0f - wiggleFactor) * (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist + wiggleFactor * targetDir.right * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses);
        
    }
}
