using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLerp : MonoBehaviour
{
    public Vector3 heightOffset; 
    public Vector3 targetLocation;
    public Vector3 openStartLocation;
    public Vector3 closeStartLocation;

    public Quaternion startRotation;

    public float speed = 1.0f;
    public float duration = 1.0f;

    public bool isMoving,
                isGrabbed;

    float startTime, totalDistance;

    private void Start()
    {
        isGrabbed = false;
        isMoving = false;
        startRotation = this.transform.rotation;
        // startTime = Time.time;
       // targetLocation = this.transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            SetLerpVariables();
        }

        closeStartLocation = this.transform.position;

    }

    private void OnEnable()
    {
        /*if (!isGrabbed && isMoving)
            MedicalItemLerper();*/

      //MedicalItemEventManager.GetInstance().
        
    }

    private void OnDisable()
    {
        this.transform.position = closeStartLocation;
        //this.transform.position += closeStartLocation;
        this.transform.rotation = startRotation;
        isMoving = false;
    }

    private void SetLerpVariables()
    {
        float currentDuration = (Time.time - startTime) * speed;
        float journeyFraction = currentDuration / totalDistance;
        this.transform.position = Vector3.Lerp(openStartLocation, targetLocation, journeyFraction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            isGrabbed = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            isGrabbed = false;
    }

    private void MedicalItemLerper()
    {
        startTime = Time.time;


        openStartLocation = this.transform.position;
        //closeStartLocation = this.transform.position;
        targetLocation = this.transform.position;

        targetLocation = openStartLocation + heightOffset;
        totalDistance = Vector3.Distance(openStartLocation, targetLocation);

        this.transform.position = Vector3.Lerp(openStartLocation, targetLocation, 1.0f);

        if (this.transform.position != targetLocation)
            isMoving = true;
        else
            isMoving = false;
    }


}
