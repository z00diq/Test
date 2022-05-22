using UnityEngine;
using UnityEngine.Events;

public class FinishPlace : MonoBehaviour
{
    public event UnityAction<FinishPlace> FinishReached;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            FinishReached?.Invoke(this);
        }
    }
}
