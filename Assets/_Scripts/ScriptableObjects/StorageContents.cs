using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContents : MonoBehaviour
{
    public Transform spawnerLocation; //Will hold the location at which the initial transform values of the items are based;
    public Vector3 offset = Vector3.zero; //Offset from the Spawner location and other items in the Drawer.

    public List<GameObject> drawerContents; //A List to hold the GameObjects "stored" in the drawer
    public SODrawerContents drawerScriptableObject; //Holds the SO this drawer is based on -- determines which items are "stored" in the drawer.

    public bool openedDrawer = false;
    public bool closedDrawer = false;

    public float itemSpacing = 0.35f; //How far apart are the items (horizontally) --  .3 seems to be a good default value for fitting ALL objects, 
                                     //                                               refine to fit specific objects if desired.

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
        offset.x = (drawerScriptableObject.drawerContents.Length / 2) * -itemSpacing;
        offset.y = 0.75f; //How far vertically above the spawnLocation are the objects -- 0.75f seems to be a decent value (Maybe 0.6f?)

        if(drawerContents.Count == 0)
        {
            foreach (GameObject pref in drawerScriptableObject.drawerContents)
            {
                GameObject obj = Instantiate(pref);
                obj.transform.SetPositionAndRotation(spawnerLocation.transform.position + offset, spawnerLocation.rotation);
                drawerContents.Add(obj);
                obj.SetActive(true);

                offset.x += itemSpacing;
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

        offset = Vector3.zero;
    }

}
