﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectTap : MonoBehaviour
{
    [SerializeField] private Text _playText;
    [SerializeField] private Text _gameName;
    [SerializeField] private GameObject _tor;
    [SerializeField] private GameObject _gameManager;

    private bool _clicked;
    private Animation _animation;
    private Animation[] _childsTor;
    private RectTransform _rec;
    private BoxCollider _boxCollider;

    private const string _startGameAnimationText = "StartGame";
    private const string _thornsAnimationText = "Thorns";

    //private GameManager gameManagerClass;
    
    private void Awake()
    {
        _childsTor = _tor.GetComponentsInChildren<Animation>();
        _rec = _gameName.gameObject.GetComponent<RectTransform>();
        _animation = _tor.GetComponent<Animation>();
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.size = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 1);
    }

    private void OnMouseDown()
    {
        Debug.Log("Detect TAP");

        _playText.gameObject.SetActive(false);
        _gameName.gameObject.SetActive(false);
        
        var offsetMax = _rec.offsetMax;
        _rec.offsetMin += new Vector2(offsetMax.x, _gameName.fontSize * offsetMax.y);
        
        _animation.CrossFade(_startGameAnimationText,0.5f);

        StartCoroutine(start());

        _boxCollider.enabled = false;
    }

    private IEnumerator start()
    {
        StartAnimationThorns();
        yield return new WaitForSeconds(_animation[_startGameAnimationText].length);
        GameManager.instance.StartGame();
    }

    private void StartAnimationThorns()
    {       
        foreach (var i in _childsTor)
        {
            if(i.GetClip(_thornsAnimationText) != null)
                i.Play(_thornsAnimationText);
        }
    }


}
