using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour {

	public GameObject main;
	public GameObject secondary;

	// Use this for initialization
	void Start () {
		main.SetActive (true);
		secondary.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goalButtonPress() {
		main.SetActive (false);
		secondary.SetActive (true);
	}

	public void chooseGoalOK() {
		main.SetActive (true);
		secondary.SetActive (false);
	}
}
