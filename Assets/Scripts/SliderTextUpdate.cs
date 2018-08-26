using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTextUpdate : MonoBehaviour {

    Text percentageText;
    public string operation;

    private int value=1;

	// Use this for initialization
	void Start () {
        percentageText = GetComponent<Text>();
    }

    void Update()
    {
        percentageText.text = operation+value;
    }
	
	// Update is called once per frame
	public void textUpdate (float value) {
        this.value = Mathf.RoundToInt(value);
	}
}
