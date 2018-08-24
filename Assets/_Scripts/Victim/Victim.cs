/* Class: Victim
 * Inherits: Monobehavior
 * Uses: System.Collections, System.Collections.Generic, UnityEngine
 * 
 * Created: 6/12/2018
 * Last Modified: 6/22/2018
 * 
 * Objective
 * ----------------------
 * 
 *      This Class is the parent class for all of the "victims" in the Mass Casualty Incident.
 *  The "Victim" class will be attatched to the GameObject that contains all of the NPC's body
 *  parts as children and will have references to the children through an ArrayList. This class 
 *  
 *  
 *  THE BELOW IS FOR WORKING PURPOSES -- NOT ACTUAL DOCUMENTATION (Just a "helpful guide")
 *  
 *  
 *  This class will also contain the following variables and methods(functions):
 *  
 *  private:
 *          const float MAX_HEALTH  -- the maximum amount of health a Victim can have
 *          const int NUM_OF_BODYPARTS -- the maximum number of body parts a Victim has
 *          const float AVG_TOTAL_BLOOD -- Average amount of blood in an Adult (4.7 liters src="https://hypertextbook.com/facts/1998/LanNaLee.shtml")
 *  
 *          bool isMoving -- will detect if the Victim is able to move
 *          bool isResponding -- will detect if the Victim is able to respond to the player when called 
 *          
 *          float victimHealth -- used to keep track of the Victim's health
 *          float  victimWeight -- the victim's weight (measured in lbs), used in estimating Blood Volume. ( If you want to convers, 1lb = 2.2kg (roughly))
 *          float totalBloodLossRate -- the rate at which the Victim is losing blood
 *          float respRate -- the rate at which the Victim is respirating
 *          float pulseTime -- the rate of the Victim's Pulse
 *          float capillaryRefilltime -- rate at which the fingers' color return to normal after pinching
 *          float totalBloodVolume -- total volume of Blood in the Victim
 *          float currentBloodVolume -- keeps track of the current Blood Volume
 *          
 *          
 *          **More to be added as needed**
 *          
 *          
 *  public:                                 
 *          
 *          float CalcTotalBLR() -- this will calculate(based on how we decide to do it) the blood loss rate
 *                                  based on the rate of blood loss from each of the body parts and return
 *                                  the value (use the setter to set the value).
 *                                  
 *          float CalcRespRate() -- Calculates the rate of Respiration (based on lung damage) https://www.health.harvard.edu/diseases-and-conditions/pneumothorax -- https://my.clevelandclinic.org/health/articles/10881-vital-signs-- https://www.blood.gov.au/pubs/pbm/module1/background/3.3.html
 *          
 *          float CalcPulseTime() -- Calculates the pulse time(Normal Pulse rate 60-100 beats per minute, when blood loss >= 15%, pulse increases when BL >=40% death/close to death)
 *                                   src="http://www.cvphysiology.com/Blood%20Pressure/BP031"
 *          
 *          float CalcCapillaryRefillTime() -- Calculates the CRT (Normal time is < 2 seconds src=" https://medlineplus.gov/ency/article/003394.htm")
 *                                  
 *          float CalcBloodVolume() -- Calculates how much blood is currently in the Victim (BVolume = weight * Avg.BloodVolume , src="https://reference.medscape.com/calculator/estimated-blood-volume")
 *         
 *          float CalcVictimHealth() -- Calculates the victims health using the current status of their vitals
 *          
 *           ** Getters & Setters for the private variables as needed **
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Triage tag enums
public enum ConditionTag { Red, Yellow, Green, Black, Grey, Untagged };

public class Victim : MonoBehaviour
{

    private Animator anim; //used to change the AnimController's parameters.

    //The variables are "public" for testing purposes -- turn to "private" when done.
    public const int MAX_HEALTH = 100;
    public const int NUM_OF_BODYPARTS = 14;
    public const float AVG_TOTAL_BLOOD = 75.0f;
    private const string FCOLOR = "Color_9A8DB259";
    public GameManager gameManager;
    private Component[] renderers;

    public bool isMoving,
                isResponding,
                isDead,
                canFollowSimpleComands,
                hasRadialPulse,
                isConscious,
                canStand;

    public string victimName = "Victim";
   
    public float victimWeight,
                 totalBloodLossRate,
                 respRate,
                 pulseTime,
                 capillaryRefillTime,
                 totalBloodVolume,
                 currentBloodVolume,
                 timer = 0, //Used for making our checks/updates in Update() frame independent -- will ensure this check happens at the same rate no matter what hardware is used.
                 timeout,
                 currentBloodPercentage = 1,
                 bodytemp;
    public VictimInjruyDisplay display;

    public ConditionTag victimTag = ConditionTag.Untagged,
                        userTag = ConditionTag.Untagged;


    //These variables are intentionally "public"
    public BodyPart[] bodyParts = new BodyPart[NUM_OF_BODYPARTS];
    public List<BodyPart> injuredBodyParts = new List<BodyPart>();

    // Use this for initialization
    void Start() 
    {
        //Initialzie anim
        anim = this.GetComponent<Animator>();

        //gameManager = FindObjectsOfType<GameManager>()[0];
        //initialize body
        bodyParts[0] = new BodyPart("Head", BodyParts.Head);
        bodyParts[1] = new BodyPart("Neck", BodyParts.Neck);
        bodyParts[2] = new BodyPart("Torso", BodyParts.Torso);
        bodyParts[3] = new BodyPart("LArm", BodyParts.L_Arm);
        bodyParts[4] = new BodyPart("RArm", BodyParts.R_Arm);
        bodyParts[5] = new BodyPart("Abdomen", BodyParts.Abdomen);
        bodyParts[6] = new BodyPart("Pelvis", BodyParts.Pelvis);
        bodyParts[7] = new BodyPart("LLeg", BodyParts.L_Leg);
        bodyParts[8] = new BodyPart("RLeg", BodyParts.R_Leg);
        bodyParts[9] = new BodyPart("Spine", BodyParts.Spine);
        bodyParts[10] = new BodyPart("RHand", BodyParts.R_Hand);
        bodyParts[11] = new BodyPart("LHand", BodyParts.L_Hand);
        bodyParts[12] = new BodyPart("RFoot", BodyParts.R_Foot);
        bodyParts[13] = new BodyPart("LFoot", BodyParts.L_Foot);

        if(this.tag == "victim") //NO LONGER built in runtime, will be built with editor
        {
            SetVictimName(this.gameObject.name);
            InitVictim(victimName, bodyParts);
        }

        SetTotalBloodLossRate(CalcTotalBLR());
        SetBloodVolume(CalcStartBloodVolume());
        SetCurrentBloodVolume(GetBloodVolume());
        CheckCondition();

        this.totalBloodVolume = GetBloodVolume();

        renderers = GetComponentsInChildren<Renderer>();

        this.InjuredBodyParts();
        Debug.Log(transform.name + ":" + injuredBodyParts.Count);
        display = GetComponent<VictimInjruyDisplay>();


        // Set body parts to ignore main collider

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeout)
        {
            //Put Code here if it involves checks that you want Frame INDEPENDENT
            SetCurrentBloodVolume(CalcCurrentBloodVolume());
            currentBloodPercentage = CurrentBloodVolumePercentage();
            SetCapllaryRefillTime(CalcCapillaryRefillTime());
            SetRespRate(CalcResperationRate());
            CheckRadialPulse();
            CheckResponsiveness();
           
            timer -= timeout;
        }
        display.VictimBleed(GetTotalBloodLossRate()*.0001f);
        CheckCondition();

        // Update every 5 frames

        if (Mathf.Floor(Time.deltaTime) % 19 == 0)
        {
        // Update values, then set anim flags to match values
            CalcResperationRate();
            
            CalcCanStand();
            CalcIsConscious();
            
            SetVictimBreathingRate(respRate);
            SetVictimCanStand(canStand);
            SetVictimIsConscious(isConscious);
            
        }

    }
    


    // Private functions // 

    /*
     * Updates the materials of each renderer to display a different color glow based on tag.
     * I HAD to make a second FCOLOR constant for the skin because Unity SRP doesnt do normal maps
     * AND Unity doesn't allow you to change the shader property codes from the randomly assigned value.
     * Really Unity??? Get it together.
     */
    private void UpdateMaterialGlow()
    {

        // Get children and check that they have renderers 
        foreach (Renderer r in renderers)
        {
            Material[] materials;
            materials = r.materials;

            //Move to different script - defining tag colors should be seperate from Victim
            foreach (Material mat in materials)
            {
                switch (GetUserTag())
                {
                    case ConditionTag.Red:
                        mat.SetColor(FCOLOR, new Color(1.0f, 0.0f, 0.0f, 1.0f));
                        break;

                    case ConditionTag.Yellow:
                        mat.SetColor(FCOLOR, new Color(1.0f, 1.0f, 0.0f, 1.0f));
                        break;

                    case ConditionTag.Green:
                        mat.SetColor(FCOLOR, new Color(0.0f, 1.0f, 0.0f, 1.0f));

                        break;

                    case ConditionTag.Grey:
                        mat.SetColor(FCOLOR, new Color(1.0f, 1.0f, 1.0f, 0.5f));
                        break;

                    case ConditionTag.Black:
                        mat.SetColor(FCOLOR, new Color(0.5f, 0.0f, 0.5f, 0.5f));
                        break;

                    case ConditionTag.Untagged:
                        mat.SetColor(FCOLOR, new Color(0.0f, 0.0f, 0.0f, 0.0f));
                        break;
                }

            }
        }

    }

    // Getters & Setters //
    
    public bool GetIsMoving()
    {
        return this.isMoving;
    }
    public void SetIsMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    public bool GetIsResponding()
    {
        return this.isResponding;
    }
    public void SetIsResponding(bool isResponding)
    {
        this.isResponding = isResponding;
    }

    public string GetVictimName()
    {
        return this.victimName;
    }
    public void SetVictimName(string newVictimName)
    {
        this.victimName = newVictimName;
    }

    public float GetTotalBloodVolume() 
    {
        return totalBloodVolume;
    }


    public float GetTotalBloodLossRate()
    {
        return this.totalBloodLossRate;
    }
    public void SetTotalBloodLossRate(float totalBloodLossRate)
    {
        this.totalBloodLossRate = totalBloodLossRate;
    }

    public float GetRespRate()
    {
        return this.respRate;
    }
    public void SetRespRate(float respRate)
    {
        this.respRate = respRate;
    }

    public float GetPulseTime()
    {
        return this.pulseTime;
    }
    public void SetPulseTime(float pulseTime)
    {
        this.pulseTime = pulseTime;
    }

    public float GetCapillaryRefillTime()
    {
        return this.capillaryRefillTime;
    }
    public void SetCapllaryRefillTime(float capillaryRefillTime)
    {
        this.capillaryRefillTime = capillaryRefillTime;
    }

    public float GetCurrentBloodVolume() 
    {
        return this.currentBloodVolume;
    }
    public void SetCurrentBloodVolume( float currentBloodVolume) 
    {
        this.currentBloodVolume = currentBloodVolume;
    }

    public void SetVictimTag(ConditionTag tag)
    {
        this.victimTag = tag;
    }
    public ConditionTag GetVictimTag()
    {
        return this.victimTag;
    }

    public void SetUserTag(ConditionTag tag)
    {
        this.userTag = tag;
        UpdateMaterialGlow();
    }
    public ConditionTag GetUserTag()
    {
        return this.userTag;
    }

    public float GetBloodVolume()
    {
        return this.currentBloodVolume;
    }
    public void SetBloodVolume(float bloodVolume)
    {
        this.currentBloodVolume = bloodVolume;
    }

    /* Function: SetVictimIsInjured()
     * Type: Void
     * Receives: Bool isInjured
     * Returnsd: N/A
     * 
     * Objective: Will set the status of the Animator anim's paramter isInjured 
     */

    void SetVictimIsInjured(bool isInjured)
    {
        anim.SetBool("isVictimInjured", isInjured);
    }


    /* Function: SetVictimCanStand()
     * Type: Void
     * Receives: Bool canStand
     * Returnsd: N/A
     * 
     * Objective: Will set the status of the Animator anim's paramter canStand 
     */

    void SetVictimCanStand(bool canStand)
    {
        anim.SetBool("canVictimStand", canStand);
    }

    /* Function: SetVictimCanStand()
    * Type: Void
    * Receives: Bool canStand
    * Returnsd: N/A
    * 
    * Objective: Will set the status of the Animator anim's paramter isConscious 
    */

    void SetVictimIsConscious(bool isConscious)
    {
        anim.SetBool("isVictimConscious", isConscious);
        anim.speed = 1;
    }

    /* Function: SetVictimBreathingRate()
    * Type: Void
    * Receives: Float rate
    * Returnsd: N/A
    * 
    * Objective: Will set the status of the Animator anim's paramter BreathingRate 
    */

    void SetVictimBreathingRate(float rate)
    {
        anim.SetFloat("BreathingRate", rate);
    }

    /*
        CalcTotalBLR() -- This will calculate (based on how we decide) the blood loss rate
                          based on the rate of blood loss from each of the body parts(via a getter in their script) and return
                          the value (use the setter to set the value).
    */
    float CalcTotalBLR()
    {
        float tempBLR = 0;
        
        for(int i = 0; i < NUM_OF_BODYPARTS; i++)
        {
            if(this.bodyParts[i] != null)
               tempBLR += this.bodyParts[i].GetBLR();
        }

        return tempBLR;
    }

    /*
        /*
            CalcRespRate() -- Calculates the rate of Respiration (based on lung damage AKA the Torso bodyPart) 
            https://www.health.harvard.edu/diseases-and-conditions/pneumothorax 
            https://my.clevelandclinic.org/health/articles/10881-vital-signs

        float CalcRespRate()
        {

        }
        /*
            CalcPulseTime -- Calculates the pulse time(Normal Pulse rate 60-100 beats per minute, when blood loss >= 15%, pulse increases when BL >=40% death/close to death) 
            src="http://www.cvphysiology.com/Blood%20Pressure/BP031"


        float CalcPulseTime()
        {

        }
*/

    // CalcStartBloodVolume -- Calculates how much blood is in the Victim at the start of the simulation.
    
    float CalcStartBloodVolume()
    {
        return this.victimWeight * AVG_TOTAL_BLOOD;
    }

    float CalcCurrentBloodVolume() 
    {
        return (GetCurrentBloodVolume() - GetTotalBloodLossRate());
    }

    float CurrentBloodVolumePercentage()
    {
        return (GetCurrentBloodVolume() / GetTotalBloodVolume());
    }

 //CalcCapillaryRefillTime -- Calculates the CRT (Normal time is < 2 seconds src=" https://medlineplus.gov/ency/article/003394.htm")
    float CalcCapillaryRefillTime()
    {
        if (currentBloodPercentage >= 0.85f)
            return 2; //capillary refill
        if (currentBloodPercentage < 0.85f && currentBloodPercentage >= 0.71f)
            return 3; 
        else if (currentBloodPercentage < 0.71f && currentBloodPercentage >= 0.61f)
            return 4;
        else if (currentBloodPercentage < 0.61f && currentBloodPercentage > 0.55f)
            return 5;
        else if (currentBloodPercentage <= 0.55f && currentBloodPercentage > 0.50f)
            return 5;
        else if (currentBloodPercentage <= 0.50f)
            return 7;
        else
            return 800;
    }

    float CalcResperationRate()
    {
        if (currentBloodPercentage >= 0.85f)
            return 14; //reserations per minute 
        if (currentBloodPercentage<0.85f && currentBloodPercentage >= 0.71f)
            return 20; //reserations per minute 
        else if (currentBloodPercentage < 0.71f && currentBloodPercentage >= 0.61f)
            return 30;
        else if (currentBloodPercentage < 0.61f && currentBloodPercentage > 0.55f)
            return 40;
        else if (currentBloodPercentage <= 0.55f && currentBloodPercentage > 0.50f)
            return 10;
        else if (currentBloodPercentage <= 0.50f)
            return 0;
        else
            return 800;
    }

    void CheckResponsiveness()
    {
        if (currentBloodPercentage >= 0.85f)
            canFollowSimpleComands = true;
        if (currentBloodPercentage < 0.85f && currentBloodPercentage >= 0.71f)
            canFollowSimpleComands = true;
        else if (currentBloodPercentage < 0.71f && currentBloodPercentage >= 0.61f)
            canFollowSimpleComands = false;
        else if (currentBloodPercentage < 0.61f && currentBloodPercentage > 0.55f)
            canFollowSimpleComands = false;
        else if (currentBloodPercentage <= 0.55f && currentBloodPercentage > 0.50f)
            canFollowSimpleComands = false;
        else if (currentBloodPercentage <= 0.50f)
            canFollowSimpleComands = false;
    }

    void CheckRadialPulse()
    {
        
        if (currentBloodPercentage >= 0.85f)
           hasRadialPulse = true;
        if (currentBloodPercentage < 0.85f && currentBloodPercentage >= 0.71f)
            hasRadialPulse = true;
        else if (currentBloodPercentage < 0.71f && currentBloodPercentage >= 0.61f)
            hasRadialPulse = false;
        else if (currentBloodPercentage < 0.61f && currentBloodPercentage > 0.55f)
            hasRadialPulse = false;
        else if (currentBloodPercentage <= 0.55f && currentBloodPercentage > 0.50f)
            hasRadialPulse = false;
        else if (currentBloodPercentage <= 0.50f)
            hasRadialPulse = false;
    }

    void CheckCondition()
    {
       if(this.isMoving)
        {
            SetVictimTag(ConditionTag.Green);
        }
       else
        {
            if(this.respRate==0)
            {
                SetVictimTag (ConditionTag.Black);
            }
            else if (this.respRate>= 30.0f)
            {
                SetVictimTag(ConditionTag.Red);
                SetVictimIsInjured(true);
            }
            else if (this.respRate<30.0f)
            {
                if(hasRadialPulse)
                {
                    if (canFollowSimpleComands)
                    {
                        SetVictimTag(ConditionTag.Yellow);
                    }
                    if(!canFollowSimpleComands)
                    {
                        SetVictimTag(ConditionTag.Red);
                    }
                }
                if (!hasRadialPulse)
                {
                    if (capillaryRefillTime < 2000) // <-- might need to change to fit the capillary refill time in CaclCapillaryRefilltime() (which uses a different number style)
                    {
                        if (canFollowSimpleComands)
                        {
                            SetVictimTag(ConditionTag.Yellow);
                        }
                        if (!canFollowSimpleComands)
                        {
                            SetVictimTag(ConditionTag.Red);
                        }
                    }

                    if (capillaryRefillTime >= 2000)
                    {
                        SetVictimTag(ConditionTag.Red);
                    }
                }
            }
        }
        
    }

    /* 
     * Function: CalcCanStand()
    * Type: Void
    * Receives: N/A
    * Returns: N/A
    * 
    * Objective: Will set canStand to true if injuries do 
    * not prevent victim from standing. Otherwise false.
    * */
    void CalcCanStand()
    {

        // First make sure he's not dead or unconscious
        if (this.isDead || !this.isConscious)
        {
            canStand = false;
        } else // Second check the ol' walkers for severe injury
        {
            canStand = true; // Assume good unless legs tell us otherwise

            foreach (BodyPart bp in bodyParts)
            {
                // body part is a walker and has a condition below usable min
                if (bp.GetIsPedal() && bp.GetCondition() < bp.GetUsableMin())
                {
                    canStand = false;
                }
            }
        }


    }

    /* 
     * Function: CalcIsConscious()
     * Type: Void
     * Receives: N/A
     * Returns: N/A
     * 
     * Objective: Will set isConscious to true if injuries do 
     * not prevent victim from being awake. Otherwise false.
     * */
    void CalcIsConscious()
    {
        if (this.isDead) // easy case, never awake if dead (we hope)
        {
            isConscious = false;
        }
        else
        {
            // FINISH THIS ONCE WE KNOW HOW TO DETERMINE CONSCIOUSNESS!
            isConscious = true;
        }

    }

    void InjuredBodyParts()
    {
        injuredBodyParts = new List<BodyPart>();
        for (int i = 0; i < bodyParts.Length; i++)
        {
            if (bodyParts[i].NumberOfInjuries()>0)
            {
                injuredBodyParts.Add(bodyParts[i]);
            }
        }


    }

    public bool NeedsIntervention()
    {
        for (int i = 0; i <bodyParts.Length; i++)
        {
            if (bodyParts[i].NeedsIntervention())
            {
                return true;
            }
        }
        return false;
    }


    ///MAKING THE BASIC BOIS!
    public void InitVictim(string name, BodyPart[] bodyParts) 
        {
        if (name == "BasicEthanGreen") 
        {  //Expected total BLR == 2.5
            foreach (BodyPart bp in bodyParts) 
            {
                bp.AddInjury(new Laceration(0.25f));
            }
        } 
        else if (name == "BasicEthanYellow") 
        {  //Expected total BLR == 25

            bodyParts[4].AddInjury(new Laceration(25));
            /*foreach (BodyPart bp in bodyParts)
            {
                bp.AddInjury(new Laceration(1.5f));
            }*/
        } 
        else if (name == "BasicEthanRed") 
        {  //Expected total BLR == 80
            bodyParts[0].AddInjury(new Laceration(10));
            bodyParts[0].AddInjury(new Laceration(15));

            bodyParts[4].AddInjury(new Laceration(30));
            bodyParts[4].AddInjury(new Laceration(25));
        }
    }

}
