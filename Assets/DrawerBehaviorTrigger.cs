using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerBehaviorTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drawer"))
        {
            other.GetComponent<StorageContents>().closedDrawer = false;
            other.GetComponent<StorageContents>().openedDrawer = true;
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drawer"))
        {
            other.GetComponent<StorageContents>().openedDrawer = false;
            other.GetComponent<StorageContents>().closedDrawer = true;
        }
    }

}
