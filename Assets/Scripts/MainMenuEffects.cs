using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuEffects : MonoBehaviour 
{

	public GameObject seletorPlay;
	public GameObject seletorCredits;
	public GameObject startTrue;
	public GameObject startFalse;

	public enum Modo{
		START1,
		START2,
		CREDITS1,
		CREDITS2
	}

	[SerializeField] private Modo _modo;


	void Start()
	{
		_modo = Modo.START1;
		playScreen (true,false,false,false);

	}

	void playScreen(bool _start, bool _choose, bool _credits, bool _play){
		ativarObjeto (startFalse, _start);
		ativarObjeto (startTrue, _choose);
		ativarObjeto (seletorCredits, _credits);
		ativarObjeto (seletorPlay, _play);
	}

	void ativarObjeto(GameObject _objeto, bool valor)
	{
		_objeto.SetActive (valor);
	}

	void Update(){
		gerenciador();
	}

	void keyToStart(){
		if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene("GameScene");
		}
	}

	void gerenciador(){
		
		switch (_modo){

		case Modo.START1:
			playScreen (true, false, false, false);
			gerenciadorDeKeys (Modo.START2, Modo.START1, Modo.START1);
			break;

		case Modo.CREDITS1:
			playScreen (false, true, true, false);
			gerenciadorDeKeys (Modo.START2, Modo.CREDITS1, Modo.CREDITS1);
			break;

		case Modo.START2:
			playScreen (false, true, false, true);
			gerenciadorDeKeys (Modo.CREDITS2, Modo.START2, Modo.START2);
			keyToStart ();
			break;

		case Modo.CREDITS2:
			playScreen (false,false,false,true);
			gerenciadorDeKeys (Modo.START2, Modo.CREDITS2, Modo.CREDITS2);
			break;
			
		}

	}

	void gerenciadorDeKeys(Modo _space, Modo _forward, Modo _backwards){
		if (Input.GetKeyDown (KeyCode.Space)) {
			_modo = _space;
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			_modo = _forward;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			_modo =  _backwards;
		}
	}

}
