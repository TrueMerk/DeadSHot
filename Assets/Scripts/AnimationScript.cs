using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator _animation;
    void Start()
    {
        _animation = GetComponent<Animator>();
    }
    
    void Update()
    {
        _animation.SetFloat("Speed",GetComponent<PlayerMover>().speed);
    }
}
