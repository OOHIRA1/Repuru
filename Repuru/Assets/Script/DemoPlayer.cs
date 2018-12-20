using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayer : MonoBehaviour {

	float InputHorizontal;
	float InputVertical;
	Rigidbody rb;
 
	[SerializeField]float MoveSpeed;
	 
	void Start() {
	    rb = GetComponent<Rigidbody>();
	}
	 
	void Update() {
	    InputHorizontal = Input.GetAxisRaw("Horizontal");
	    InputVertical = Input.GetAxisRaw("Vertical");
	}
	 
	void FixedUpdate() {
	    // カメラの方向から、X-Z平面の単位ベクトルを取得
	    Vector3 CameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
	 
	    // 方向キーの入力値とカメラの向きから、移動方向を決定
	    Vector3 MoveForward = CameraForward * InputVertical + Camera.main.transform.right * InputHorizontal;
	 
	    // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
	    rb.velocity = MoveForward * MoveSpeed + new Vector3(0, rb.velocity.y, 0);
	 
	    // キャラクターの向きを進行方向に
	    if (MoveForward != Vector3.zero) {
	        transform.rotation = Quaternion.LookRotation(MoveForward);
	    }
	}
}
