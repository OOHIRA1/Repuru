using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUi : MonoBehaviour {
	[SerializeField]Item[] item = new Item[10];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ItemHitDetails(){ 
		for (int i = 0; i < item.Length; i++){ 
			if(item[i].ItemHit == true){
				
			}
		}
	}

}
