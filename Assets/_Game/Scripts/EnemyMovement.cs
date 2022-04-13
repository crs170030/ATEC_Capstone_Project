using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 10f;
    [SerializeField] Animator animator = null;
    [SerializeField] LevelLoaderScript levelLoader = null;
    //Rigidbody _rb;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        //_rb = GetComponent<Rigidbody>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }

        //update animations
        //Debug.Log("nav mesh vel : " + agent.velocity.x);
        animator.SetInteger("xVelocity", (int) Mathf.Ceil(agent.velocity.x));
        animator.SetInteger("yVelocity", (int) Mathf.Ceil(agent.velocity.y));
    }

    void OnCollisionEnter(Collision other)
    {
        //detect if it's the player
        PlayerMovement _player = other.gameObject.GetComponent<PlayerMovement>();
        if (_player != null)
        {
            Debug.Log("Enemy has touched :" + _player.name);
            //play sound

            //save enemy data to battle data

            //tell the player to save their position

            //

            //load battle level
            //PlayerManager.EnterBattleState();
            levelLoader.LoadNextLevel(2);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
