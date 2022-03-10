using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public HealthBase[] TargetGroup = null;
    public float baseDamage = 25;
    //public int Resolve = 100;
    float runSpeed = 50f;
    bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running) { 
            transform.position += new Vector3(runSpeed, 0, 0);

            if(transform.position.x > 1100)
                Destroy(gameObject, 0.5f);
        }
    }

    public void BaseAttack(float damage = 25)
    {
        //apply base Damage to list of targets
        if (TargetGroup != null)
        {
            foreach (HealthBase target in TargetGroup)
            {
                Debug.Log(this.name + " deals " + damage + " damage to " + target);
                target.TakeDamage(damage);
            }

            ClearTargets();
        }
        else
        {
            Debug.Log(this.name + " target's group is null!");
        }
    }

    public void AddTarget(HealthBase target)
    {
        //TargetGroup.Add(target);
        TargetGroup = new HealthBase[1];
        TargetGroup[0] = target;
    }

    void ClearTargets()
    {
        //TargetGroup.Clear();
        TargetGroup = null;
    }

    public void RunAway()
    {
        running = true;
        //TODO: More Elaborate Run away effect
        /*
        //move the enemy stage right until offscreen
        while (transform.position.x < 2000)
            transform.position += new Vector3(runSpeed, 0, 0);

        //destroy the enemy
        Destroy(gameObject, 0.5f);
        */
    }
}
