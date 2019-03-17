using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    [SerializeField] private float _speed;


    private float _checkPoint;
    private RectTransform _rec;

    private void Awake()
    {
        _checkPoint = 0f;
        _rec = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    private void Update()
    {
        if (_rec.offsetMax.y <= _checkPoint)
        {
            _rec.offsetMax += new Vector2(_rec.offsetMax.x, _speed);
        }
    }
}
