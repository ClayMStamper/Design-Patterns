using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class VictimTestEvaluation : MonoBehaviour
{
    //This struct holds a start and end time to an engagement in order to see how long the engagement took
    public struct engagement
    {
        public float start;
        public float end;
    }

    // reffrence to victim
    Victim victim;

    // Determines if the triage was correct 
    bool triageCorrect;

    // Holds all of the engagements the player has with this victim 
    List<engagement> engagements;
    engagement currentEngagement = new engagement();

    //+ add list of intervention attempts

    // Use this for initialization
    void Start()
    {
        victim = GetComponent<Victim>();
    }

    public bool EvaluateVictimTriage()
    {
        triageCorrect = victim.GetUserTag() == victim.GetVictimTag();
        return triageCorrect ;
    }
    public int NumberOfEngagements()
    {
        return engagements.Count;
    }

    //returns total time player spent with victim
    public float TimeOnTask()
    {
        float timeOnTask = 0;
        for(int i=0;i<engagements.Count;i++)
        {
            timeOnTask= (engagements[i].end-engagements[i].start)+timeOnTask;
        }
        return timeOnTask;
    }

    public float AverageEngagmentTime()
    {
        float average = 0;
        for (int i = 0; i < engagements.Count; i++)
        {
           average = (engagements[i].end - engagements[i].start) + average;
        }
        return average/engagements.Count;
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
