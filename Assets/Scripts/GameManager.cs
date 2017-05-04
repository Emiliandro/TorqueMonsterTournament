using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public GameObject[] players = new GameObject[4];
	public bool temBomba;
	public GameObject bomba;
	public GameObject endOfRoundPanel;
	public string resto;
	public Text vencedor;

	void Start(){
		endOfRoundPanel.SetActive (false);
	}
	// analisa um array para entregar o numero restantes de players
	public int playersVivos() {
		int restantes = 0;
		
		foreach (GameObject player in players){
			if (player != null){
				if (player.activeSelf) {
					resto = player.name;
					restantes++;
				}
				print (restantes);
			}
		} 
		return restantes;
	}
	// diz se pode instanciar nova bomba no mapa
	public bool instanciarBomba(){
		GameObject bombaNoMapa = GameObject.Find("TMT");
		//int playersAntes = ;
		//int playerDepois = playersVivos();

		bool retorno = false;
		
		if (bombaNoMapa != null) {
			retorno = true;
		}

		return retorno;
	}



	void FixedUpdate(){

		if (playersVivos () == 1) {
			vencedor.text = resto;
			endOfRoundPanel.SetActive (true);
			Time.timeScale = 0.2f;
		}


	}
}
