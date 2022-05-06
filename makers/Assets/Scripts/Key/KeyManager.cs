using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyAction { UP, DOWN, LEFT, RIGHT, DASH, ATTACK, JUMP, SKILL1, SKILL2, KEYCOUNT }

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}

public class KeyManager : MonoBehaviour
{
    KeyCode[] defaultKeys = new KeyCode[] {KeyCode.UpArrow,KeyCode.DownArrow,KeyCode.LeftArrow,KeyCode.RightArrow,
    KeyCode.Z,KeyCode.X,KeyCode.C,KeyCode.A,KeyCode.S,};
    
    private void Awake()
    {
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }

    private void OnGUI()
    {
        Event keyEvent = Event.current;

        if (keyEvent.isKey)
        {
            KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            key = -1;
        }
    }

    int key = -1;
    
    public void ChangeKey(int num)
    {
        key= num;
    }
}
