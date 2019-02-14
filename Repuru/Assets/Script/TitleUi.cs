using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUi : MonoBehaviour {
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		
	}

	void Update () {
		if (Input.GetKey("z")) {
			TitleAnim ();
		}
	}

	public void TitleAnim(){
		animator.SetTrigger("Title");
	}

}
