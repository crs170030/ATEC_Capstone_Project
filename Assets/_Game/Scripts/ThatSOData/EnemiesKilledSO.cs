using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemiesKilledSO : ScriptableObject
{
    /*
    [SerializeField]
    private int[] _enemiesKilled;

    public int[] EnemiesKilled
    {
        get { return _enemiesKilled; }
        set { _enemiesKilled = value; }
    }
    */
    [SerializeField]
    private ArrayList _enemiesKilled;

    public ArrayList EnemiesKilled
    {
        get { return _enemiesKilled; }
        set { _enemiesKilled = value; }
    }
}
