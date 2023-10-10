using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ApprovalButton : MonoBehaviour
{
    MicrochipScanner microchipscanner;
    private void Awake()
    {
        microchipscanner = GameObject.FindAnyObjectByType<MicrochipScanner>();
    }
    public void AcceptNPC()
    {
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>().approved = true;
        microchipscanner.hasDecided = true;
        Debug.Log("ACCEPTED");
    }
    public void RejectNPC()
    {
        GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>().denied = true;
        microchipscanner.hasDecided = true;
        Debug.Log("REJECTED");
    }
}
