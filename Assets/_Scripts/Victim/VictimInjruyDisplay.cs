using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimInjruyDisplay : MonoBehaviour {
    GameObject body;
    Victim victim;
    Renderer renderer;
    Material headMaterial;
    Material bodyMaterial;
    Texture headInjuryMask;
    Texture bodyInjuryMask;
    public List<GameObject> headInjuryMasks= new List<GameObject>();
    public List<GameObject> bodyInjuryMasks= new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        body = transform.Find("CC_Base_Body").gameObject;
        renderer = body.GetComponent<Renderer>();
        bodyMaterial = renderer.materials[0];
        headMaterial = renderer.materials[1];
        bodyInjuryMask = bodyMaterial.GetTexture("InjuryMask");
        headInjuryMask = headMaterial.GetTexture("InjuryMask");
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
