using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    [SerializeField] private float _zoomValue;

    private float currentScale;

    private void OnMouseDown()
    {
        currentScale = transform.localScale.x + _zoomValue;
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
	}

    private void OnMouseUp()
    {
        currentScale = transform.localScale.x - _zoomValue;
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }


}
