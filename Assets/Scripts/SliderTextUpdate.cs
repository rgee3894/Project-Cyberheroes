using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextUpdate : MonoBehaviour {

    Text percentageText;

	// Use this for initialization
	void Start () {
        percentageText = GetComponent<Text>();
        percentageText.text = "X2";

    }
	
	// Update is called once per frame
	public void textUpdate (float value) {
        percentageText.text = "X"+Mathf.RoundToInt(value) ;
	}
}
