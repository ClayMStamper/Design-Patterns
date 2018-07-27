using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Tagger : MonoBehaviour
{
    public class Callback : UnityEvent<Ray, RaycastHit> { }
    public Transform leftHandAnchor = null;
    public Transform rightHandAnchor = null;
    public Transform centerEyeAnchor = null;
    public LineRenderer lineRenderer = null;
    public float maxRayDistance = 500.0f;
    public LayerMask excludeLayers;
    public Tagger.Callback raycastHitCallback;
    public Color tagColor;
    public ConditionTag playerTagColor;

    void Awake()
    {
        if (leftHandAnchor == null)
        {
            Debug.LogWarning("Assign LeftHandAnchor in the inspector!");
            GameObject left = GameObject.Find("LeftHandAnchor");
            if (left != null)
            {
                leftHandAnchor = left.transform;
            }
        }
        if (rightHandAnchor == null)
        {
            Debug.LogWarning("Assign RightHandAnchor in the inspector!");
            GameObject right = GameObject.Find("RightHandAnchor");
            if (right != null)
            {
                rightHandAnchor = right.transform;
            }
        }
        if (centerEyeAnchor == null)
        {
            Debug.LogWarning("Assign CenterEyeAnchor in the inspector!");
            GameObject center = GameObject.Find("CenterEyeAnchor");
            if (center != null)
            {
                centerEyeAnchor = center.transform;
            }
        }
        if (lineRenderer == null)
        {
            Debug.LogWarning("Assign a line renderer in the inspector!");
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            lineRenderer.receiveShadows = false;
            lineRenderer.widthMultiplier = 0.02f;
        }
    }

    Transform Pointer()
    {
       
        return rightHandAnchor;
        
    }

    void Update()
    {
        Transform pointer = Pointer();
        if (pointer == null)
        {
            return;
        }

        Ray laserPointer = new Ray(pointer.position, pointer.forward);

        if (!OVRInput.Get(OVRInput.RawNearTouch.RIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.RHandTrigger) == true)
        {
            lineRenderer.enabled = true;
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, laserPointer.origin);
                lineRenderer.SetPosition(1, laserPointer.origin + laserPointer.direction * maxRayDistance);

            }
        } 
        
        else
            lineRenderer.enabled = false;


        /*if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, laserPointer.origin);
            lineRenderer.SetPosition(1, laserPointer.origin + laserPointer.direction * maxRayDistance);
        }*/


        RaycastHit hit;
        if (Physics.Raycast(laserPointer, out hit, maxRayDistance))
        {
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(1, hit.point);
            }

            if (raycastHitCallback != null)
            {
                raycastHitCallback.Invoke(laserPointer, hit);
            }
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                if( hit.collider.CompareTag("victim"))
                {
                    Debug.Log("tag!!!!");
                    //hit.transform.GetComponent<Taggable>().Tag(tagColor);
                    hit.transform.GetComponent<Victim>().SetUserTag(playerTagColor);
                }
            }
        }
        
    }

    /* Function: OnTriggerEnter
     * Type: void
     * Recieves: Collider other
     * returns: N/A
     *
     * Objective - To determine which UI canvas is active by interacting with the collider on a body part
     * 
     * ADD: Timed delay so selecting part connected to the bone is smoother
     */

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Button"))
        {

        if (!OVRInput.Get(OVRInput.RawNearTouch.RIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.RHandTrigger) == true)
        {
            tagColor = other.GetComponent<Renderer>().material.color;
            lineRenderer.material.color = tagColor;
            Debug.Log(other.name + "-Touched");

                if (other.GetComponent<Renderer>().material.color == Color.red)
                    playerTagColor = ConditionTag.Red;
                else if (other.GetComponent<Renderer>().material.color == Color.yellow || other.transform.name == "Yellow") 
                    playerTagColor = ConditionTag.Yellow;
                else if (other.GetComponent<Renderer>().material.color == Color.green)
                    playerTagColor = ConditionTag.Green;
                else if (other.GetComponent<Renderer>().material.color == Color.black)
                    playerTagColor = ConditionTag.Black;
                else
                    playerTagColor = ConditionTag.Untagged;

        }

        else if (!OVRInput.Get(OVRInput.RawNearTouch.LIndexTrigger) == true && OVRInput.Get(OVRInput.RawButton.LHandTrigger) == true)
        {
            tagColor = other.GetComponent<Renderer>().material.color;
            lineRenderer.startColor= tagColor;
            lineRenderer.endColor = tagColor;
        }
    }

        //refactor
        else if(other.CompareTag("Head") || other.CompareTag("Torso") || other.CompareTag("RightArm") || other.CompareTag("LeftArm") || other.CompareTag("RightHand") ||
                other.CompareTag("LeftHand") || other.CompareTag("RightLeg") || other.CompareTag("LeftLeg") || other.CompareTag("RightFoot") || other.CompareTag("LeftFoot"))
        {
            Debug.Log("This is the Collider that you hit: " + other.name);
            Debug.Log("This is the child(0)" + other.transform.GetChild(0).name);

            if (!other.transform.GetChild(0).gameObject.activeSelf)
                other.transform.GetChild(0).gameObject.SetActive(true);
            else
                other.transform.GetChild(0).gameObject.SetActive(false);
                
                switch(other.tag) // Determines the body part selected by player
                {
                    case "Head": //Head
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.Head);
                        break;

                    case "Torso": //Torso
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.Torso);
                        break;

                    case "RightArm": //RightArm
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.R_Arm);
                        break;

                    case "LeftArm": //LeftArm
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.L_Arm);
                        break;

                    case "RightHand": //RightHand
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.R_Hand);
                        break;

                    case "LeftHand": //LeftHand
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.L_Hand);
                        break;

                    case "RightLeg": //RightLeg
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.R_Leg);
                        break;

                    case "LeftLeg": //LeftLeg
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.L_Leg);
                        break;

                    case "RightFoot": //RightFoot
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.R_Foot);
                        break;

                    case "LeftFoot": //LeftFoot
                        other.transform.GetChild(0).GetComponent<InjuryUIHandler>().SetSelectedPart(BodyParts.L_Foot);
                        break;

                    default:
                    other.transform.GetChild(0).gameObject.SetActive(false);
                        break;
                }
        }


    }
}
