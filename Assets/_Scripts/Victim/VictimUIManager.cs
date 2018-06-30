/* File: VictimeUIManager.cs
 * 
 * Created: 6/27/2018
 * Last Modified: 6/27/2018
 * 
 * 
 * Objective: 
 * 
 * This will handle the controlling of the position/rotation/etc of the diegeticUI for the NPC(s)
 * Will also handle the priority of the diegetic UI(s).
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimUIManager : MonoBehaviour {

	// Update is called once per frame
	void Update () 
    {
        FaceMainCamera();
	}

    /* Function: FaceMainCamera()
     * Type: void
     * Recieves: Nothing
     * Returns: N/A
     * 
     * Objective: 
     * Makes the diegetic UI canvas face the Main Camera regardless of rotation.
     */

    void FaceMainCamera() 
    {
       this.transform.rotation = Camera.main.transform.rotation;
       //this.transform.LookAt(Camera.main.transform);
    }
}
