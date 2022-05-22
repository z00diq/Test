using UnityEngine;

public class GunRay : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Ray _ray;
    private RaycastHit _hit;
    private Selectable _current;

    private void LateUpdate()
    {
        _ray = new Ray(transform.position, transform.up);
       
        if (Physics.Raycast(_ray,out _hit))
        {
            Selectable selectable = _hit.collider.gameObject.GetComponent<Selectable>();

            if (selectable)
            {
                if(_current && _current != selectable)
                    _current.Deselect();

                _current = selectable;
                selectable.Select();
            }
            else
            {
                if (_current)
                {
                    _current.Deselect();
                    _current = null;
                }
            }
        } 
        else
        {
            if (_current)
            {
                _current.Deselect();
                _current = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_ray.origin, _ray.direction * 20);
    }
}
