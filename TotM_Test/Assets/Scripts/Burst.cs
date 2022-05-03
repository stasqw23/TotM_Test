using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burst : MonoBehaviour
{
    [SerializeField] private Button _burstButton;
    [SerializeField] private float _burstTime;
    [SerializeField] private float _burstPercent;
    [SerializeField] private Image _kdButton;
    private bool _flagBurst = true;
    private float _elapsedTime;

    void Start()
    {
        _burstButton.onClick.AddListener(BurstStart);  
    }

    void Update()
    {
        KdButton();
    }

    private void BurstStart()
    {
        if(_flagBurst)
        {
            StartCoroutine(BurstTime());
        }
    }
    private void KdButton()
    {
        if (_kdButton.fillAmount!=0)
        {
           _elapsedTime += Time.deltaTime;
           var speedAnimation = _elapsedTime/ _burstTime;
            _kdButton.fillAmount = Mathf.MoveTowards(1,0,speedAnimation);
        }
        else
        {
            _elapsedTime = 0;
        }
    }
    IEnumerator BurstTime()
    {
        _flagBurst = false;
        _kdButton.fillAmount = 1;
        Time.timeScale = _burstPercent;
        Time.fixedDeltaTime = _burstPercent * 0.02f;
        yield return new WaitForSeconds(_burstTime);
        _flagBurst = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        yield return null;
    }
}
