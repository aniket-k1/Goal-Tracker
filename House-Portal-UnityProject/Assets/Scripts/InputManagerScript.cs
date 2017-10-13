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
	public GameObject particles;

	// Extra
	private ParticleSystem inputManagerParticleSystem;
	public double currentValue;
	public bool isTransitioning;
	private Vector3 shrinkScaleVector; //= Vector3(0.001,0.001,0.001);
	private Vector3 normalizedScaleVector; // = Vector3(1.0,1.0,1.0);

	// Use this for initialization
	void Start () {
		inputManagerParticleSystem = particles.GetComponent<ParticleSystem> ();
		shrinkScaleVector = new Vector3(0.01f,0.01f,0.01f);
		normalizedScaleVector = new Vector3(1.0f,1.0f,1.0f);
		currentValue = 0;
		isTransitioning = false;

		shrinkAllHouses ();
		// Initial UI state
		mainCanvas.SetActive (true);
		chooseCanvas.SetActive (false);
		recurringCanvas.SetActive (false);
		oneTimeCanvas.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (isTransitioning) {
			//particleEmitter start
			inputManagerParticleSystem.Play();
			if(currentValue >= 0 && currentValue <= 5000){
				growHouse( ref house1);
			}else if(currentValue >= 5001 && currentValue <= 20000){
				shrinkHouse(ref house1);
				growHouse(ref house2);
			}else if(currentValue >= 20001 && currentValue <= 30000){
				shrinkHouse (ref house2);
				growHouse (ref house3);
			}else if(currentValue >= 30001 && currentValue <= 50000){
				shrinkHouse (ref house3);
				growHouse (ref house4);
			}
		}

	}

	private void shrinkHouse(ref GameObject house){
		house.transform.localScale = Vector3.Lerp (normalizedScaleVector, shrinkScaleVector, 1000); 
	}

	private void shrinkAllHouses(){
		shrinkHouse (ref house1);
		shrinkHouse (ref house2);
		shrinkHouse (ref house3);
		shrinkHouse (ref house4);

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
	}

	public void openRecurring() {
		mainCanvas.SetActive (false);
		recurringCanvas.SetActive (true);
	}

	public void closeRecurring() {
		mainCanvas.SetActive (true);
		recurringCanvas.SetActive (false);
	}

	public void openOneTime() {
		oneTimeCanvas.SetActive (true);
	}

	public void closeOneTime() {
		oneTimeCanvas.SetActive (false);
	}
}