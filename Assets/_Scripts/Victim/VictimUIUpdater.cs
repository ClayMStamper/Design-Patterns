using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictimUIUpdater : MonoBehaviour {
    Victim victimScript;
    public GameObject victim,
                     uiDisplayLocation,
                     uiParent,
                     header,
                     victimName,
                     respiratoryRate,
                     capillaryRefill,
                     radialPulse;

	// Use this for initialization
	void Start () 
    {
        /*
        victimScript = victim.GetComponent<Victim>();
        uiParent = this.gameObject;
        header = uiParent.transform.Find("Header").gameObject;
        victimName = header.transform.Find("Name").gameObject;

        respiratoryRate = uiParent.transform.Find("RespiratoryRate").transform.Find("Value").gameObject;
        capillaryRefill = uiParent.transform.Find("CapillaryRefill").transform.Find("Value").gameObject;
        radialPulse = uiParent.transform.Find("RadialPulse").transform.Find("Value").gameObject;

        victimName.GetComponent<Text>().text = victimScript.GetVictimName();
        respiratoryRate.GetComponent<Text>().text = victimScript.GetRespRate().ToString() + " r/s";
        capillaryRefill.GetComponent<Text>().text = victimScript.GetCapillaryRefillTime().ToString()+" s";
        radialPulse.GetComponent<Text>().text = victimScript.hasRadialPulse.ToString();

        uiParent.name = victimScript.GetVictimName() + "_UI";
        */

        //If we're not doing "finds" then this might be the way to go...DO NOT REARRANGE THE CHILDREN IN THE HIERARCHY!!!!

        victimScript = victim.GetComponent<Victim>();

        header = this.transform.GetChild(0).gameObject; //Gets the first Child(Header) of this Gameobject(The VictimUI)
        respiratoryRate = this.transform.GetChild(1).gameObject;
        capillaryRefill = this.transform.GetChild(2).gameObject;
        radialPulse = this.transform.GetChild(3).gameObject;
        victimName = header.transform.GetChild(1).gameObject;

        victimName.GetComponent<Text>().text = victimScript.GetVictimName();
        respiratoryRate.transform.GetChild(1).GetComponent<Text>().text = victimScript.GetRespRate().ToString() + "r/s";
        capillaryRefill.transform.GetChild(1).GetComponent<Text>().text = victimScript.GetCapillaryRefillTime().ToString() + " s";
        radialPulse.transform.GetChild(1).GetComponent<Text>().text = victimScript.hasRadialPulse.ToString();

    }
	
	// Update is called once per frame
	void Update () 
    {

        

        respiratoryRate.transform.GetChild(1).GetComponent<Text>().text = victimScript.GetRespRate().ToString() + "r/s";
        capillaryRefill.transform.GetChild(1).GetComponent<Text>().text = victimScript.GetCapillaryRefillTime().ToString() + " s";
        radialPulse.transform.GetChild(1).GetComponent<Text>().text = victimScript.hasRadialPulse.ToString();
        TagColor(victimScript.GetUserTag());

    }
    void TagColor(ConditionTag tag) 
    {
        switch(tag) 
        {
            case ConditionTag.Green:
                header.GetComponent<Image>().color = Color.green;
                uiParent.GetComponent<Image>().color= new Color(0,1,0,0.3921569f);
                break;

            case ConditionTag.Yellow:
                header.GetComponent<Image>().color = Color.yellow;
                uiParent.GetComponent<Image>().color = new Color(1, .92f, .016f, 0.3921569f);
                break;

            case ConditionTag.Red:
                header.GetComponent<Image>().color = Color.red;
                uiParent.GetComponent<Image>().color = new Color(1, 0, 0, 0.3921569f);
                break;

            case ConditionTag.Grey:
                header.GetComponent<Image>().color = Color.grey;
                uiParent.GetComponent<Image>().color = new Color(.5f, .5f, .5f, 0.3921569f);
                break;

            case ConditionTag.Black:
                header.GetComponent<Image>().color = Color.black;
                uiParent.GetComponent<Image>().color = new Color(0, 0, 0, 0.3921569f);
                break;

            case ConditionTag.Untagged:
                header.GetComponent<Image>().color = Color.white;
                uiParent.GetComponent<Image>().color = new Color(1, 1, 1, 0.3921569f);
                break;

            default:
                break;
        }

    }
}
