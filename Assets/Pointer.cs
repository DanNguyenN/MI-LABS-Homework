using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
    public GameObject Controller;
    public GameObject Player;


    private GameObject lastObject;


    public float maxRayDistance = 100f;

    void Start()
    {

    }

    void Update()
    {
        // Ray cast from the center of the camera
        Ray ray = new Ray(Controller.transform.position, Controller.transform.forward);

        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object has the Outline.cs script
            if (hit.collider.gameObject.GetComponent<Outline>() != null)
            {
                //hit.collider.gameObject.GetComponent<Outline>().enabled = true;

                // Disable outline for the previous object
                if (lastObject != null && lastObject != hit.collider.gameObject)
                {
                    //lastObject.GetComponent<Outline>().enabled = false;
                }

                lastObject = hit.collider.gameObject;
            }
        }
        else
        {

            // Disable outline for the previous object
            if (lastObject != null)
            {
                //lastObject.GetComponent<Outline>().enabled = false;
                lastObject = null;
            }
        }

        // Check for input
        checkInput();

    }



    void checkInput()
    {
        if (lastObject == null)
        {
            return;
        }

        // Check if the X button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Debug.Log("X button pressed");
            //Check if object first 4 letters are "Cube"
            if (lastObject.name == "Cube1")
            {
                //Make the cube go up in y direction
                lastObject.transform.Translate(0, 1, 0);
            }else if (lastObject.name == "Cube2")
            {
                //Object is rotated 30 degrees in the x direction
                lastObject.transform.Rotate(30, 0, 0);
            }
        }

        // Check if the Y button is pressed
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Debug.Log("Y button pressed");
            if (lastObject.name.Substring(0, 6) == "Sphere")
            {
                //Teleport the player to the sphere but keep the same y position
                Player.transform.position = new Vector3(lastObject.transform.position.x, Player.transform.position.y, lastObject.transform.position.z);
                //Destroythe sphere
                Destroy(lastObject);
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


