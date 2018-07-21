using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Injury 
{
    private float bloodLossRate;

    public Burn() 
    {
        SetBloodLossRate(0.0f);
    }

    public Burn(float blr) 
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

    /*
     * Body Temperature drops sharply the more severe the burn is.
     * Different levels of burns: first, second and third degree.
     * 
     * Directly affects blood volume, body temperature, and respratory rate 
     * It can also interfere with joint movability depending on the location of the burn.
     * 
     * https://www.mayoclinic.org/diseases-conditions/burns/symptoms-causes/syc-20370539
     */


}