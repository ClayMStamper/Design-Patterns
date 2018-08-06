using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager: MonoBehaviour
{
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

    private void Start()
    {
        LoadSprites();
    }

    /* Function: GetArray()
     * Type: public Sprite[]
     * Receives: BodyParts bp
     * Returns: A body part or null
     * 
     * Objective - Determines the body part sprite array that needs to be returned and shown on the UI so that the Caller can access
     *             a Sprite from that Array.
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

    /* Function: LoadSprites()
     * Type: public void
     * Receives: N/A
     * Returns: N/A
     * 
     * Objective - Fills  Sprite[].* arrays with the status sprite options for each body part.
     */

    public void LoadSprites()
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
