using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public List<Transform> Destinations;
    public Transform currentTarget;
    NavMeshAgent agent;
    int i = 0;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update() {
        agent.destination = Destinations[i].position;
        var dist = Vector3.Distance(Destinations[i].position, transform.position);
        currentTarget = Destinations[i];
        
        if (dist < 100) {
            if (i < Destinations.Count - 1) {
                i++;
                agent.destination = Destinations[i].position;
            }
            else{
                if (agent.remainingDistance <= float.Epsilon) {
                    i = 0;
                }
            }
        }
    }
}
