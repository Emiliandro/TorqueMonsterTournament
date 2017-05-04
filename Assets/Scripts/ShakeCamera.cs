using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {

	public float velocidade;
	public float tempoDeAcao;
	public float valorAtual;
	public float tempoLimite;
	public float minima;
	public float maxima;
	private Vector2 original;
	private GameObject camera;

	void Start(){
		Time.timeScale = 2f;
		tempoLimite = tempoDeAcao;
		tempoDeAcao = 0f;
		camera = GameObject.FindGameObjectWithTag ("MainCamera");		
		original = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;
	}

	void ShakeEffect(){

		float escolha = Random.Range (0, 4);

		if (escolha == 0) camera.transform.position = new Vector2(camera.transform.position.x + Random.Range(minima, maxima), camera.transform.position.y);
        if (escolha == 1) camera.transform.position = new Vector2(camera.transform.position.x, camera.transform.position.y + Random.Range(minima, maxima));
        if (escolha == 2) camera.transform.position = new Vector2(camera.transform.position.x - Random.Range(minima, maxima), camera.transform.position.y);
        if (escolha == 3) camera.transform.position = new Vector2(camera.transform.position.x, camera.transform.position.y - Random.Range(minima, maxima));

	}

	void Update(){
		valorAtual += Time.deltaTime;

		if (valorAtual < tempoLimite) {
			ShakeEffect ();
		} else {
			AnularEfeito ();
		}
	}

	void AnularEfeito(){
        // Após o término do Shake, ele faz a camera voltar a posição pré setada com tamanho original. Depois se destroi. 
        camera.GetComponent<Camera>().orthographicSize = 40;
        camera.transform.position = new Vector3(0, 7, -10);
        Destroy(this.gameObject);
		Time.timeScale = 1f;
	}

}
