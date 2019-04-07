using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUi : MonoBehaviour {
	[SerializeField]Item[] item = new Item[10];
	[SerializeField]GameObject itemPickUp = null;           //拾うUI
    //SerializeField]Image[] ItemUiImage = new Image[2];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ItemHitDetails();
		ItemHitHideDetails();
	}

    //プレイヤーがアイテムに近づいたら拾うUIを表示------------------------------
	void ItemHitDetails(){ 
		for (int i = 0; i < item.Length; i++){ 
			if(item[i].ItemHit == true){
				itemPickUp.SetActive(true);
			}
		}
	}
    //--------------------------------------------------------------------

    //プレイヤーがアイテムから離れたら拾うUIを非表示----------------------------
	void ItemHitHideDetails(){ 
		for(int i = 0; i < item.Length; i++){ 
			if(item[0].itemHit == false && item[1].itemHit == false){ 
				itemPickUp.SetActive(false);
			}
		}
	}
    //--------------------------------------------------------------------

    //アイテムを消す関数-----------------------------------------------------
    public void ItemDestroy(){
        for (int i = 0; i < item.Length; i++){
            if (item[i].ItemHit == true){
                item[i].gameObject.SetActive(false);
            }
        }
    }
    //--------------------------------------------------------------------

    //
    //public void ItemUiDisplay() {
    //    for (int i = 0; i < item.Length; i++) {
    //        if (item[i].gameObject.activeInHierachy) {

    //        }
    //    }
    //}

}
