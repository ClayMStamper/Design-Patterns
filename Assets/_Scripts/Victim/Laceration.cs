using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laceration : Injury
{
    float bloodLossRate;

    public Laceration() 
    {
        SetBloodLossRate(0.0f);
    }

    public Laceration(float blr) 
    {
        SetBloodLossRate(blr);
    }

    public float GetBloodLossRate() 
    {
        return this.bloodLossRate;
    }

    public void SetBloodLossRate(float bloodLossRate) 
    {
        this.bloodLossRate = bloodLossRate;
    }
}