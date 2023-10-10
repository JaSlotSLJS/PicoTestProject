using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    int targetPoint;
    float speed = 3;
    public bool approved = false;
    public bool denied = false;
    public bool scanned = false;
    NpcState npcState;

    enum NpcState
    {
        goingToThedesk,
        ScanningMicrochip,
        waitForApproval,
        accepted,
        Rejected,

    }
    // Start is called before the first frame update
    void Start()
    {
        npcState = NpcState.goingToThedesk;
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (npcState)
        {
            case NpcState.goingToThedesk:
                
                if (transform.position == patrolPoints[targetPoint].position /*&& targetPoint != patrolPoints.Length - 3*/)
                {
                    transform.Rotate(Vector3.up, 90);
                    IncreaseTargetInt();
                }
                if (transform.position == patrolPoints[1].position)
                {
                    npcState = NpcState.ScanningMicrochip;
                }
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
                Debug.Log($"{npcState}");
                break;
            case NpcState.ScanningMicrochip:
                if (scanned)
                {
                    npcState = NpcState.waitForApproval;
                }
                Debug.Log($"{npcState}");
                break;
            case NpcState.waitForApproval:

                /*
                    Animation of showing the microchip
                */
                if (approved)
                {
                    npcState = NpcState.accepted;
                    approved = false;
                }
                if (denied)
                {
                    npcState = NpcState.Rejected;
                    denied = false;
                }
                Debug.Log($"{npcState}");
                break;
            case NpcState.accepted:
                targetPoint = 3;
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

                Debug.Log($"{npcState}");
                break;
            case NpcState.Rejected:
                targetPoint = 2;
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

                Debug.Log($"{npcState}");
                break;
            default:
                break;
        }
        //    if (transform.position == patrolPoints[targetPoint].position && targetPoint != patrolPoints.Length -3)
        //    {
        //        IncreaseTargetInt();
        //    }
        //    else
        //    {
        //        if (approved)
        //        {
        //            denied = false;
        //            targetPoint = 3;
        //            approved = false;

        //        }
        //        else if (denied)
        //        {
        //            approved = false;
        //            targetPoint = 2;
        //            denied = false;
        //        }

        //    }
        //    transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    public void IncreaseTargetInt()
    {
        targetPoint++;
    }
}
