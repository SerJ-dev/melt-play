using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.AI;
using UnityEngine;

public class RobotFolloweAI : MonoBehaviour
{
    public Transform FollowerBody; // тело робота
    public Transform PlayerBody;   // тело игрока
    public GameObject player;
    private NavMeshAgent navmesh;
    private float dist;
    public float FollowDist = 5;


    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        dist = Vector3.Distance(FollowerBody.position,PlayerBody.position);

        if (dist > FollowDist)
        {
            navmesh.destination = player.transform.position;
        }
    }
}
