using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyBase))]
public class EnemyResources : HealthBase, IScareable<int>
{
    public event Action<int> Scared = delegate { };

    public int Resolve = 100;
    //float runSpeed = 10f;
    [SerializeField] EnemyBase eb = null;

    public virtual void ReduceResolve(int reduceAmount)
    {
        Scared.Invoke(reduceAmount);

        Resolve -= reduceAmount;
        Debug.Log("EnemyBase: " + this.name + "'s resolve reduced to " + Resolve);

        if (Resolve <= 0)
        {
            eb.RunAway(); //call run away method in enemybase
        }
    }
    /*
    public void RunAway()
    {
        //TODO: More Elaborate Run away effect

        //move the enemy stage right until offscreen
        while (transform.position.x < 2000)
            transform.position += new Vector3(runSpeed, 0, 0);

        //destroy the enemy
        Destroy(gameObject, 0.5f);
    }
    */
}
