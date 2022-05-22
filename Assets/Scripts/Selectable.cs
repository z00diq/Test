using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    private Color _current;
    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _current = _renderer.material.color;
    }

    public void Select()
    {
        _renderer.material.color = Color.yellow;
    }

    public void Deselect()
    {
        _renderer.material.color = _current;
    }
}