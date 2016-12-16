using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerShow : MonoBehaviour
{
    float timeLeft = 300.0f;
	public Text timer;

	void Update()
    {
		timeLeft -= Time.deltaTime;
		timer.text = "Time: " + Mathf.Round(timeLeft).ToString();
		Debug.Log (timeLeft);
        if (timeLeft <= 0)
        {
            Debug.Log("Timesup.");
            //Application.LoadLevel("gameOver");
        }
    }
}
