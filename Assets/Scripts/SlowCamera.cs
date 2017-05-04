using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCamera : MonoBehaviour {

	public float velocidade;
	public float tempoDeAcao;
	public float valorAtual;
	public float tempoLimite;

	void Start () {
		Time.timeScale = 0.5f;
		tempoLimite = tempoDeAcao;
		tempoDeAcao = 0f;
	}
	
	void Update () {
		
		valorAtual += Time.deltaTime;
		if (valorAtual < tempoLimite) {
			
		} else {
			
		}
	}
}
