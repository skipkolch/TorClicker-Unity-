using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera main;
    [SerializeField] private Text _textTimer;
    [SerializeField] private Text _resultGame;
    [SerializeField] private GameObject _salute;
    [SerializeField] private GameObject _timer;
    [SerializeField] private Transform _tor;
    [SerializeField] private GameObject _sphere;
    [SerializeField] private float shakeAmount = 0.7f;
    [SerializeField] private float decreaseFactor = 1.0f;    
    [SerializeField] private GameObject _hearts;
    [SerializeField] private GameObject[] _heartIcons;
    [SerializeField] private GameObject _exitScreen;
 
    private Timer _currentTimer;
    private int _timerTextSize;  
    private float _minimumTime = 10f;
    private bool gameStarted;
    private bool _win;
    private bool _isStartPulsar;
    private Vector3 _beginCameraPosition;
    private GameObject _currentSphere;
    
    [HideInInspector] public bool readyToSpawn; 
    [HideInInspector] public int lives;   
    [HideInInspector] public float shake; 
    
    public static GameManager instance = null;

    private void Awake()
    {
        gameStarted = false;
        _isStartPulsar = false;
        _beginCameraPosition = main.transform.localPosition;
                    
        _currentTimer = _timer.GetComponent<Timer>();

        _timerTextSize = _textTimer.fontSize;
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    
    public void StartGame()
    {
        gameStarted = true;
        readyToSpawn = true;
        
        lives = _heartIcons.Length;
        
        _timer.SetActive(true);
        _hearts.SetActive(true);
        _textTimer.gameObject.SetActive(true);
        
        _currentTimer.StartTimer();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameStarted) return;

        Debug.Log("Can spawn: " + readyToSpawn);
        
        LivesTracking();
        Spawner();
        ScreenShake();
        TimerUpdate();
    }

    private void Spawner()
    {
        if (!readyToSpawn) return;
        _currentSphere = Instantiate(_sphere, _tor.position, Quaternion.Euler(-90,0,0));
        readyToSpawn = false;
    }

    private void StartPulsarTimer()
    {
       _textTimer.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo);
       _textTimer.gameObject.GetComponent<RectTransform>().DOScale(new Vector3(1.5f, 1.5f), 0.5f).SetLoops(-1, LoopType.Yoyo);
       //_textTimer.fontSize = Convert.ToInt32(Mathf.Lerp(_timerTextSize, 1.5f*_timerTextSize, Mathf.PingPong(Time.time, 0.5f)));
    }

    private void TimerUpdate()
    {
        _textTimer.text = _currentTimer.ToString();

        if (_currentTimer.GetTime <= 10f && _currentTimer.IsStarted && !_isStartPulsar)
        {
            StartPulsarTimer();
            _isStartPulsar = true;
        }

        if (_currentTimer.GetTime <= 0f)
        {
            _currentTimer.StopTimer();
            if (lives > 0)
            {
                _win = true;
                StartCoroutine(gameOver());
            }
        }
    }
    
    private void ScreenShake()
    {
        if (shake > 0)
        {
            var rand = Random.insideUnitSphere * shakeAmount;
            main.transform.localPosition = new Vector3(rand.x,rand.y,0);
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
            main.transform.localPosition = _beginCameraPosition;
        }

    }
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    private void LivesTracking()
    {
        Debug.Log("LIVES: " + lives);
        switch (lives)
        {
            case 2:
                _heartIcons[lives].SetActive(false);
                break;
            case 1:
                _heartIcons[lives].SetActive(false);
                break;
            case 0:
                _heartIcons[lives].SetActive(false);
                _win = false;
                StartCoroutine(gameOver());
                break;
        }
    }

    private IEnumerator gameOver()
    {
        #if UNITY_ANDROID
            Handheld.Vibrate();    
        #endif
            
        Destroy(_currentSphere);
        readyToSpawn = false;
        StopAnimationThorns();
        _textTimer.gameObject.SetActive(false);
        _hearts.SetActive(false);
        
        yield return new WaitForSeconds(0.5f);
        
        gameStarted = false;
        
        if (_win)
        {
            _resultGame.text = "You win!";
            _salute.SetActive(true);  
        }
        else _resultGame.text = "Game Over";
        
        _exitScreen.SetActive(true);
    }


    private void StopAnimationThorns()
    {
        var thorns = _tor.gameObject.GetComponentsInChildren<Animation>();

        foreach (var i in thorns)
            i.Stop();
    }
}
