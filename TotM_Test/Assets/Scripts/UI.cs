using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _play;
    [SerializeField] private Button _restartInPause;
    [SerializeField] private Button _restartInDeath;
    [SerializeField] private Button _restartInWin;
    [SerializeField] private GameObject _pauseMenu;
    void Start()
    {
        _pause.onClick.AddListener(Pause);
        _play.onClick.AddListener(Resrume);
        _restartInPause.onClick.AddListener(Restart);
        _restartInDeath.onClick.AddListener(Restart);
        _restartInWin.onClick.AddListener(Restart);

    }

    void Update()
    {
        
    }

    private void Pause()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }
    private void Resrume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;


    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;


    }
}
