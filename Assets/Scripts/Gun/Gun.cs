using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootPoint;
    public void Shoot()
    {
        Bullet bullet = Instantiate(_prefab,_shootPoint.position,Quaternion.identity);
        bullet.transform.rotation = Quaternion.Euler(0, _shootPoint.rotation.eulerAngles.y,0);
    }
}
