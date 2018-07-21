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
                    Arm,
                    Abdomen,
                    Pelvis,
                    Leg,
                    Spine,
                    Hand,
                    Foot;

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
}