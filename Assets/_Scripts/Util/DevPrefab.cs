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
            PrefabUtility.ConnectGameObjectToPrefab(gameObject, prefabLink);
        } catch 
        {
            Debug.LogError("Error linking Gameobject " + name + " to prefab " + prefabLink); //+ ":" + e.Message);
        }
    
    }
}
