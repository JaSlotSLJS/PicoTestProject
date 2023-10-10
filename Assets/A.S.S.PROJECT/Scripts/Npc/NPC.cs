using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    private Transform target;
    private int wavePointIndex = 0;
    NpcState npcState;

    public bool approved = false;
    public bool denied = false;
    public bool scanned = false;
    WaveSpawner spawn;
    private void Start()
    {
        target = WayPoints.points[wavePointIndex];
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<WaveSpawner>();
        //spawn.isThereNPC = true;
    }

    enum NpcState
    {
        WalkingState,
        ScanningState,
        WaitingState,
        ApprovedState,
        RejectedState
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        switch (npcState)
        {
            case NpcState.WalkingState:
                
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, target.position) <= 0.2f)
                {
                    GetNextWayPoint();
                }
                if (wavePointIndex >= WayPoints.points.Length - 2)
                {
                    npcState = NpcState.ScanningState;
                    return;
                }
                Debug.Log($"{npcState}");
                break;
            case NpcState.ScanningState:
                if (scanned)
                {
                    npcState = NpcState.WaitingState;
                    denied = false;
                    approved = false;
                }
                Debug.Log($"{npcState}");
                break;
            case NpcState.WaitingState:
                if (denied)
                {
                    npcState = NpcState.RejectedState;
                }
                if (approved)
                {
                    npcState = NpcState.ApprovedState;
                }
                Debug.Log($"{npcState}");
                break;
            case NpcState.ApprovedState:

                wavePointIndex = 2;
                target = WayPoints.points[wavePointIndex];
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

                Invoke("DestroyPrefab",2);
                
                
               
                Debug.Log($"{npcState}");
                break;
            case NpcState.RejectedState:

                
                wavePointIndex = 3;
                target = WayPoints.points[wavePointIndex];
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


                Invoke("DestroyPrefab", 2);

                Debug.Log($"{npcState}");
                break;
            default:
                break;
        }

        //if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        //{
        //    GetNextWayPoint();
        //}
    }
    private void DestroyPrefab()
    {
        Destroy(gameObject);
        if (wavePointIndex >= WayPoints.points.Length - 2 || wavePointIndex >= WayPoints.points.Length - 3)
        {

            spawn.SpawnNPC();
            return;
        }
    }

    public void GetNextWayPoint()
    {
        if (wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }
}
