using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private float _forseScale;
    [SerializeField] private int _maxCountClick;

    private int _countClick;

    private void Awake()
    {
        _countClick = 0;
        
    }

    private void OnMouseDown()
    {
        _countClick++;    

        if (_countClick % _maxCountClick == 0)
            _forseScale *= 0.95f;
        
        var localScale = transform.localScale; 
        localScale = new Vector3(localScale.x - _forseScale,localScale.y - _forseScale,localScale.z - _forseScale);
        transform.localScale = localScale;

        Logger();
    }

    private void Logger()
    {
        Debug.Log("Count click: " + _countClick);
        Debug.Log("Forse " + _forseScale);
        Debug.Log("LocalScale: " + transform.localScale);
    }
}
