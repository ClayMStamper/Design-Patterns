using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Function: Teleports the player in and out of the bus
 * Instances: Attached to "Teleporter" objects
 */

public class Teleporter : MonoBehaviour
{
    //pos to teleport to: attached to child
    [SerializeField]
    private Transform marker;

    //Fade script: attached to OVRCameraRig
    [SerializeField]
    OVRScreenFade fade;

    public GameObject teleportLocation;

    //draw light blue wire sphere on teleport target in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(marker.position, 0.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(FadeAndTeleport(other.transform));
    }


    IEnumerator FadeAndTeleport(Transform player)
    {

        Debug.Log("Starting fade");

        //start fade out
        IEnumerator e = fade.Fade(0, 1);
        while (e.MoveNext()) //wait for fade out
            yield return e.Current;

        //teleport
        player.position = marker.position;

        //start fade in
        e = fade.Fade(1, 0);
        while (e.MoveNext()) //wait
            yield return e.Current;

        Debug.Log("Finished fade");

    }

}
