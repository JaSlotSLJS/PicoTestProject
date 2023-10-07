using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RejectButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<XRPushButton>().selectEntered.AddListener(x => RejectNPC());
    }

    public void RejectNPC()
    {
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().denied = true;

        Debug.Log("REJECTED");
    }
}
