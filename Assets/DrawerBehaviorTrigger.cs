using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerBehaviorTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drawer"))
        {
            other.GetComponent<StorageContentsV2>().closedDrawer = false;
            other.GetComponent<StorageContentsV2>().openedDrawer = true;
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Drawer"))
        {
            other.GetComponent<StorageContentsV2>().openedDrawer = false;
            other.GetComponent<StorageContentsV2>().closedDrawer = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Drawer"))
        {
            other.GetComponent<StorageContentsV2>().openedDrawer = false;
            other.GetComponent<StorageContentsV2>().closedDrawer = true;
        }
    }

}
