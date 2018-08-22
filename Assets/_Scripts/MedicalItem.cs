using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalItem : MonoBehaviour, ISpecialGrabbable
{
    public void Interact()
    {
        if (transform.parent.GetComponent <DrawerContent>()) //is drawer
        {

            DrawerContent parent = transform.parent.GetComponent<DrawerContent>();
            parent.UnsetCurrentItem();

        }
    }

}
