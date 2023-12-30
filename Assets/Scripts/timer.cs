using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _timerText;
    
    [SerializeField] 
    private float _remainingTime;

    private int minutes;
    private int seconds;

    void FixedUpdate()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -=Time.deltaTime;
        }
        else if(_remainingTime < 0)
        {
            _remainingTime = 0;
            _timerText.color = Color.red;
            SceneManager.LoadScene("GameOver");
        }
        
        minutes = Mathf.FloorToInt(_remainingTime / 60);
        seconds = Mathf.FloorToInt(_remainingTime % 60);
        _timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
