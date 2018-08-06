using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContents : MonoBehaviour
{
    public Transform spawnerLocation; //Will hold the location at which the initial transform values of the items are based;
    public Vector3 offset; //Offset from the Spawner location and other items in the Drawer.

    public List<GameObject> drawerContents; //A List to hold the GameObjects "stored" in the drawer
    public SODrawerContents drawerScriptableObject; //Holds the SO this drawer is based on -- determines which items are "stored" in the drawer.

    public bool openedDrawer = false;
    public bool closedDrawer = false;

	// Use this for initialization
	void Start ()
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
        if(drawerContents.Count == 0)
        {
            foreach (GameObject pref in drawerScriptableObject.drawerContents)
            {
                GameObject obj = Instantiate(pref);
                obj.transform.SetPositionAndRotation(spawnerLocation.transform.position + offset, Quaternion.Euler(Vector3.zero));
                drawerContents.Add(obj);
                obj.SetActive(true);
            }
        }    
    }

    private void ContentsDespawner()
    {
        int counter = 0;

        while (drawerContents.Count >= 1)
        {
            GameObject.Destroy(drawerContents[counter]);
            drawerContents.Remove(drawerContents[counter]);
        } 
    }

}
