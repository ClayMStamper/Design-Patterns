using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerContent : MonoBehaviour {

    [SerializeField]
    GameObject item;
    [SerializeField] [Tooltip ("Where item spawns from")]
    Transform origin;

    [SerializeField] [Tooltip ("How high item floats out of drawer")]
    float floatDistance = 0.2f;

    [HideInInspector]
    public GameObject currentItem;

    //the current item
    public void UnsetCurrentItem()
    {

        currentItem = null;
        SpawnNewItem();

    }

    private void SpawnNewItem()
    {

    }
}
