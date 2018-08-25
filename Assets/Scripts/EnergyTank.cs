using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyTank : MonoBehaviour {

	public Slider slider;
	public Button minValue; 
	public Button maxValue;

	public Image directionArrow;

	public SliderTextUpdate answerSliderText;

	private bool isMultiplication;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	/*Highlights minValue as the current value and maxValue as the target value. Arrow points to the right.*/
	public void setupMultiplication()
	{
		directionArrow.transform.rotation = new Quaternion(0,0,0,0);
		answerSliderText.operation = "x";
		isMultiplication = true;
	}

	/*Highlights maxValue as the current value and minValue as the target value. Arrow points to the left.*/
	public void setupDivision()
	{
		directionArrow.transform.rotation = new Quaternion(0,0,180,0);
		answerSliderText.operation = "÷";
		isMultiplication = false;
	}


	public void setValue(int val)
	{
		slider.value = val;
	}

	public void setMin(int min)
	{
		slider.minValue = min;
		minValue.GetComponentInChildren<Text>().text = min+"";
	}

	public void setMax(int max)
	{
		slider.maxValue = max;
		maxValue.GetComponentInChildren<Text>().text = max+"";
	}


}
