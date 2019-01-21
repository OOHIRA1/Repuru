using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStone : MonoBehaviour {

    [SerializeField] private Transform _attackSpace;
    [SerializeField] private GameObject _stone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Instantiate (_stone, _attackSpace.position, _attackSpace.rotation);
        }
	}
}
