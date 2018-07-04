using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] victims;

    public Sprite greenCheck,
                  redX;

    

	// Use this for initialization
	void Start ()
    {
        victims = GameObject.FindGameObjectsWithTag("victim");
		
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



}
