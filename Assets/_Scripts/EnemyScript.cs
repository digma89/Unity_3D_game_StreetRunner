using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    private Transform Player;
    public NavMeshAgent Agent;

    // Use this for initialization
    void Start()
    {
        this.Player = GameObject.FindWithTag("Player").transform;
        this.GetComponent<Animator>().speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        this.Agent.SetDestination(this.Player.position);
    }
 
}
