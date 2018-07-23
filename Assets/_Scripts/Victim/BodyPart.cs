/* Class: BodyPart
 * Inherits: MonoBehavior
 * Uses: System.Collections, System.Collections.Generic, UnityEngine
 * 
 * Created: 6/13/2018
 * Last Modified: 6/23/2018
 * 
 * Objective
 * -----------------------------
 *  This class is intended to be the parent class for all the bodyparts.
 *  This class will hold properties of each body part that will be initialized
 *  on the creation of the bodypart object.
 *  
 *             
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Preset body part enums
public enum BodyParts { Head, Neck, Torso, L_Arm, R_Arm, Abdomen, Pelvis, L_Leg, R_Leg, Spine, L_Hand, R_Hand, L_Foot, R_Foot, NULL };

public class BodyPart
{

    private float bloodLossRate;
    //float bloodLossMod; // modifies blood loss 1 = no change, <1 bleeds less, >1 bleeds more

    private string name;        // label for the body part

    private bool isLimb;        // can be considered a limb (arm, leg)
    private bool isNeural;      // effects neural state (brain, spine, neck) 
    private bool isVital;       // contains vital organs (abdomen, torso, head) 
    private bool isPedal;       // injuries to this part physically impede walking (feet, legs)

    private bool isBleeding;    // has cuts open wounds 
    private bool isBroken;      // has broken bones
    private bool isBurned;      // has burns
    private bool needsIntervention;

    private int injuryCounter = 0; // used to keep track of position in the injury list

    private float breakSeverity;// 0 (not broken) - 100 (obliterated)
    private float burnSeverity; // 0 (not burned) - 100 (extra crispy) 

    private float usableMin;    // minimum condition value for part to be considered "usable"
    private float condition;    // 0 (obliterated) - 100 (healthy)

    public BodyParts partType = BodyParts.NULL;

    private List<Injury> injuries = new List<Injury>(); // Will hold all the injuries attatched to the bodypart.

    public BodyPart(string name, BodyParts preset) 
    {
        this.name = name;

        // Set default condition values (no burns/breaks 100% cond)
        this.breakSeverity = 0.0f;
        this.burnSeverity = 0.0f;
        this.condition = 100;
        this.isBleeding = false;
        this.isBroken = false;
        this.isBurned = false;

        // assign type by preset
        switch (preset) 
        {

            case BodyParts.Head:
                isLimb = false;
                isNeural = true;
                isVital = true;
                isPedal = false;
                usableMin = 50;
                break;

            case BodyParts.Neck:
                isLimb = false;
                isNeural = true;
                isVital = true;
                isPedal = false;
                usableMin = 50;
                break;

            case BodyParts.L_Arm:
            case BodyParts.R_Arm:
                isLimb = true;
                isNeural = false;
                isVital = false;
                isPedal = false;
                usableMin = 50;
                break;

            case BodyParts.Torso:
                isLimb = false;
                isNeural = false;
                isVital = true;
                isPedal = false;
                usableMin = 50;
                break;

            case BodyParts.Abdomen:
                isLimb = false;
                isNeural = false;
                isVital = true;
                isPedal = false;
                usableMin = 50;
                break;

            case BodyParts.Pelvis:
                isLimb = false;
                isNeural = false;
                isVital = true;
                isPedal = true;
                usableMin = 50;
                break;

            case BodyParts.L_Leg:
            case BodyParts.R_Leg:
                isLimb = true;
                isNeural = false;
                isVital = false;
                isPedal = true;
                usableMin = 50;
                break;

            case BodyParts.Spine:
                isLimb = false;
                isNeural = true;
                isVital = true;
                isPedal = true;
                usableMin = 50;
                break;

            case BodyParts.L_Hand:
            case BodyParts.R_Hand:
                isLimb = true;
                isNeural = false;
                isVital = false;
                isPedal = false;
                usableMin = 50;
                break;

            case BodyParts.L_Foot:
            case BodyParts.R_Foot:
                isLimb = true;
                isNeural = false;
                isVital = false;
                isPedal = true;
                usableMin = 50;
                break;

            default:
                isLimb = false;
                isVital = false;
                isPedal = false;
                isNeural = false;
                usableMin = 0;
                break;

        }
    }

   /* Function: AddInjury()
    * Type: void
    * Receives: Injury i
    * returns: N/A
    * 
    * Objective: Adds an Injury object to the injuries List
    */
    public void AddInjury(Injury i) 
    {
        this.injuries.Add(i);
    }

    /* Function: RemoveInjury()
    *  Type: void
    *  Receives: Injury i
    *  Returns: N/A
    *  
    *  Objective: Removes an Injury object from injuries by instance.
    */
    public void RemoveInjury(Injury i) 
    {
        this.injuries.Remove(i);
    }

    /* Function: RemoveInjury
     * Type: void
     * Receives: int i
     * Returns: N/a
     * 
     * Objective: Removes an Injury object from injuries by index.
     */
    public void RemoveInjury(int i)
    {
        this.injuries.RemoveAt(i);
    }

    public void SetBLR(float bloodLossRate) 
    {
        this.bloodLossRate = bloodLossRate;
        this.needsIntervention = true;
    }

    /* Function: CalcBLR()
     * Type: float
     * Receives: List<Injury> injures (passed by ref), int injuryCounter
     * Returns: float tempBLR
     * 
     * Objective: Iterates through the Injury List "injuries" searching for each type of injury that generates blood loss
     *            and adds it to tempBLR. The sum is then returned.
     */

    public float CalcBLR(List<Injury> injuries, int injuryCounter) 
    { 
        float tempBLR = 0.0f;

        foreach (Injury inj in injuries) 
        {
            if (inj.GetType() == typeof(Laceration)) 
            {
                tempBLR += (inj as Laceration).GetBloodLossRate();
            }

        }

        return tempBLR;
    }

    //Getters & Setters 
    public float GetBLR() {
        SetBLR(CalcBLR(injuries, injuryCounter));
        return this.bloodLossRate;
    }

    public bool GetIsLimb()
    {
        return this.isLimb;
    }

    public bool GetIsNeural()
    {
        return this.isNeural;
    }

    public bool GetIsVital()
    {
        return this.isVital;
    }

    public bool GetIsPedal()
    {
        return this.isPedal;
    }

    public bool GetIsBleeding()
    {
        return this.isBleeding;
    }

    public bool GetIsBroken()
    {
        return this.isBroken;
    }

    public bool GetIsBurned()
    {
        return this.isBurned;
    }

    public float GetBreakSeverity()
    {
        return this.breakSeverity;
    }

    public void SetBreakSeverity(float breakSeverity)
    {
        this.breakSeverity = breakSeverity;
    }

    public float GetBurnSeverity()
    {
        return this.burnSeverity;
    }

    public void SetBurnSeverity(float burnSeverity)
    {
        this.burnSeverity = burnSeverity;
    }

    public float GetUsableMin()
    {
        return this.usableMin;
    }

    public float GetCondition()
    {
        return this.condition;
    }

    public void SetCondition(float condition)
    {
        this.condition = condition;
    }

    public int NumberOfInjuries()
    {
        return injuries.Count;
    }

    public bool NeedsIntervention()
    {
        
        for (int i =0;i<injuries.Count;i++)
        {
            if(injuries[i].requiresIntervention)
            {
                return true;
            }
        }

        return false;
    }

    public List<Injury> GetInjuries()
    {
        return injuries;
    }

    public List<Injury> GetInterveneableInjuries()
    {
        List<Injury> interveneableInjuries = new List<Injury>();
        for (int i = 0; i < injuries.Count; i++)
        {
            if (injuries[i].requiresIntervention)
            {
                interveneableInjuries.Add(injuries[i]);
            }
        }

        return interveneableInjuries;
    }

}