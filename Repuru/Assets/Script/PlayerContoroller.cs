using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoroller : MonoBehaviour {
    [SerializeField] private Vector3 velocity;          //移動方向
    [SerializeField] private float moveSpeed = 5.0f;    //移動速度
    [SerializeField] private float applySpeed = 0.2f;   //振り向きの速度


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //velociyを増やしたり減らしたして移動させる
        velocity = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W)) {
            velocity.z += 1;
        }

        if (Input.GetKey(KeyCode.A)) {
            velocity.x -= 1;
        }

        if (Input.GetKey(KeyCode.S)) {
            velocity.z -= 1;
        }

        if (Input.GetKey(KeyCode.D)) {
            velocity.x += 1;
        }
        //-----------------------------------------------

        //移動スピードを現実の１秒に------------------------------------------
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;
        //--------------------------------------------------------------------


        //velocityが0になったら座標を更新させる----------------------------------------
        if (velocity.magnitude > 0) {

            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(-velocity),
                                                  applySpeed);
            transform.position += velocity;
        }
        //----------------------------------------------------------------------------
    }
}
