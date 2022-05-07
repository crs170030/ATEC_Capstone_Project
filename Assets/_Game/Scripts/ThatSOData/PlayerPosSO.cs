using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerPosSO : ScriptableObject
{
    [SerializeField]
    private Vector3 _playerPosition;

    public Vector3 PlayerPosition
    {
        get { return _playerPosition; }
        set { _playerPosition = value; }
    }


    [SerializeField]
    private float _kazHealth;

    public float KazHealth
    {
        get { return _kazHealth; }
        set { _kazHealth = value; }
    }


    [SerializeField]
    private float _phoebeHealth;

    public float PhoebeHealth
    {
        get { return _phoebeHealth; }
        set { _phoebeHealth = value; }
    }


    [SerializeField]
    private float _monchHealth;

    public float MonchHealth
    {
        get { return _monchHealth; }
        set { _monchHealth = value; }
    }

}
