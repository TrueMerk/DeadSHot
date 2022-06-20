using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    private PlayerMover _mover;
    
    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _mover.LevelCompleteEvent += LevelComplete;
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
