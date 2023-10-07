using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class AcceptButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x=>AcceptNPC());
    }

    public void AcceptNPC()
    {
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCMovement>().approved = true;
        Debug.Log("ACCEPTED");
    }
}
