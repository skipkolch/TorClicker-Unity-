using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    private Text _tapText;
    private Outline _oLine;
    
    
    private void Awake()
    {
        _tapText = GetComponent<Text>();
        _oLine = GetComponent<Outline>();
    }

    private void Start()
    {
        _tapText.DOFade(0, 1.5f).SetLoops(-1, LoopType.Yoyo);
        _oLine.DOFade(0, 1.5f).SetLoops(-1, LoopType.Yoyo);
    }

}
