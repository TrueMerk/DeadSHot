using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpot : MonoBehaviour
{
    [SerializeField] public List<Enemy> Enemys = new List<Enemy>();
    public event Action SpotIsClearEvent;
    void Start()
    {
        foreach (var vEnemy in Enemys)
        {
            vEnemy.DieEvent += SpotIsClear;
        }
    }
    
    void SpotIsClear()
    {
        
        Enemys.Remove(Enemys[0]);
        if (Enemys.Count < 1)
        {
            Debug.Log("Переход к следующей точке");
            SpotIsClearEvent?.Invoke();
        }
    }
}
