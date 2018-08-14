using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimSpawnPoint : MonoBehaviour {

    [SerializeField]
    public GameObject bodyType; // Body Type MUST be an iClone format character prefab (i.e, Ethan) with body parts tagged
    [SerializeField]
    public string victimName;

    private GameObject skeletalMesh;
    private GameObject UINameTag;
    private GameObject UIHead;
    private GameObject UIBody;
    private GameObject UILeftArm;
    private GameObject UIRightArm;
    private GameObject UILeftLeg;
    private GameObject UIRightLeg;


    // Use this for initialization
    void Start() {

        skeletalMesh = Instantiate(bodyType, transform.position, transform.rotation);

        // Creates UI Canvases 
        UINameTag = Instantiate(GameObject.Find("VictimUI"), transform.position + transform.up * 2, transform.rotation);
        UINameTag.transform.parent = skeletalMesh.transform;

        UIHead = Instantiate(GameObject.Find("InjuryUI"), new Vector3(0, 0, 0), Quaternion.identity);
        UIBody = Instantiate(GameObject.Find("InjuryUI"), new Vector3(0, 0, 0), Quaternion.identity);
        UILeftArm = Instantiate(GameObject.Find("InjuryUI"), new Vector3(0, 0, 0), Quaternion.identity);
        UIRightArm = Instantiate(GameObject.Find("InjuryUI"), new Vector3(0, 0, 0), Quaternion.identity);
        UILeftLeg = Instantiate(GameObject.Find("InjuryUI"), new Vector3(0, 0, 0), Quaternion.identity);
        UIRightLeg = Instantiate(GameObject.Find("InjuryUI"), new Vector3(0, 0, 0), Quaternion.identity);

        // Assign all Canvases as children to their respective Bones
        Transform[] boneList = skeletalMesh.GetComponentsInChildren<Transform>();

        foreach (Transform bone in boneList)
        {
            if (bone.CompareTag("Head"))
            {
                UIHead.transform.position = bone.transform.position + bone.transform.forward * 0.25f;
            }

            if (bone.CompareTag("Body"))
            {
                UIHead.transform.position = bone.transform.position + bone.transform.forward * 0.25f;
            }
        }

    }

	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(0.6f, 0.1f, 0.6f));
        Gizmos.DrawWireSphere(this.transform.position + this.transform.forward * 0.5f, 0.1f);
    }
}
