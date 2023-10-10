using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform npcPrefab;

    public Transform spawnPoint;

    float timeBetweenWaves = 5f;
    float countdown = 5f;

    public bool isThereNPC;

    private void Start()
    {
        SpawnNPC();
    }
    private void Update()
    {
        //if (!isThereNPC)
        //{
        //    SpawnNPC();
            
        //    return;
        //    //countdown = timeBetweenWaves;
        //}

        //countdown -= Time.deltaTime;
    }
    public void SpawnNPC()
    {
        //isThereNPC = true;
        Instantiate(npcPrefab, spawnPoint.position, spawnPoint.rotation);
        return;

        
        Debug.Log("NPC SAPWNING");
    }
}
