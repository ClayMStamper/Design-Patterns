using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalItem : MonoBehaviour, ISpecialGrabbable
{
    public void Interact()
    {
        if (transform.parent.GetComponent <DrawerContent>() != null) //is drawer
        {

            DrawerContent parent = transform.parent.GetComponent<DrawerContent>();
            parent.UnsetCurrentItem();

            transform.SetParent(null);

        }
    }

}
