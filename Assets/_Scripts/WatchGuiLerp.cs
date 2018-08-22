using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchGuiLerp : MonoBehaviour {

    [SerializeField]
    Transform target;
    [SerializeField] [Range(0, 1)]
    public float smoothSpeed = 0.125f;
    [SerializeField]
    public Vector3 offset;

    void FixedUpdate()
    {
        UpdatePos();
    }

    [ContextMenu("Set Position")]
    void UpdatePos()
    {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

        transform.position = smoothedPosition;

    }

}
