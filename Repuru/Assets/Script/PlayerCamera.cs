using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField] private Transform player;   //追従対象プレイヤー

    [SerializeField] private float distance = 5.0f; //追従対象プレイヤーから距離
    [SerializeField] private Quaternion vRotation;  //カメラの垂直回転
    [SerializeField] public Quaternion hRotation;   //カメラの水平回転


	// Use this for initialization
	void Start () {

        vRotation = Quaternion.Euler(30, 0, 0);
        hRotation = Quaternion.identity;
        transform.rotation = hRotation * vRotation;

        transform.position = player.position - transform.rotation * Vector3.forward * distance;


	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
	}
}
