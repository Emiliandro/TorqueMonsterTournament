using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFourSides : MonoBehaviour {

    
    public string horizontal = "Horizontal";
	public string vertical = "Vertical";

    [Header("indique a velocidade")]
    public float velocidade;
    
	[Header("Ative as demais direcoes")]
	public bool Vertical;

    void FixedUpdate() {
		ParaMovementar();
    }

	void ParaMovementar(){
		if (Input.GetAxis(horizontal) < 0) 
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - (velocidade / 5), transform.position.y), (velocidade * 5) * Time.deltaTime);
        
        if (Input.GetAxis(horizontal) > 0)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + (velocidade / 5), transform.position.y), (velocidade * 5) * Time.deltaTime);

        if (Input.GetAxis(vertical) < 0 && Vertical)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y - (velocidade / 5)), (velocidade * 5) * Time.deltaTime);
      
        if (Input.GetAxis(vertical) > 0 && Vertical)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + (velocidade / 5)), (velocidade * 5) * Time.deltaTime);

	}

	void ParaFreiar(){

	}
}
