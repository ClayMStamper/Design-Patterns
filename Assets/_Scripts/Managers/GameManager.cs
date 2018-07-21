using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] victims;

    public Sprite greenCheck,
                  redX;

    Victim victimScript;

    public Sprite[] Head,
                    Neck,
                    Torso,
                    Arm,
                    Abdomen,
                    Pelvis,
                    Leg,
                    Spine,
                    Hand,
                    Foot;

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

            case BodyParts.Arm:
                return Arm;

            case BodyParts.Abdomen:
                return Abdomen;

            case BodyParts.Pelvis:
                return Pelvis;

            case BodyParts.Leg:
                return Leg;

            case BodyParts.Spine:
                return Spine;

            case BodyParts.Hand:
                return Hand;

            case BodyParts.Foot:
                return Foot;

            default:
                return null;
        }
    }

    public void GetSprites()
    {
        //Rename these in the Resources/XraySprites directory. Make names like: brokenArm0, brokenArm1..(good -> bad)

        Head = Resources.LoadAll<Sprite>("XraySprites/EthanHead");
        Torso = Resources.LoadAll<Sprite>("XraySprites/EthanTorso");
        Arm = Resources.LoadAll<Sprite>("XraySprites/EthanArm");
        Leg = Resources.LoadAll<Sprite>("XraySprites/EthanLegs");
        Hand = Resources.LoadAll<Sprite>("XraySprites/EthanHand");
        Foot = Resources.LoadAll<Sprite>("XraySprites/EthanFoot");
    }
}
