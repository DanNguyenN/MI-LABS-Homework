using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject ovrCameraRig; // Assign the OVRCameraRig prefab in the Unity Inspector

    public GameObject CenterCamera;

    public float movementSpeed = 10.0f;

    private OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    private OVRInput.Controller rightController = OVRInput.Controller.RTouch;

    void Update()
    {
        // Get controller inputs
        Vector2 leftThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, leftController);
        Vector3 moveDirection = new Vector3(leftThumbstick.x, 0, leftThumbstick.y);

        // Get the forward and right directions of the CenterCamera
        Vector3 forward = CenterCamera.transform.forward;
        Vector3 right = CenterCamera.transform.right;

        // Keep the direction only in the horizontal plane
        forward.y = 0;
        right.y = 0;

        // Combine both forward and right directions for movement
        Vector3 move = (forward.normalized * moveDirection.z + right.normalized * moveDirection.x) * movementSpeed * Time.deltaTime;

        ovrCameraRig.transform.Translate(move, Space.World);
    }
}