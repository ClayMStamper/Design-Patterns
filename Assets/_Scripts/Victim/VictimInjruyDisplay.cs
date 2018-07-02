using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimInjruyDisplay : MonoBehaviour {
    public const string THRESHHOLD = "Vector1_3F6C7BF3";
    public const string INJURYMASK1 = "Texture_40E362AD";
    public const string INJURYMASK2 = "Texture_E17A53A1";
    public const string INJURYMASK3 = "Texture_8245CA4";
    GameObject body;
    Victim victim;
    bool injuredHead=false;
    bool injuredBody=false;
    Renderer renderer;
    public Material headMaterial;
    public Material bodyMaterial;
    Texture headInjuryMask;
    Texture bodyInjuryMask;
    public List<Texture> headInjuryMasks= new List<Texture>();
    public List<Texture> bodyInjuryMasks= new List<Texture>();
    

	// Use this for initialization
	void Start ()
    {
        victim = GetComponent<Victim>();
        body = transform.Find("CC_Base_Body").gameObject;
        renderer = body.GetComponent<Renderer>();
        bodyMaterial = renderer.materials[0];
        headMaterial = renderer.materials[1];
        //bodyInjuryMask = bodyMaterial.GetTexture("InjuryMask");
        //headInjuryMask = headMaterial.GetTexture("InjuryMask");
        UpdateInjuredParts();
        
    }

    public void VictimBleed(float bloodLoss)
    {
        bodyMaterial.SetFloat(THRESHHOLD, bodyMaterial.GetFloat(THRESHHOLD) + bloodLoss);
        headMaterial.SetFloat(THRESHHOLD,headMaterial.GetFloat(THRESHHOLD) + bloodLoss);
    }

    public void UpdateInjuredParts()
    {
         //injuredHead = false;
         //injuredBody = false;

        for (int i = 0; i < victim.injuredBodyParts.Count; i++)
        {
            if (victim.injuredBodyParts[i].partType == BodyParts.Head)
            {
                injuredHead = true;
            }
            if (victim.injuredBodyParts[i].partType != BodyParts.Head)
            {
                injuredBody = true;
            }
        }
    }

    public void UpdateMask(int injuryMaskIndex,int materialLocation,int maskNumber)
    {
        switch (materialLocation)
        {
            case 0:
                if (maskNumber == 1)
                {
                    bodyMaterial.SetTexture(INJURYMASK1, bodyInjuryMasks[injuryMaskIndex]);
                } 
                
                else if (maskNumber == 2)
                {
                    bodyMaterial.SetTexture(INJURYMASK2, bodyInjuryMasks[injuryMaskIndex]);
                }
                
                else if (maskNumber == 3)
                {
                    bodyMaterial.SetTexture(INJURYMASK3, bodyInjuryMasks[injuryMaskIndex]);
                }

                break;
            case 1:
                if (maskNumber == 1)
                {
                    headMaterial.SetTexture(INJURYMASK1, headInjuryMasks[injuryMaskIndex]);
                } 
                else if (maskNumber == 2)
                {
                    headMaterial.SetTexture(INJURYMASK2, headInjuryMasks[injuryMaskIndex]);
                } 
                else if (maskNumber == 3)
                {
                    headMaterial.SetTexture(INJURYMASK3, headInjuryMasks[injuryMaskIndex]);
                }
                break;
        }

        

    }
}
