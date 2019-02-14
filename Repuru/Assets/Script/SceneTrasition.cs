using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrasition : MonoBehaviour {


	//TitleSceneに遷移する関数-----------------------------
	public void TitleTrasition() {
		SceneManager.LoadScene("Title");
	}
	//-----------------------------------------------------

	//StageSelectSceneに遷移する関数-----------------------
	public void StageSelectTrasition() {
		SceneManager.LoadScene("StageSelect");
	}
	//-----------------------------------------------------

	//MainSceneに遷移する関数-----------------------------
	public void MainTrasition() {
		SceneManager.LoadScene("Main");
	}
	//-----------------------------------------------------

	//ResultSceneに遷移する関数----------------------------
	public void ResultTrasition() {
		SceneManager.LoadScene("Result");
	}
	//-----------------------------------------------------
}
