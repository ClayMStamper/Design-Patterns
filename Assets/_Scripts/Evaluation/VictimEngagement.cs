using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct engagement
{
    public float start;
    public float end;
}

public class VictimEngagement : MonoBehaviour
{
    List<engagement> engagements;
    engagement currentEngagement = new engagement();
    Victim victim;
    
	// Use this for initialization
	void Start () {
        victim = transform.GetComponent<Victim>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            currentEngagement.start = Time.time;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentEngagement.end = Time.time;
            engagements.Add(currentEngagement);
        }
    }
}
