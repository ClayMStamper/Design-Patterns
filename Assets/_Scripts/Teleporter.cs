using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //pos to teleport to
    [SerializeField]
    private Transform marker;
    [SerializeField]
    OVRScreenFade fade;

    public GameObject teleportLocation;

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

        IEnumerator e = fade.Fade(0, 1);
        while (e.MoveNext())
            yield return e.Current;

        player.position = marker.position;

        e = fade.Fade(1, 0);
        while (e.MoveNext())
            yield return e.Current;

        Debug.Log("Finished fade");

        yield return null;

    }

}
