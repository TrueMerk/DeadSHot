using System.Collections;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    
    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
        var transform1 = transform;
        _rigidbody.velocity = transform1.rotation * Vector3.forward * _speed;
        transform1.rotation = GetComponentInParent<Transform>().rotation;
        
    }
    
    private void OnDisable()
    {
        var transform1 = transform;
        _rigidbody.velocity = transform1.rotation * Vector3.forward * 0;
        if(GetComponentInParent<Transform>() != null)
            transform1.position = GetComponentInParent<Transform>().position;
      
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(this._lifeTime);
        this.gameObject.SetActive(false);
    }
}