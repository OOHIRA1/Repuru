using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUi : MonoBehaviour {
	[SerializeField]Item[] item = new Item[10];
	[SerializeField]GameObject itemPickUp = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ItemHitDetails();
		ItemHitHideDetails();
	}

	void ItemHitDetails(){ 
		for (int i = 0; i < item.Length; i++){ 
			if(item[i].ItemHit == true){
				itemPickUp.SetActive(true);
			}
		}
	}

	void ItemHitHideDetails(){ 
		for(int i = 0; i < item.Length; i++){ 
			if(item[0].itemHit == false && item[1].itemHit == false){ 
				itemPickUp.SetActive(false);
			}
		}
	}

}
