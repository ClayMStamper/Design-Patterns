using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Medical", menuName = "ScriptableObjects/MedicalSupplies", order = 1)]
public class SOSupplies : ScriptableObject
{
    public new string name;

    public string description;

    public int quantity;

    public MeshRenderer mesh;

    public SphereCollider trigger;

}
