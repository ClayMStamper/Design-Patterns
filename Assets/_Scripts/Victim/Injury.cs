/* Class: Injury.cs
*
* created 06/19/2018
* last modified 06/19/2018
* 
* Objective - This class will be the parent class for all injuries.
* 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injury 
{
    public string name;
    public bool causesBleeding;
    public bool effectsBodyTemperature;
    public bool causesConfusion;
    public bool condition;
    public bool requiresIntervention;
    public float bloodLossRate;

    public float GetBloodLossRate()
    {
        return this.bloodLossRate;
    }
    public void SetBloodLossRate(float bloodLossRate)
    {
        this.bloodLossRate = bloodLossRate;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
