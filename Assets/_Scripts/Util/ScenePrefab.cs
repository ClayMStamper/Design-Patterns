using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum SceneCategory {Ambus, MCI}

public class ScenePrefab : MonoBehaviour {

    [SerializeField]
    private new string name;

    [SerializeField]
    private SceneCategory sceneCategory;

    [ContextMenu ("Set Prefab")]
    public void SetPrefab()
    {

        //duplicate gameobject

        //prefab duplicated gameobject
        try
        {
            switch (sceneCategory)
            {
                case SceneCategory.Ambus:
                    PrefabUtility.CreatePrefab(("Assets/_Prefabs/Ambus/ScenePrefabs/" + name + ".prefab"), gameObject);
                    break;
                case SceneCategory.MCI:
                    PrefabUtility.CreatePrefab(("Assets/_Prefabs/MassCasualty/ScenePrefabs" + name + ".prefab"), gameObject);
                    break;
                default:
                    Debug.LogError("Scene category not recognized");
                    break;
            }
        } catch
        {
            Debug.LogError("Failed to create new prefab");
        }

    }


}
