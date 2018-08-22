using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerRoll : MonoBehaviour {

    
    [SerializeField] [Tooltip ("How far the drawer can be pulled out. (in world space units)")]
    float maxPullDistance = 0.5f;

    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
       
        float pullDistance = Mathf.Abs(transform.position.z - startPos.z);

        if (pullDistance < startPos.z || pullDistance > maxPullDistance)
        {
            ClampPos();
        }

    }

    void ClampPos()
    {
        Vector3 newPos = transform.position; //store locally
        newPos.z = Mathf.Clamp(newPos.z, startPos.z, startPos.z + maxPullDistance); //clamp newPos
        transform.position = newPos; //set pos = newPos
    }

}
