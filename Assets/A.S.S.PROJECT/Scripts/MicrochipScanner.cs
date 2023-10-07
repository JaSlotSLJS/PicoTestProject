using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class MicrochipScanner : MonoBehaviour
{
    
    public TextMeshProUGUI idText;
    public TextMeshProUGUI visaText;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        grabbable.activated.AddListener(ScanMicrochip);
    }

    public void ScanMicrochip(ActivateEventArgs arg)
    {
        Vector3 direction = Vector3.forward;

        Ray scanRay = new Ray(transform.position, transform.TransformDirection(direction*10));

        Debug.DrawRay(transform.position, transform.TransformDirection(direction*10));

        Debug.Log("Scanning the Microchip");
        if (Physics.Raycast(scanRay, out RaycastHit hit, 10))
        {
            if (hit.collider.CompareTag("NPC"))
            {
                hit.collider.gameObject.GetComponent<NPCMovement>().scanned = true; 

            }
            Debug.Log($"This object named {hit.collider.gameObject.name} has been scanned");
        }
       
        idText.text = $"{hit.collider.gameObject.name}";
        visaText.text = $"{hit.collider.gameObject.name} Has a specific visa";
    }
}
