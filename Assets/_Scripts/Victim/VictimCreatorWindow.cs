/* File: VictimCreatorWindow.cs
 * 
 * Inherits: EditorWindow
 * Uses: UnityEngine, UnityEditor, System.Collections
 * 
 * Objective:
 * ---------------------------
 * 
 * This script was created to create a window that could easily create victims by simple checking a few selections.
 * This script would selecte a victim model prefab, and then populate it's victim script with the selected injuries on the selected
 * body parts.
 */


using UnityEngine;
using UnityEditor;
using System.Collections;

public class VictimCreatorWindow : EditorWindow
{
    string sex = "Sex",
           race = "Race",
           age = "Age";

    bool groupEnabled,
         male = true,
         female = false,
         addInjury = false;


    [MenuItem("Window/Victim Creator")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(VictimCreatorWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Appearance", EditorStyles.boldLabel);
        GUILayout.Label("Sex:", EditorStyles.largeLabel);

        //Horiz SexList 
        //SingleSexCheck();
        EditorGUILayout.BeginHorizontal();
        male = EditorGUILayout.Toggle("Male", male);
        female = EditorGUILayout.Toggle("Female", female);
        EditorGUILayout.EndHorizontal();
       
    }
/*
    private void SingleSexCheck()
    {
        if ()
        {
            this.female = false;
            //EditorGUILayout.Toggle("Female", female);
        }
           
        else if()
        {
            this.male = false;
            //EditorGUILayout.Toggle("Male", male);
        }
            
    }*/
}
