using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour {

	public AudioClip motor;
	public AudioClip batida;
	public AudioClip explosao;
	public AudioSource source;

	void startsound (){
		source.Play ();
	}
	// 			audiocontroller.GetComponent<sfxManager> ().playmotor ();
	void playsound (AudioClip valor){
		source.clip = valor;
	}

	public void playmotor(){
		playsound (motor);
	}
	public void playbatida(){
		playsound (batida);
	}
	public void playexplosao(){
		playsound (explosao);
	}
}
