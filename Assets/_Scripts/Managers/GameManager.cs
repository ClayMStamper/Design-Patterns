/*
 * 
 * 
 * 
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] victims;

    public Sprite greenCheck,
                  redX;

    Victim victimScript; // variable that references the victim script 

    public Sprite[] Head, // Arrays that hold the X-Ray Sprites for the Injury UI.
                    Neck,
                    Torso,
                    L_Arm,
                    R_Arm,
                    Abdomen,
                    Pelvis,
                    L_Leg,
                    R_Leg,
                    Spine,
                    L_Hand,
                    R_Hand,
                    L_Foot,
                    R_Foot;

    // Use this for initialization
    void Start ()
    {
        victimScript = GetComponent<Victim>();

        victims = GameObject.FindGameObjectsWithTag("victim");

        GetSprites(); 
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Return))
            CheckTagResults();
    }

    /* Function: CheckForVictimTestingComponents
     * Type: void
     * Receives: nothing
     * Returns: N/A
     * 
     * Objective - This function will check for the necessary components for evaluation in each GameObject tagged 'victim',
     *             if it is missing the component, this function will add it to the gameObject.
    */

    void CheckForTestingComponents()
    {
        foreach(GameObject vic in victims)
        {
            if(!vic.GetComponent<VictimTestEvaluation>())
            {
                vic.AddComponent<VictimTestEvaluation>();
            }
        }
    }

    /* Function: CheckTagResults()
     * Type: void
     * Receives: nothing
     * Returns: N/A
     * 
     * Objective - This function will check to see if the player tagged the victim properly,
     *             if they did then the function will populate the victim's Overhead UI with a GreenCheck
     *             else it will populate the victim's UI with a RedX.
     */

    void CheckTagResults()
    {
        foreach(GameObject vic in victims)
        {
            if (vic.GetComponent<VictimTestEvaluation>().EvaluateVictimTriage())
                vic.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = greenCheck;
            else
                vic.transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = redX;
        }
    }

    /* Function: CheckTagResults()
     * Type: public Sprite[] GetArray
     * Receives: BodyParts bp
     * Returns: A body part or null
     * 
     * Objective - Determines the body part sprite array that needs to be returned and shown on the UI.
     */

    public Sprite[] GetArray(BodyParts bp)
    {
        switch (bp)
        {
            case BodyParts.Head:
                return Head;

            case BodyParts.Neck:
                return Neck;

            case BodyParts.Torso:
                return Torso;

            case BodyParts.L_Arm:
                return L_Arm;

            case BodyParts.R_Arm:
                return R_Arm;

            case BodyParts.Abdomen:
                return Abdomen;

            case BodyParts.Pelvis:
                return Pelvis;

            case BodyParts.L_Leg:
                return L_Leg;

            case BodyParts.R_Leg:
                return R_Leg;

            case BodyParts.Spine:
                return Spine;

            case BodyParts.L_Hand:
                return L_Hand;

            case BodyParts.R_Hand:
                return R_Hand;

            case BodyParts.L_Foot:
                return L_Foot;

            case BodyParts.R_Foot:
                return R_Foot;

            default:
                return null;
        }
    }

    /* Function: GetSprites()
     * Type: public void
     * Receives: N/A
     * Returns: N/A
     * 
     * Objective - Fills arrays with the necessary sprites for each body part.
     */

    public void GetSprites()
    {
        //Rename these in the Resources/XraySprites directory. Make names like: brokenArm0, brokenArm1..(good -> bad)

        Head = Resources.LoadAll<Sprite>("XraySprites/EthanHead");
        Torso = Resources.LoadAll<Sprite>("XraySprites/EthanTorso");
        L_Arm = Resources.LoadAll<Sprite>("XraySprites/EthanArm/LeftArm");
        R_Arm = Resources.LoadAll<Sprite>("XraySprites/EthanArm/RightArm");
        L_Leg = Resources.LoadAll<Sprite>("XraySprites/EthanLegs/LeftLeg");
        R_Leg = Resources.LoadAll<Sprite>("XraySprites/EthanLegs/RightLeg");
        L_Hand = Resources.LoadAll<Sprite>("XraySprites/EthanHand/LeftHand");
        R_Hand = Resources.LoadAll<Sprite>("XraySprites/EthanHand/RightHand");
        L_Foot = Resources.LoadAll<Sprite>("XraySprites/EthanFoot/LeftFoot");
        R_Foot = Resources.LoadAll<Sprite>("XraySprites/EthanFoot/RightFoot");
    }
}
