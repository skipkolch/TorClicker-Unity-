using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{
    [SerializeField] private GameObject star;

    public float _timeSpawn = 5.01f;
    private bool _isCamera1NotNull;


    private void Start()
    {
        _isCamera1NotNull = Camera.main != null;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_isCamera1NotNull)
            {
                var pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 20));
                Instantiate(star, pos, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            }
            
            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
