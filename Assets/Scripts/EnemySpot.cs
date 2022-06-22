using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpot : MonoBehaviour
{
    [FormerlySerializedAs("Enemys")] [SerializeField] public List<Enemy> enemys = new List<Enemy>();
    public event Action SpotIsClearEvent;
    void Start()
    {
        foreach (var vEnemy in enemys)
        {
            vEnemy.DieEvent += SpotIsClear;
        }
    }
    
    void SpotIsClear()
    {
        
        enemys.Remove(enemys[0]);
        if (enemys.Count < 1)
        {
            Debug.Log("Переход к следующей точке");
            SpotIsClearEvent?.Invoke();
        }
    }
}
