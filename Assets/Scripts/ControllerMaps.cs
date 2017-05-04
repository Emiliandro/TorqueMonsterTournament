using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class ControllerMaps{

    private static string[] VerticalAxis = new string[]{
        "Vertical", "Vertical2","JoystickV1","JoystickV2","JoystickV3","JoystickV4"
    };

    private static string[] HorizontallAxis = new string[]{
        "Horizontal", "Horizontal2","JoystickH1","JoystickH2","JoystickH3","JoystickH4"
    };

    private static Dictionary<string, KeyCode> InputDictionaryKeyboard = new Dictionary<string, KeyCode>(){
        {"Jump",KeyCode.Space },
        {"Dash",KeyCode.Z },
        {"Shoot",KeyCode.X },
    };
    private static Dictionary<string, KeyCode> InputDictionaryJoystick1 = new Dictionary<string, KeyCode>() {
        {"Jump",KeyCode.Joystick1Button0 },
        {"Dash",KeyCode.Joystick1Button2 },
        {"Shoot",KeyCode.Joystick1Button1 }
    };
    private static Dictionary<string, KeyCode> InputDictionaryJoystick2 = new Dictionary<string, KeyCode>() {
        {"Jump",KeyCode.Joystick2Button0 },
        {"Dash",KeyCode.Joystick2Button2 },
        {"Shoot",KeyCode.Joystick2Button1 }
    };

    public static Dictionary<string,KeyCode> getMapsJoystic(int idx){
        if(idx == 1){
            return InputDictionaryJoystick1;
        }else if(idx == 2){
            return InputDictionaryJoystick2;
        }
        return null;
    }

    public static Dictionary<string, KeyCode> getMapsKeyboard(){
        return InputDictionaryKeyboard;
    }

    public static string getVerticalJoystick(int idx){
        if(idx == 1){
            return VerticalAxis[2];
        }else if(idx == 2){
            return VerticalAxis[3];
        }
        else if (idx == 3)
        {
            return VerticalAxis[4];
        }
        else if (idx == 4)
        {
            return VerticalAxis[5];
        }
        return null;
    }

    public static string getHorizontalJoystick(int idx){
        if (idx == 1)
        {
            return HorizontallAxis[2];
        }
        else if (idx == 2)
        {
            return HorizontallAxis[3];
        }
        else if (idx == 3)
        {
            return HorizontallAxis[4];
        }
        else if (idx == 4)
        {
            return HorizontallAxis[5];
        }
        return null;
    }

    public static string getVerticalKeyboard(int idx, int eix)
    {
        if ((idx == 1 || idx == 2 || idx == 3) && eix == 1)
        {
            return VerticalAxis[0];
        }
        else if ((idx == 2 || idx == 3 || idx == 4) && eix == 2)
        {
            return VerticalAxis[1];
        }
        return null;
    }

    public static string getHorizontalKeyboard(int idx, int eix)
    {
        if ((idx == 1 || idx == 2 || idx == 3) && eix == 1)
        {
            return HorizontallAxis[0];
        }
        else if ((idx == 2 || idx == 3 ||idx == 4) && eix == 2)
        {
            return HorizontallAxis[1];
        }
        return null;
    }

    public static void SaveInputCustom(int playerIdx, string config){
        PlayerPrefs.SetString("PlayerIdInput" + playerIdx, config);
    }


}


