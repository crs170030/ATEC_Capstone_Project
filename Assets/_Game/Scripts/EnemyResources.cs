using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyBase))]
public class EnemyResources : HealthBase, IScareable<int>
{
    public event Action<int> Scared = delegate { };
    //public event Action<int> Infected = delegate { };

    [SerializeField] Image _enemyImage = null;
    
    public int Resolve = 100;
    public bool hasStatusEffect = false;
    public bool isInfected = false;
    //float runSpeed = 10f;
    [SerializeField] EnemyBase eb = null;

    void OnAwake()
    {
        //Infected += ChangeSprite;
    }

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

    public void ChangeSprite()
    {
        if (isInfected)
        {
            if(_enemyImage != null)
            {
                //change image color to green
                _enemyImage.color = new Color32(124, 198, 124, 255);
            }
        }
    }
}
