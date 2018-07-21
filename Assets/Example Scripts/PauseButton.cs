using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class PauseButton : MonoBehaviour {
    public VideoPlayer movieTexture;
    public AudioSource audioSource;
    Material mat;
    Color clicked=Color.black;
    Color normal;
    // Use this for initialization
    void Start()
    {
        mat = transform.GetComponent<Renderer>().material;
        normal = mat.color;

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void VideoStop()
    {
        if (movieTexture.isPlaying)
        {
            movieTexture.Pause();
            audioSource.Pause();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("b_r_index3") || other.gameObject.name.Contains("RightHandAnchor"))
        {
            Debug.Log("Stop touch!");
            if (!OVRInput.Get(OVRInput.RawNearTouch.RIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.RHandTrigger) == true)
            {
                mat.color = clicked;
                VideoStop();
            }
        } else if (other.gameObject.name.Contains("b_l_index3") || other.gameObject.name.Contains("LeftHandAnchor"))
        {
            if (!OVRInput.Get(OVRInput.RawNearTouch.LIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.LHandTrigger) == true)
            {
                mat.color = clicked;
                VideoStop();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("b_r_index3") || other.gameObject.name.Contains("RightHandAnchor"))
        {
            if (!OVRInput.Get(OVRInput.RawNearTouch.RIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.RHandTrigger) == true)
            {
                mat.color = normal;
            }
        } else if (other.gameObject.name.Contains("b_l_index3") || other.gameObject.name.Contains("LeftHandAnchor"))
        {
            if (!OVRInput.Get(OVRInput.RawNearTouch.LIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.LHandTrigger) == true)
            {
                mat.color = normal;
            }
        }
    }
}
