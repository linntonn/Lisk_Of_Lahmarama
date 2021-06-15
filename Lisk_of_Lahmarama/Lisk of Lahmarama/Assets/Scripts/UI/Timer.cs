using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeLeft = 60;
    public Text countdownText;

    void Start()
    {
        StartCoroutine("LoseTime");
    }


    void Update()
    {
        countdownText.text = ("Timer: " + timeLeft / 60 + ":");
        if (timeLeft % 60 == 0)
        {
            countdownText.text += ("0");
        }
        else if (timeLeft % 60 > 0 && timeLeft % 60 < 10)
        {
            countdownText.text += ("0");
        }
        countdownText.text += (timeLeft % 60);
        if (timeLeft <= 0)
        {
        
        }

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}