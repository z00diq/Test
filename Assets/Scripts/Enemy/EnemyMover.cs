using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _time;
    
    private Rigidbody _rigidboy;
    private float ellapsedTime=0;
    private Collider _collider;
    private Vector3 _movment = Vector3.right;
    private RaycastHit _hit;
    private Ray _ray;
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _ray.origin = transform.position;
        _rigidboy = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        if (_speed == 0)
            return;

        ellapsedTime += Time.deltaTime;

        if (ellapsedTime > _time)
        {
            _movment = -_movment;
            ellapsedTime = 0;
        }
        
    }

    private void FixedUpdate()
    {
        if(_rigidboy.SweepTest(_movment,out _hit, _movment.magnitude * _speed))
        {
            _rigidboy.MovePosition(_movment * _speed);
        }
            
    }
}
