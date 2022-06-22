using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class Pool<T> where T: MonoBehaviour
{
   private T _bullPrefab;
   public bool autoExpand = true;
   private Transform _container;

   private List<T> _pool;

   public Pool(T bullPrefab, int count)
   {
      this._bullPrefab = bullPrefab;
      this._container = null;
      
      this.CreatePool(count);
   }

   public Pool(T bullPrefab, int count, Transform container)
   {
      this._bullPrefab = bullPrefab;
      this._container = container;
      
      this.CreatePool(count);
   }

   private void CreatePool(int count)
   {
       this._pool = new List<T>();

       for (var i = 0; i < count; i++)
       {
          this.CreateObject();
       }
   }

   private T CreateObject(bool isActiveByDefault = false)
   {
      var createdObject = Object.Instantiate(this._bullPrefab, this._container);
      createdObject.gameObject.SetActive(isActiveByDefault);
      this._pool.Add(createdObject);
      return createdObject;
   }

   private bool HasFreeElement(out T element)
   {
      foreach (var mono in _pool.Where(mono => !mono.gameObject.activeInHierarchy))
      {
         element = mono;
         mono.gameObject.SetActive(true);
         return true;
      }
      element = null;
      return false;
   }

   public T GetFreeElement()
   {
      if (this.HasFreeElement(out var element))
         return element;
      if (this.autoExpand)
         return this.CreateObject(true);

      throw new Exception("No free GameObjects in pool");
   }
}
