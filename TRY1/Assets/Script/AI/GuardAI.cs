using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navmesh;
    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.destination = player.transform.position;
    }
}
