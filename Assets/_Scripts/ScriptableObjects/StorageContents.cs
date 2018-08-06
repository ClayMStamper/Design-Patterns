using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContents : MonoBehaviour {

    private List<GameObject> inventory;
    private List<GameObject> instances;
    [SerializeField]
    public string drawerPreset = null;
    [SerializeField]
    public Transform origin = null;
    private float offsetSize = 0.25f;
    private float height = 20;

    public GameObject prefab;

    public SOSupplies item;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void spawnContents(SOSupplies itemData)
    {

        for (int i = 0; i < itemData.quantity; i++)
         {
            GameObject obj = GameObject.Instantiate(prefab, origin);
            obj.name = itemData.name;

            //return obj;
            obj.transform.position = origin.position; //.Translate(Vector3.right * (i * offsetSize), Space.Self);
            obj.transform.Translate(Vector3.right * (i * offsetSize), Space.Self);


            // instances.Add(obj);
        }

       // }
    }
}
