using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectAnim : MonoBehaviour {
    [SerializeField] GameObject backGround2 = null;
    Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackGround2Display() {
        backGround2.SetActive(true);
    }


}
