using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public float _lifeTime = 20f;
    public float _speed = 0.1f;

    private SpriteRenderer _star;

    private void Start()
    {
        _star = GetComponent<SpriteRenderer>();
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        _star.color = new Color(_star.color.r, _star.color.g, _star.color.b, Mathf.PingPong(2f * Time.time / _lifeTime, 1));

        // Move star
        transform.position += transform.up * Time.deltaTime * _speed;
    }
}
