using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] float remainingTime;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -=Time.deltaTime;
        }
        else if(remainingTime < 0)
            {
            
            remainingTime = 1;
            timertext.color = Color.red;
            SceneManager.LoadScene("GameOver");
        }
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timertext.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
