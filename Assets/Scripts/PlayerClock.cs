using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClock : MonoBehaviour {

    Text clockText;
    float timeRemaining = 15;
	// Use this for initialization
	void Start () {
        clockText = GetComponent<Text>();
        clockText.text = Mathf.RoundToInt(timeRemaining) + "";
    }
	
	// Update is called once per frame
	void Update () {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            clockText.text = Mathf.RoundToInt(timeRemaining) + "";
        }
        else
        {
            //over
        }
	}

}
