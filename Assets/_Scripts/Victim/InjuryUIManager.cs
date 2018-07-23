using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InjuryUIManager : MonoBehaviour
{
    Victim victimScript;

    public Sprite[] Head,
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

	void Start()
	{
        victimScript = GetComponent<Victim>();
	}

	// reference bodyparts from the victim script
	public Sprite[] GetArray( BodyParts bp )
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
}