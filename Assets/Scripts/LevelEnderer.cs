using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnderer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private FinishPlace[] _finishPlaces;
    
    private int _enemyCount;
    private EnemyHealth[] _enemies; 

    private void Start()
    {
        _enemies= FindObjectsOfType<EnemyHealth>();
        _enemyCount = _enemies.Length;

        foreach (EnemyHealth enemy in _enemies)
            enemy.Die += OnEnemyDie;

        foreach (FinishPlace finishPlace in _finishPlaces)
            finishPlace.FinishReached += OnFinishReached;

        _player.Die += OnPlayerDie;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    private void OnEnemyDie(EnemyHealth enemy)
    {
        enemy.Die -= OnEnemyDie;
        Destroy(enemy.gameObject);
        _enemyCount--;
    }

    private void OnFinishReached(FinishPlace finish)
    {
        finish.FinishReached -= OnFinishReached;
        Debug.Log("Player Win");
        RestartLevel();
    }

    private void OnPlayerDie(Player player)
    {
        player.Die -= OnPlayerDie;
        Debug.Log("Player Die");
        RestartLevel();
    }
}
