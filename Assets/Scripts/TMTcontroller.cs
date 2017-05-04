using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMTcontroller : MonoBehaviour {
	
    public FollowCamera2D fC;
	public GameObject Bomb;

    private void Awake()
    {
        fC = GameObject.Find("Main Camera").GetComponent<FollowCamera2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
            //Assim que um player pegar a bomba, o FollowCamera começará a segui-lo.
            fC.target = other.gameObject;
            //E adicionará o script CountDown no mesmo.
            //other.gameObject.AddComponent<Countdown>();
			Instantiate (Bomb, other.gameObject.transform).transform.parent = other.gameObject.transform;
			Destroy(this.gameObject);

		}
	}

}
