using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEfeito : MonoBehaviour {

    [Header("Indique o tempo da ação")]
    public float tempo;

    void Start()
    {
        Invoke("anularEfeito", tempo);
    }

    void anularEfeito()
    {
        Destroy(this.gameObject);
}
}
