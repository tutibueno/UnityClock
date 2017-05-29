using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	public Transform hour;
	public Transform minute;
	public Transform second;

	public Vector3 rotationVector = new Vector3(0, 0, 1);

	//For canvas clock only
	public RectTransform pinBase;
	public RectTransform pinHour;

	public bool isCanvasClock;

	// Use this for initialization
	void Start () {

		if (isCanvasClock)
			CreatePins();

		second.SetAsLastSibling();
		
	}

	bool automaticMotion;
	
	// Update is called once per frame
	void Update () {


		float f_hour = (float)System.DateTime.Now.Hour;

		float f_minute = (float)System.DateTime.Now.Minute;

		float f_second = (float)System.DateTime.Now.Second;

		float miliseconds = (float)System.DateTime.Now.Millisecond;


		float ang = 0;

		if(automaticMotion)
			f_second += (miliseconds/1000f);
		else
		{
			if(miliseconds < 32)
				ang += 1.5f;
		}

		hour.localEulerAngles = -rotationVector * ((f_hour+(f_minute/60)) /12)*360;

		minute.localEulerAngles = -rotationVector * (f_minute/60*360);

		second.localEulerAngles = -rotationVector * ((f_second/60*360) + ang);

		if(Input.GetKeyDown(KeyCode.Space))
			automaticMotion = !automaticMotion;

		
	}

	void CreatePins()
	{
		//cria os pins minutos
		for (int i = 0; i< 60; i++) {

			float rot = (float)i / 60 * 360;

			RectTransform rect = Instantiate<RectTransform>(pinBase, transform.position, Quaternion.Euler(0, 0, rot), transform);

		}

		//Pins hora
		for (int i = 0; i< 12; i++) {

			float rot = (float)i / 12 * 360;

			RectTransform rect = Instantiate<RectTransform>(pinHour, transform.position, Quaternion.Euler(0, 0, rot), transform);

		}
	}
}
