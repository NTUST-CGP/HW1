using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveSwitch : MonoBehaviour {

    public Camera firstPersonCamera; //the camera for first person view
    public Camera thirdPersonCamera; //the camera for third person view
    public KeyCode switchKey = KeyCode.C; //the key to switch between views

    void Start () {
        //enable first person camera and disable third person camera by default
        firstPersonCamera.enabled = true;
        thirdPersonCamera.enabled = false;
    }

    void Update () {
        //check if switch key is pressed
        if (Input.GetKeyDown(switchKey)) {
            //toggle between cameras by switching their enabled state
            firstPersonCamera.enabled = !firstPersonCamera.enabled;
            thirdPersonCamera.enabled = !thirdPersonCamera.enabled;
        }
    }
}