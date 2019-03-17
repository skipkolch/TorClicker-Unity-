using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
        _tapText.color = new Color(_tapText.color.r,_tapText.color.g,_tapText.color.b, Mathf.PingPong(Time.time/2, 1f));
        _oLine.effectColor = new Color(_oLine.effectColor.r, _oLine.effectColor.g, _oLine.effectColor.b, _tapText.color.a);
    }
}
