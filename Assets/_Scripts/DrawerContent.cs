using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerContent : MonoBehaviour {

    [SerializeField]
    GameObject itemPrefab;

    [SerializeField] [Tooltip ("How high item floats out of drawer")]
    float floatDistance = 0.2f;
    [SerializeField]
    float floatSpeed = 3.0f;
    [SerializeField] [Tooltip("Starting rotation of spawned objects")]
    Vector3 orientation;
    [SerializeField] [Tooltip ("distance from parent on spawn")]
    Vector3 offset;

    [HideInInspector]
    public GameObject currentItem;

    private void Start()
    {
        SpawnNewItem();
    }

    //on current item was grabbed
    public void UnsetCurrentItem()
    {
        currentItem = null;
        SpawnNewItem();
    }

    private void SpawnNewItem()
    {
        currentItem = Instantiate(itemPrefab, transform.position + offset, Quaternion.Euler (orientation), transform) as GameObject;
    }

    public void OnWasMoved(float pullDistance)
    {

        Debug.Log("was moved");

        //Debug.Log("distance is: " + floatDistance + ", my parents height is" + transform.position.y, +", so my height is: " + transform.position.y);

        Vector3 newItemPos = currentItem.transform.position;
        newItemPos.y = transform.position.y + pullDistance;

        currentItem.transform.position = Vector3.Lerp (currentItem.transform.position, newItemPos, Time.deltaTime * floatSpeed);

    }
}
