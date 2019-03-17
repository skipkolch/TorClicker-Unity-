using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    public float _speed; 

    public Transform[] _childsTransform;

    private Vector3 _startScale;
    private Vector3 _maxScale;

    private void Start()
    {
        _startScale = _childsTransform[0].localScale;   
    }

    // Update is called once per frame
    private void Update()
    {
        foreach(var child in _childsTransform)
        {
            child.localScale += new Vector3(0, 0, _speed * Time.deltaTime);
        }
    }
}
