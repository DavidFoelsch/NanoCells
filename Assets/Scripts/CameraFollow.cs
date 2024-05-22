using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool move = true;
    public GameObject targetObject;
    public float followSpeed;

    private Vector3 moveTo = Vector3.zero;
    private Transform targetTransform;
    private float cameraHeight;

    void Start()
    {
        targetTransform = targetObject.transform;
        cameraHeight = transform.position.z;
    }

    void FixedUpdate()
    {
        if (move)
        {
            moveTo = targetTransform.position;
            moveTo.z = cameraHeight;
            transform.position = Vector3.Slerp(transform.position, moveTo, followSpeed * Time.deltaTime);
        }
    }

}
