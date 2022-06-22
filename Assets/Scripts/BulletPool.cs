using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private BulletMover _bulletPrefab;
    [SerializeField] private Transform _shotDir;
    private Pool <BulletMover> _pool;

    private void Start()
    {
        this._pool = new Pool <BulletMover> (this._bulletPrefab, this._poolCount, this.transform)
        {
            AutoExpand = this._autoExpand
        };
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.CreateBullet();
        };
    }

    private void CreateBullet()
    {
        var bullet = this._pool.GetFreeElement();
        bullet.gameObject.transform.position = _shotDir.position;
    }
}
