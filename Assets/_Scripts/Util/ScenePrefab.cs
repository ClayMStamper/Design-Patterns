using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/*
 * Author: Clayton
 * 
 * Use Case: When adding functionality unlink prefab by right clicking this component and select the "Relink" function.
 * 
 * Requirements: 
 * - Reference low lvl prefabs in serialized list
 * - Low lvl prefabs have LowLvlPrefab.cs attached
 * - Reference prefab link in each low lvl prefab
 * 
 */
public class ScenePrefab : MonoBehaviour {

    [SerializeField]
    List<GameObject> LowLvlPrefabs;

    [ContextMenu("Relink Low Lvl Prefabs")]
    void LinkPrefabs()
    {

        //disconnect high level prefab
        PrefabUtility.DisconnectPrefabInstance(gameObject);

        //cycly through and relink low lvl prfabs
        foreach (GameObject obj in LowLvlPrefabs)
        {
            
            //cache references for when obj is destroyed
            GameObject newObj = null;
            Vector3 pos = obj.transform.position;

            GameObject prefabLink = obj.GetComponent<LowLvlPrefab>().prefabLink;

            try
            {
                //relink prefab (destroys current obj)
                newObj = PrefabUtility.ConnectGameObjectToPrefab(obj, prefabLink);
            }
            catch
            {
                Debug.LogError("Error linking Gameobject " + name + " to prefab " + prefabLink); //+ ":" + e.Message);
            }

            //reset to correct position
            newObj.transform.position = pos;

        }

    }

}
