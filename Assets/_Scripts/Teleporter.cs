using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 offsetFromCollider;

    public GameObject teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
           other.transform.SetPositionAndRotation(teleportLocation.transform.position + offsetFromCollider, Quaternion.LookRotation(teleportLocation.transform.forward));
    }

}
