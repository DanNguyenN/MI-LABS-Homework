using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPointing : MonoBehaviour
{

    //Get the gameobject with name "Character" and assign it to OVR_Rig
    private GameObject OVR_Rig;

    

    // Start is called before the first frame update
    public void turnOutlineOn(bool on)
    {
        var outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = on;
        }
    }

    void Start()
    {
        OVR_Rig = GameObject.Find("Character");
    }

    private void Update()
    {
        //Check if the object has the Outline.cs script and if it is enabled
        if (GetComponent<Outline>() != null && GetComponent<Outline>().enabled)
        {
            //Check for input
            checkInput(gameObject);
        }
    }

    void checkInput(GameObject curr_object)
    {
        if (curr_object == null)
        {
            return;
        }

        // Check if the X button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Debug.Log("X button pressed");
            //Check if object first 4 letters are "Cube"
            if (curr_object.name == "Cube1")
            {
                //Make the cube go up in y direction
                curr_object.transform.Translate(0, 1, 0);
            }
            else if (curr_object.name == "Cube2")
            {
                //Object is rotated 30 degrees in the x direction
                curr_object.transform.Rotate(30, 0, 0);
            }
        }

        // Check if the Y button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Debug.Log("Y button pressed");
            if (curr_object.name.Substring(0, 6) == "Sphere")
            {
                //Teleport the player to the sphere but keep the same y position
                OVR_Rig.transform.position = new Vector3(curr_object.transform.position.x, OVR_Rig.transform.position.y, curr_object.transform.position.z);
                //Destroythe sphere
                Destroy(curr_object);
            }
        }

        // Check if the A button is pressed
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("A button pressed");
        }

        // Check if the B button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Debug.Log("B button pressed");
        }


    }
}
