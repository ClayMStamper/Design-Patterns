#region Description

/* Filename: Drawercontents.cs
 * Type: ScriptableObject
 * 
 * Objective: 
 *   Create child scriptable Objects with a public GameObject array that will be hold the contents of a Drawer gameobject
 *    -- the Drawer will load it's array with the sets of Gameobject pulled from these Scriptable Ojbects.
 */

#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Drawer", menuName = "ScriptableObjects/Drawer", order = 2)]
public class SODrawerContents : ScriptableObject
{
    public GameObject[] drawerContents;

}
