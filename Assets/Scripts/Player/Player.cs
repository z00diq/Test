using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private float _endLevelHeight;

    private Rigidbody _rigidbody;

    public event UnityAction<Player> Die;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shoot");
            _gun.Shoot();
        }

        if (transform.position.y <= _endLevelHeight)
            Die?.Invoke(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            _rigidbody.AddForce(bullet.transform.forward*bullet.KinematicEnergy);
        }
    }
   
}
