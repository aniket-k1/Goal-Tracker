using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManagerScript : MonoBehaviour {

	// UI Elements
	public GameObject mainCanvas;
	public GameObject chooseCanvas;
	public GameObject recurringCanvas;
	public GameObject oneTimeCanvas;

	// Assets
	public GameObject house1;
	public GameObject house2;
	public GameObject house3;
	public GameObject house4;
	public ParticleSystem particles;

	// Extra
	public double currentValue;
	public bool isTransitioning;
	private Vector3 shrinkScaleVector;
	private Vector3 normalizedScaleVector;

	// Use this for initialization
	void Start () {
		if (particles.isPlaying) {
			particles.Stop ();
		}

		shrinkScaleVector = new Vector3(0.01f,0.01f,0.01f);
		normalizedScaleVector = new Vector3(45.0f,45.0f,45.0f);

		// Initial UI state
		mainCanvas.SetActive (true);
		chooseCanvas.SetActive (false);
		recurringCanvas.SetActive (false);
		oneTimeCanvas.SetActive (false);

		// Initial Object state
		growHouse (ref house1);
		shrinkHouse (ref house2);
		shrinkHouse (ref house3);
		shrinkHouse (ref house4);
	}

	// Update is called once per frame
	void Update () {

	}

	private void shrinkHouse(ref GameObject house){
		house.transform.localScale = Vector3.Lerp (normalizedScaleVector, shrinkScaleVector, 1000); 
	}

	private void growHouse(ref GameObject house){
		house.transform.localScale = Vector3.Lerp (shrinkScaleVector, normalizedScaleVector, 1000);
	}

	public void openGoal() {
		mainCanvas.SetActive (false);
		chooseCanvas.SetActive (true);
	}

	public void closeGoal() {
		mainCanvas.SetActive (true);
		chooseCanvas.SetActive (false);

		if (particles.isPlaying) {
			particles.Stop ();
		}
		particles.Play ();

		shrinkHouse(ref house1);
		growHouse(ref house2);
	}

	public void openRecurring() {
		mainCanvas.SetActive (false);
		recurringCanvas.SetActive (true);
	}

	public void closeRecurring() {
		mainCanvas.SetActive (true);
		recurringCanvas.SetActive (false);

		if (particles.isPlaying) {
			particles.Stop ();
		}
		particles.Play ();

		shrinkHouse(ref house2);
		growHouse(ref house3);
	}

	public void openOneTime() {
		oneTimeCanvas.SetActive (true);
	}

	public void closeOneTime() {
		oneTimeCanvas.SetActive (false);

		if (particles.isPlaying) {
			particles.Stop ();
		}
		particles.Play ();

		shrinkHouse(ref house3);
		growHouse(ref house4);
	}
}