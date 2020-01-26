using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{

    public Transform target;
    private NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.Warp(this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            print(agent.isOnNavMesh);
            print(target.position);
            agent.SetDestination(target.position);
        }

    }
}
