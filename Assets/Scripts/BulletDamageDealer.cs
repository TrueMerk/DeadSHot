using UnityEngine;

public class BulletDamageDealer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("destroy");
        this.gameObject.SetActive(false);
    }
}
