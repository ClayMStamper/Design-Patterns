using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContentsV2 : MonoBehaviour
{
    public GameObject[] drawerContents; //A List to hold the GameObjects "stored" in the drawer

    public bool openedDrawer = false;
    public bool closedDrawer = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (openedDrawer)
        {
            closedDrawer = false;
            ContentsSpawner();
        }


        if (closedDrawer)
        {
            openedDrawer = false;
            ContentsDespawner();
        }
    }

    private void ContentsSpawner()
    {
        foreach (GameObject obj in drawerContents)
        {
            obj.SetActive(true);

            //obj.GetComponent<Rigidbody>().isKinematic = true; //keeps the object from floating away.*/
        }
    }

    private void ContentsDespawner()
    {
        foreach (GameObject obj in drawerContents)
        { 
            obj.SetActive(false);
        }
    }
}
