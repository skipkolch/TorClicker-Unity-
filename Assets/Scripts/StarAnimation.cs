using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public float _lifeTime = 20f;
    public float _speed = 40f;

    private SpriteRenderer _star;

    private void Start()
    {
        _star = GetComponent<SpriteRenderer>();

        var _target = transform.position + (transform.up * _speed);
        
        transform.DOMove( new Vector3(_target.x,_target.y, transform.position.z) , 5 * _lifeTime);
        _star.DOFade(1f, _lifeTime / 4f).SetLoops(4,LoopType.Yoyo);    
        
        Destroy(gameObject,_lifeTime);
    }

}
