using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyOscillator : MonoBehaviour
{
    private const float Tau = Mathf.PI * 2;
    private const float Period = 5f; 

    [SerializeField] private float _speed;

    private float SinWave;
    private Vector3 _movment;
    private Rigidbody _rigidbody;
    private float _ellapsedTime = 0;
    private Ray _ray;


    private void Start()
    {
        _ray = new Ray(transform.position - transform.lossyScale / 2, _movment);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _ellapsedTime = Time.time / Period;
        SinWave = Mathf.Sin(_ellapsedTime * Tau);
        _movment = Vector3.right * SinWave*_speed;

        if(TryMovment())
            _rigidbody.velocity = _movment;

        
    }

    private bool TryMovment()
    {
        Vector3 rayOrigin = transform.position + _movment;
        _ray = new Ray(rayOrigin, Vector3.down);
        return Physics.Raycast(_ray, _movment.magnitude);
    }
}
