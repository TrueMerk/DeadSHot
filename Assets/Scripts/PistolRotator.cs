using UnityEngine;

public class PistolRotator : MonoBehaviour
{
    
    [SerializeField]private float camSens = 0.05f; 
    private Vector3 _lastMouse = new Vector3(255, 300, 0); 
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            _lastMouse = Input.mousePosition - _lastMouse ;
            _lastMouse = new Vector3(0, _lastMouse.x * camSens, 0 );
            var eulerAngles = transform.eulerAngles;
            _lastMouse = new Vector3(0 , eulerAngles.y + _lastMouse.y, 0);
            eulerAngles = _lastMouse;
            transform.eulerAngles = eulerAngles;
            _lastMouse =  Input.mousePosition;
           
        }
    }
}
