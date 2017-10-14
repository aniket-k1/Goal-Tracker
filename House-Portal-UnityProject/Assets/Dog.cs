using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

	private Animation dogAnimation;


	// Use this for initialization
	void Start () {
		dogAnimation = GetComponent<Animation> ();

		if (!dogAnimation.isPlaying) {
			
			dogAnimation.Play ();
		
		
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!dogAnimation.isPlaying) {

			dogAnimation.Play ();
		}
	}
}
