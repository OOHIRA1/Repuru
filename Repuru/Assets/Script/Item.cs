using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	bool itemHit = false;		//プレイヤーがアイテムに当たったかどうか

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//ゲッターとセッター-----------------------------------------
	public bool ItemHit{
		set { itemHit = value; }
        get { return itemHit; }
	}
	//-----------------------------------------------------------

	//プレイヤーに当たった時の関数-------------------------------
	private void OnTriggerEnter(Collider other)	{
		if(other.gameObject.tag == "Player"){
			itemHit = true;	
		}
	}
	//-----------------------------------------------------------

	//プレイヤーから離れた時の関数-------------------------------
	private void OnTriggerExit(Collider other)	{
		if(other.gameObject.tag == "Player"){ 
			itemHit = false;
		}
	}
	//-----------------------------------------------------------

}
