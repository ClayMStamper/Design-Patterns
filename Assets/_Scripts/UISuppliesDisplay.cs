using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISuppliesDisplay : MonoBehaviour
{
    public SOSupplies MedicalSupply;

    private string itemName,
                   description;

    private int quantity;


    private void Start()
    {
        itemName = MedicalSupply.name;
        description = MedicalSupply.description;
        quantity = MedicalSupply.quantity;
    }
}
