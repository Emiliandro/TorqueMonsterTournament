using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    private const int MAX_SLOTS = 4;
    [Tooltip ("Os Carros que estarão no jogo.")]
    public Car[] Cars;
    [Tooltip("Numero maximo de jogadores no Teclado")]
    public int ck = 0;
    [SerializeField]
    [Tooltip("Os Joysticks que estão conectados.")]
    private string[] currentJoy;

    private KeyCode TheKey(string controler, int idx, int buttonI)
    {
        string button = controler + idx + "Button" + buttonI;
        KeyCode kc = (KeyCode)Enum.Parse(typeof(KeyCode), button);
        return kc;
    }

    private void Awake()
    {
        currentJoy = Input.GetJoystickNames();
        SetPlayersInput();
    }

    private void Start()
    {
        KeyCode kcTeste = TheKey("Joystick", 1, 2);
        print(kcTeste.ToString());
    }

    private void Update()
    {
        currentJoy = Input.GetJoystickNames();

        KeyCode kcTeste = TheKey("Joystick", 1, 2);
        print(kcTeste.ToString());

        if (Input.anyKeyDown)
        {
            foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kc))
                {
                    Debug.Log(">> " + kc);
                }
            }
        }

    }

    public void SetPlayersInput()
    {
        for (int i = 0; i < MAX_SLOTS; i++)
        {
            Cars[i].CarIndex = i + 1;
            if ((currentJoy.Length < (i + 1)) && ck < 2)
            {
                    ck += 1;
                    Cars[i].CarKey = ck;
                    Cars[i].inputType = TypeInput.Keyboard;
                    Cars[i].SetCarInputConfig();
            }
            else
            {
                //Como os Teclados serão setados por ultimos. Assim que eles forem configurados os proximos carros serão desativados.
                if (ck > 1) Cars[i].DesativeThis();
                Cars[i].SetCarInputConfig();
            }
        }
    }
}
