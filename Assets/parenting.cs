using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class parenting : MonoBehaviour
{
    public GameObject thingBeingGrabbed;
    private void OnTriggerStay(Collider collider)
    {
        if (SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.Any)) {
            Debug.Log("button pressed");
            thingBeingGrabbed = collider.gameObject;
            thingBeingGrabbed.transform.parent = transform;
            thingBeingGrabbed.GetComponent<Rigidbody>().useGravity = false;
            thingBeingGrabbed.GetComponent<Rigidbody>().isKinematic = true;
        }

        else if(SteamVR_Input.GetStateUp("GrabPinch", SteamVR_Input_Sources.Any))
        {
            thingBeingGrabbed.transform.parent = null;
            thingBeingGrabbed.GetComponent<Rigidbody>().useGravity = true;
            thingBeingGrabbed.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
