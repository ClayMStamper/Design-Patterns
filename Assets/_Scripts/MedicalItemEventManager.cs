/* File:L MedicalItemEventManager.cs
 * 
 * Created: 8/10/2018
 * LastModified: 8/10/2018
 * 
 * Inherits: Monobehavior
 * SubType: EventSystem
 * 
 * Objective: Syncing, item events.
 * 
 * Events that will be handled:
 *   1.) ItemLerp.cs - ItemLerping
 *   2)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalItemEventManager : MonoBehaviour
{

    #region singleton

    private static MedicalItemEventManager instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }

    }

    public MedicalItemEventManager GetInstance()
    {
        return instance;
    }

    #endregion


    public delegate void MedicalItemFunctions();

    public static event MedicalItemFunctions MedicalItemLerpCallback;


    //Trigger the callback
    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
