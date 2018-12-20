using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCamera : MonoBehaviour {

	GameObject Target;
	Vector3 TargetPos;
	 
	void Start () {
	    Target = GameObject.Find("Player");
	    TargetPos = Target.transform.position;
	}
	 
	void Update() {
	    // targetの移動量分、自分（カメラ）も移動する
	    transform.position += Target.transform.position - TargetPos;
	    TargetPos = Target.transform.position;
	 
	    // マウスの右クリックを押している間
	    if (Input.GetMouseButton(1)) {
	        // マウスの移動量
	        float MouseInputX = Input.GetAxis("Mouse X");
	        float MouseInputY = Input.GetAxis("Mouse Y");
	        // targetの位置のY軸を中心に、回転（公転）する
	        transform.RotateAround(TargetPos, Vector3.up, MouseInputX * Time.deltaTime * 200f);
	        // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
	        transform.RotateAround(TargetPos, transform.right, MouseInputY * Time.deltaTime * 200f);
	    }
	}  
}
