using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator _animation;
    private PlayerMover _playerMover;
    private float _playerSpeed;
    void Start()
    {
        _animation = GetComponent<Animator>();
        _playerMover = GetComponent<PlayerMover>();
    }
    
    void Update()
    {
        _animation.SetFloat("Speed",_playerMover.speed);
    }
}
