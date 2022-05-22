using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    [SerializeField] Player _target;

    private void Update()
    {
        transform.LookAt(_target.transform);
    }
}
