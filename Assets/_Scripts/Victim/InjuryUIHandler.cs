using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InjuryUIHandler : MonoBehaviour 
{
    BodyPart bodyPartScript;

    public const int NUM_BP = 10; // needs to be changed 

    public GameManager UIManager;

    public GameObject bone,
                      uiDisplayLocation,
                      uiParent,
                      header,
                      condition;

    public bool isBroken,
                isBurned,
                isLungCollapsed,
                isConcussed;

    public string notBroken = "0 / 3",
                  break1 = "1 / 3",
                  break2 = "2 / 3",
                  break3 = "3 / 3";

    public int breakSeverity = 4;

    string Head = "Head",
           Neck = "Neck",
           Torso = "Torso",
           Arm = "Arm",
           Abdomen = "Abdomen",
           Pelvis = "Pelvis",
           Leg = "Leg",
           Spine = "Spine",
           Hand = "Hand",
           Foot = "Foot";

	// Use this for initialization
	void Start () 
    {
        
        bodyPartScript = GetComponent<BodyPart>();

        header = this.transform.GetChild(0).gameObject;
        condition = this.transform.GetChild(1).gameObject;
        uiParent = this.transform.GetChild(2).gameObject;
	}
	
	
	void SetupUI () 
    {
        if (isBroken == true) // Declares the bone broken or not if isBroken is set to true or false
            condition.transform.GetChild(1).GetComponent<Text>().text = "Bone is broken.";
        else
            condition.transform.GetChild(1).GetComponent<Text>().text = "Bone is not broken.";

        if (isConcussed == true) // Declares the head as either concussed or not if isConcussed is set to true or false
            condition.transform.GetChild(2).GetComponent<Text>().text = "Head is concussed.";
        else
            condition.transform.GetChild(2).GetComponent<Text>().text = "Head is not concussed";

        //// isLungcollapsed


        for (int i = 0; i < NUM_BP; i++)
        {
            BodyParts selectedPart = BodyParts.NULL;
            //The above will eventually be replaced:
            //"selectedPart" will be the type of bodypart returned by a raycastHit
            //BodyParts selectedPart = RaycastHit;

            switch (breakSeverity)
            {
                case 1:
                        isBroken = true;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + break1;
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity];
                    break;
                case 2: 
                        isBroken = true;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + break2;
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity];
                    break;
                case 3:
                        isBroken = true;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + break3;
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity];
                    break;
                case 4:
                        isBroken = false;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + notBroken;
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity];
                    break;
                default:
                        isBroken = false;
                        isConcussed = false;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + notBroken;
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity];
                    break;
            }
        }
    }
}