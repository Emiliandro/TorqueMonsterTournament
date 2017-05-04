using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDestroying : MonoBehaviour {
    public string tag = "Plataform";
	public GameObject shakecamera, cam;
	public KillConfirmManager menu;
	public float tempoParaExplodir = 12;
	public GameObject[] explosoes;
	public GameObject BOMBATEMPORARIA;
	//public GameObject pai;
    
	void anularEfeito()
    {
		Destroy(GameObject.Find("GoDestroying(Clone)"));
	}

	void Start(){
		//explosoesSurgem ();
		//pai = gameObject.transform.parent.GetComponent<GameObject>();
		menu = GameObject.Find("GameManager").GetComponent<KillConfirmManager>();
        cam = GameObject.Find("Main Camera");
    }

    
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == tag) {
			destroiCarro (other.gameObject);
		} 
    }

	void destroiCarro(GameObject other){
        //Toda vez que for ocorrer a destruição de um player, a camera dará zoom.
        cam.GetComponent<Camera>().orthographicSize = 20;
        InstanciaShakeCamera();
		setQuemMorreu (other);
		Destroy(other.gameObject);
		explosoesSurgem ();

		Invoke("anularEfeito", 0.3f);
		Instantiate (BOMBATEMPORARIA, new Vector2 (0, 0), transform.rotation);
	}
   
	void InstanciaShakeCamera(){
		Instantiate (shakecamera);
   	}
	
	void Update(){
		//tempoParaExplodir -= Time.deltaTime;
		//if (tempoParaExplodir < 0) {
			//destroiCarro (pai);
		//}

		Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>());

	}


	void setQuemMorreu(GameObject other){
		string valor = other.name.ToString();
		Debug.Log (valor);
		menu.PlayPainelAnimation ();
		menu.quemMorreuChecker(valor);

	}

	void explosoesSurgem(){
		foreach (GameObject _explosoes in explosoes){
			Debug.Log ("explodir");
			int randomico2 = Random.Range (-5, 4);
			int randomico1 = Random.Range (-4, 3);
			Instantiate (_explosoes, new Vector2 (this.transform.position.x + randomico1, this.transform.position.y + randomico2), transform.rotation);
		} 
	}
}
