using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpot : MonoBehaviour
{
    [FormerlySerializedAs("Enemys")] [SerializeField] public List<Enemy> EnemyList = new List<Enemy>();
    public event Action SpotIsClearEvent;
    void Start()
    {
        foreach (var vEnemy in EnemyList)
        {
            vEnemy.DieEvent += SpotIsClear;
        }
    }
    
    void SpotIsClear()
    {
        
        EnemyList.Remove(EnemyList[0]);
        if (EnemyList.Count < 1)
        {
            Debug.Log("Переход к следующей точке");
            SpotIsClearEvent?.Invoke();
        }
    }
}
