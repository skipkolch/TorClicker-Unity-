using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButtons : MonoBehaviour {

    public float _speed = 5f;

    private RectTransform rec;
    private float _checkPosition;

    private float moveDown;

    private bool onPlace;
    void Start ()
    {
        rec = GetComponent<RectTransform>();
        _checkPosition = 0f;

        moveDown = -Screen.height / 2;
        onPlace = false;
    }

    public void setCheckPosition(float position)
    {
        _checkPosition = position;
    }

    public bool checkPosition()
    {
        return onPlace;
    }

    // Update is called once per frame
    void Update ()
    {

        if (Mathf.Round(rec.offsetMax.x) != 0)
        {
            rec.offsetMax = new Vector2(Mathf.Lerp(rec.offsetMax.x, 0, Time.time * _speed / 100), rec.offsetMax.y);
            rec.offsetMin = new Vector2(Mathf.Lerp(rec.offsetMin.x, 0, Time.time * _speed / 100), rec.offsetMin.y);
        }
        else
            onPlace = true;

        if(_speed < 0)
        {
            rec.offsetMax = new Vector2( rec.offsetMax.x, Mathf.Lerp(rec.offsetMax.y, moveDown, Time.time * (-1) * _speed / 200));
            rec.offsetMin = new Vector2(rec.offsetMin.x, Mathf.Lerp(rec.offsetMin.y, moveDown, Time.time * (-1) * _speed / 200));
        }
    }
}
