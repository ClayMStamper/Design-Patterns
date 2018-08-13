using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContents : MonoBehaviour, ISpecialGrabbable
{
    public List<GameObject> drawerContents; //A List to hold the GameObjects "stored" in the drawer

    void Start()
    {
        GetContentsRecursively(transform);
    }

    void GetContentsRecursively(Transform t)
    {
        int i = 0;

        foreach (Transform child in t)
        {
            //add if medical item
            if (child.CompareTag("MedicalItem_Grabbable"))
            {
                drawerContents.Add(child.gameObject);
            }

            //check children
            GetContentsRecursively(child);
        }

    }

    public void Interact()
    {
        Debug.Log("DRAWER INTERACTED WITH BECAUSE SPECIAL");
        Debug.Break();
    }

}

//needs to be moved. Temporary spot for testing
public interface ISpecialGrabbable
{

    void Interact();

}
