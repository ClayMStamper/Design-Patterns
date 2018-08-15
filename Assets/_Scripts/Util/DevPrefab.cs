using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class DevPrefab : MonoBehaviour {

    [SerializeField]
    GameObject prefabLink;

    [ContextMenu ("Link Prefab")]
	void LinkPrefab()
    {
   
        try
        {
            Vector3 prePos = transform.position;

            PrefabUtility.ConnectGameObjectToPrefab(gameObject, prefabLink);

            //this line won't run. The script is destroyed by now
            transform.position = prePos;

        } catch 
        {
            Debug.LogError("Error linking Gameobject " + name + " to prefab " + prefabLink); //+ ":" + e.Message);
        }
    
    }
}
