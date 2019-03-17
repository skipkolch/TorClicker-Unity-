using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time = 15f;
    
    private bool _isStart = false;

    public float GetTime => _time;
    

    public bool IsStarted => _isStart;

    public void StartTimer()
    {
        Debug.Log("Timer is start!");
        _isStart = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isStart)
            _time -= Time.deltaTime;
    }

    public void StopTimer()
    {
        _isStart = false;
    }

    public override string ToString()
    {
        var strTime = Convert.ToString(Mathf.Round(_time));
        return strTime;
    }
}
