using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToNextSceneOnEnd : MonoBehaviour {

	public string cena;
	public float tempo;

	// Use this for initialization
	void Start () {
		Invoke ("changesceneonend",tempo);
	}
	
	// Update is called once per frame
	void changesceneonend () {
		SceneManager.LoadScene (cena);
	}
}
