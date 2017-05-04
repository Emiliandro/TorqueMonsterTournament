using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroyedCar : MonoBehaviour {

	public GameObject destruido;
	[SerializeField]private Transform _tranform;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Finish") {
			_tranform = transform;
			Instantiate (destruido, _tranform);
		} 
	}

}
