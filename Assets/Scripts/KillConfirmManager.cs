using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillConfirmManager : MonoBehaviour {
    public GameObject painel;
    private Animator anuncios;

    public void PlayPainelAnimation() {
        int valor = Random.Range(1, 3);
        anuncios = GameObject.Find("KillConfirmPanel").GetComponent<Animator>();
        anuncios.SetInteger("Painel", valor);
        Invoke("StopAnuncio", 0.2f); //debug
        
    } 

	public void quemMorreuChecker(string valor){
        
        Text textoDePlayerMorto = GameObject.Find ("Top Text").GetComponent<Text> ();
		textoDePlayerMorto.text = valor;
    }


	void StopAnuncio(){
		anuncios.SetInteger ("Painel", 0);
    }
}
