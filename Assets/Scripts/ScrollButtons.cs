using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScrollButtons : MonoBehaviour {

    public float _duration = 5f;

    private RectTransform _rec;
    private float _moveDown;
    private bool _onPlace;

    private void Start ()
    {
        _rec = GetComponent<RectTransform>();
        _onPlace = false;
        
        _rec.DOAnchorPos(Vector2.zero, _duration, false).OnComplete(() =>
        {
            _onPlace = true;
        });
        
    }

    public bool checkPosition()
    {
        return _onPlace;
    }

}
