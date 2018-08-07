#region
/* File: MedicalSuppliesUIManager.cs
 * Type: MonoBehavior
 * 
 * Objective: 
 * ----------------------------------------------------------------------------------------------------------------
 * Makes the Diegetic UI for the Medical Supplies always face the Player Camera (The MAIN Camera).
 * This script will take in the Transform of the GameObject the canvas is to be hovering above and then use an
 * offset to position direcetly above the GameObject. Doing it this way will prevent the Canvas from rotating as
 * the object itself rotates.
 * 
 * 
 */

#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalSuppliesUIManager : MonoBehaviour
{
    public Transform pairedObjectTransform;
    public Vector3 offset; //Position the Canvas above the center of the object.

    // Update is called once per frame
    void Update()
    {
        FaceMainCamera();
        this.GetComponent<Transform>().position = pairedObjectTransform.position + offset;
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
