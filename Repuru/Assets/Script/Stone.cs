using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private Rigidbody _rb;
    private bool _throwing = true;

	// Use this for initialization
	void Start () {
		_rb = GetComponent < Rigidbody > ();
	}
	
	// Update is called once per frame
	void Update () {
        if (_throwing == true) {
            _rb.AddForce (transform.forward * 200f);
            _rb.AddForce (transform.up * 300f);
            _throwing = false;
        }
	}

    private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Stage") {
            Debug.Log ("パン！");
            Invoke ("Delete", 1f);
        }
    }

    private void Delete () {
        Destroy (this.gameObject);
    }
}
