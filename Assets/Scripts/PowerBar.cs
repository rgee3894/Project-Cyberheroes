using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {
	private Image img;

	// Use this for initialization
	void Start () 
	{
		img = GetComponent<Image>();
		
	}

	public void correct()
	{
		img.color = Color.green;
	}

	public void wrong()
	{
		img.color = Color.red;
	}

	public void unanswered()
	{
		img.color = Color.gray;
	}
	

}
