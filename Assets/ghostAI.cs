using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ghostAI : MonoBehaviour
{
    enum GhostState
    {
        WANDER,
        CHASE,
        RETURN
    };

    public GameObject player;
    private Vector3 startPosition;

    GhostState state = GhostState.WANDER;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        bool cherry= player.GetComponent<CherryCollection>().collected;
        if(cherry){
            state = GhostState.RETURN;
        }

        if(state == GhostState.WANDER){
            if(agent.remainingDistance <= 1.0f){
                float x = Random.Range(-75.0f,75.0f);
                float z = Random.Range(-75.0f,75.0f);
                agent.destination = new Vector3(x,0,z);


            }
        }
        else if(state == GhostState.CHASE){
            agent.destination = player.transform.position;
        }

        else if(state == GhostState.RETURN){
            agent.destination = startPosition;
             if(agent.remainingDistance <= 1.0f){
                state = GhostState.WANDER;
            }
        }
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player"){
            state = GhostState.CHASE;
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
    if(other.gameObject.name == "Player"){
        state = GhostState.WANDER;
        
    }
    }
}
