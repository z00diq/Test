using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _kinematicEnergy = 300;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _effectPrefab;

    private Rigidbody _rigidbody;

    public float KinematicEnergy => _kinematicEnergy;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward*_speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            Debug.Log("Agent hitted"); 
            enemyHealth.TakeDamage(_damage);
        }

        var effect = Instantiate(_effectPrefab, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

}
