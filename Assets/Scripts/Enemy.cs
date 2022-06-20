using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action DieEvent;
    
    private void OnDestroy()
    {
        DieEvent?.Invoke();
    }
    private void OnDisable()
    {
        //DieEvent?.Invoke();
    }
}
