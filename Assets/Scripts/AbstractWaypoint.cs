using System;
using UnityEngine;

 public abstract class AbstractWaypoint : MonoBehaviour
 {

  private int _enemyCounter;
  public event Action OnCompleteEvent;

  private void Update()
  {
   if (_enemyCounter < 1)
   {
    OnComplete();
   }
  }

  private void OnComplete()
  {
   OnCompleteEvent?.Invoke();
  }
 }
