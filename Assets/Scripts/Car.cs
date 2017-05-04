using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public enum TypeInput
{
    Keyboard,
    Joystick
}

public class Car : MonoBehaviour {

	public GameObject audiocontroller;

    [Header("Configuração do Carro")]
    public GameObject obj;
    [HideInInspector]
    public Rigidbody2D rb;
    private float rot;
    [Tooltip("Velocidade de Rotação.")]
    public float rotSpeed;
    [Tooltip("Velocidade de Aceleração")]
    public float velocidade;
    [HideInInspector]
    public int CarIndex, CarKey;
    private bool isActivated = false;
    [SerializeField]
    public Dictionary<String, KeyCode> carInput;

    [SerializeField]
    [Space(20)]
    [Header("Configuração de Input")]
    private string Vertical;
    [SerializeField]
    private string Horizontal;
    [SerializeField]
    public TypeInput inputType;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        SetCarInputConfig();

    }
    public void SetCarInputConfig()
    {
        if (inputType == TypeInput.Keyboard)
        {
            carInput = ControllerMaps.getMapsKeyboard();
            Horizontal = ControllerMaps.getHorizontalKeyboard(CarIndex, CarKey);
            Vertical = ControllerMaps.getVerticalKeyboard(CarIndex, CarKey);
        }
        else
        {
            carInput = ControllerMaps.getMapsJoystic(CarIndex);
            Horizontal = ControllerMaps.getHorizontalJoystick(CarIndex);
            Vertical = ControllerMaps.getVerticalJoystick(CarIndex);
        }
        isActivated = true;
        print("Input Configurado");
    }
    // Update is called once per frame
    void Update () {
        if (!isActivated)
            return;

        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis(Horizontal) * rotSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

		if (Input.GetAxis (Vertical) > 0) {
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(obj.transform.position.x, obj.transform.position.y + (velocidade / 5)), (velocidade * 5) * Time.deltaTime);
		} 
    }

    //Desativa o Carro
    public void DesativeThis()
    {
        this.gameObject.SetActive(false);
    }
}
