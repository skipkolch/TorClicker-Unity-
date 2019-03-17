using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private float _shake;
    [SerializeField] private float _scaleSpeed;
    [SerializeField] private GameObject _boom;

    private bool _bang;

    private Vector3 _maxScale;
    private void Awake()
    {
        _bang = false;
        _maxScale = new Vector3(400,400,400);
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        UpScale();     
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEvent");
        
        if(!_bang)
            Boom();
    }

    private void Boom()
    {   
        #if UNITY_ANDROID
            Handheld.Vibrate();
            
        #endif
        
        GameManager.instance.shake = _shake;
        GameManager.instance.lives--;
        GameManager.instance.readyToSpawn = true;
        _bang = true;
        Destroy(gameObject);
    }

    private void UpScale()
    {
        var localScale = transform.localScale;
        localScale = Vector3.Lerp(localScale, 2*_maxScale, _scaleSpeed * Time.deltaTime);
        transform.localScale = localScale;
    }
}
