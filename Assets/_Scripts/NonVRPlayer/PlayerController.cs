using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameObject target = null;
    private ConditionTag currentTag = ConditionTag.Untagged;
    public float speed = 10.0F;


	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        // Moves the player 
        float translation = Input.GetAxis("Vertical") * speed;
        float strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        // Frees the mouse
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // Sets the current Tag
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentTag = ConditionTag.Green; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentTag = ConditionTag.Yellow;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentTag = ConditionTag.Red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentTag = ConditionTag.Grey;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentTag = ConditionTag.Black;
        }

        // set tag on mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            TagVictim(currentTag);
        }

		
	}

    // returns the GameObject the player is looking at
    void TagVictim(ConditionTag tag)
    {
        RaycastHit hit;
        Vector3 lineOfVision = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, lineOfVision, Color.red);

        if (Physics.Raycast(transform.position, lineOfVision, out hit))
        {
            if (hit.collider.tag == "victim")
            {
                Debug.DrawRay(transform.position, lineOfVision, Color.green);
                
                hit.collider.gameObject.SendMessageUpwards("SetUserTag", tag, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
