/* Class: InjuryUIHandler
 * Inherits: MonoBehavior
 * Uses: System.Collections, System.Collections.Generic, UnityEngine, UnityEngine.UI
 * 
 * Created: 7/16/2018
 * Last Modified: 7/25/2018
 * 
 * Objective
 * ------------------------
 * This class is intended to recieve data contained in the ResourcesManager and use it to assign sprites and text to the ui containing the bone break,
 * concussion and lung status. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InjuryUIHandler : MonoBehaviour 
{
    enum BreakSeverity {NOTBROKEN, BREAKONE, BREAKTWO, BREAKTHREE, SPECIALCASE };

    int breakSeverity;

    BodyPart bodyPartScript;

    BodyParts selectedPart;

    //public const int NUM_BP = 10; //probably not necessary

    public GameManager UIManager;   // change "GameManager" to ResourceBank

    public GameObject bone,         // The bone that the UI is attached to 
                      uiParent,     // The canvas containing this script
                      Header,       // Header of the canvas
                      condition;    // Condition of the selected bodypart

    public bool isBroken, // bools determine UI text status
                isBurned,
                isLungCollapsed,
                isConcussed;

    public string notBroken = "0 / 3", // severity strings, breaks 0 through 3. 0 / 3 - No break. 3 / 3 - Most severe break.
                  break1 = "1 / 3",
                  break2 = "2 / 3",
                  break3 = "3 / 3";

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
        
        bodyPartScript = GetComponent<BodyPart>(); // get reference to the BodyPart script

        breakSeverity = 1; // temporary hardcoding

        Header = this.transform.GetChild(0).gameObject;
        condition = this.transform.GetChild(1).gameObject;
        uiParent = this.transform.GetChild(2).gameObject;
	}
	
	/* Function: SetupUI()
     * Type: Void
     * Recieves: N/A
     * Returns: N/A
     * 
     * Objective: Assigns data such as break severity, concussion, lung status and X-ray sprites (more will be added in later versions) to the body part UI. 
     */

	public void SetupUI() 
    {
        if (isBroken == true) // Declares the bone broken if isBroken is set to "true"
            condition.transform.GetChild(1).GetComponent<Text>().text = "Bone is broken.";
        else // Otherwise it declares the bone as not broken when it is set equal to "false"
            condition.transform.GetChild(1).GetComponent<Text>().text = "Bone is not broken.";

        if (isConcussed == true) // Declares the head as concussed if isConcussed is set to "true"
            condition.transform.GetChild(2).GetComponent<Text>().text = "Head is concussed.";
        else // Otherwise it declares the head as not concussed when it is set equal to "false"
            condition.transform.GetChild(2).GetComponent<Text>().text = "Head is not concussed";

        if (isLungCollapsed == true) // Declares that a Lung as collapsed if isLungCollapsed is set to "true"
            condition.transform.GetChild(0).GetComponent<Text>().text = "Lung is Collapsed";
        else // Otherwise it declares the Lungs as not collapsed when it is set equal to "false"
            condition.transform.GetChild(0).GetComponent<Text>().text = "Lung is not collapsed";

        if (isBurned == true)
            condition.transform.GetChild(0).GetComponent<Text>().text = "Victim is burned";
        else
            condition.transform.GetChild(0).GetComponent<Text>().text = "Victim is not burned";

        //for (int i = 0; i < NUM_BP; i++) // probably not necessary
        //{
            //The above will eventually be replaced:
            //"selectedPart" will be the type of bodypart returned by a raycastHit
            //BodyParts selectedPart = RaycastHit;


            switch (breakSeverity) // Assigns the specific Text and Sprites recieved from the victim's status 
            {
                case 1:
                        isBroken = true; 
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + break1; // Assigns the text "Break Severity: 1 / 3"
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity]; // Assigns the X-Ray Sprite based on the breakSeverity and selectedPart
                    break;
                case 2: 
                        isBroken = true;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + break2; // Assigns the text "Break Severity: 2 / 3"
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity]; // Assigns the X-Ray Sprite based on the breakSeverity and selectedPart
                    break;
                case 3:
                        isBroken = true;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + break3; // Assigns the text "Break Severity: 3 / 3"
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity]; // Assigns the X-Ray Sprite based on the breakSeverity and selectedPart
                    break;
                case 4:
                        isBroken = false;
                        isConcussed = true;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + notBroken; // Assigns the text "Break Severity: 0 / 3"
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity]; // Assigns the X-Ray Sprite based on the breakSeverity and selectedPart
                    break;
                default:
                        isBroken = false;
                        isConcussed = false;
                        condition.transform.GetChild(0).GetComponent<Text>().text = System.Environment.NewLine + "Break Severity: " + notBroken; // Assigns the text "Break Severity: 0 / 3"
                        uiParent.transform.GetChild(0).GetComponent<Image>().sprite = UIManager.GetArray(selectedPart)[breakSeverity]; // Assigns the X-Ray Sprite based on the breakSeverity and selectedPart
                    break;
            }
        //}
    }

    /* Function: SetSelectedPart()
     * Type: Void
     * Recieves: BodyParts selectedPart
     * returns: N/A
     * 
     * Objective: To set the selected body part.
     */

    public void SetSelectedPart(BodyParts selectedPart)
    {
        this.selectedPart = selectedPart;
    }

    /* Function: SetBreakSeverity()
     * Type: Void
     * Recieves: int breakSeverity
     * returns: N/A
     * 
     * Objective: To set break severity as an int.
     */

    public void SetBreakSeverity(int breakSeverity)
    {
        this.breakSeverity = breakSeverity;
    }
}