using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcChanger : MonoBehaviour
{
    [SerializeField] GameObject[] npcs;
    int npcNumber;
    public bool changeNPC;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int npcNumber = 0; npcNumber < npcs.Length; npcNumber++)
        {
            if (changeNPC)
            {
                npcs[npcNumber - 1].SetActive(false);
                changeNPC = false;
                npcs[npcNumber].SetActive(true);
                
            }
        }

    }
    public void ChangeMaterial()
    {
       
    }
}
