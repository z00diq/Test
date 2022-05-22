using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _reloadTime;

    private float _ellapsedTime = 0;
    private Gun _gun;

    private void Start()
    {
        _gun = GetComponentInChildren<Gun>();
    }

    private void Update()
    {
        if (_gun == null)
            return;

        _ellapsedTime += Time.deltaTime;

        if (_ellapsedTime >= _reloadTime)
        {
            _ellapsedTime = 0;
            _gun.Shoot();
        }
    }
}
