using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 move=new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))*_speed*Time.deltaTime;
        transform.Translate(move);
    }
}
