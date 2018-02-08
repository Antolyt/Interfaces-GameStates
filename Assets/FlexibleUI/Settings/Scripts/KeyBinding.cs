using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class KeyBinding : MonoBehaviour {
    public static KeyBinding keyBinding;
    private string keyBindingPath;      // Requieres set in Awake
    public KeyBindingDefaultData keyBindingDefaultData;

    /// <summary>
    /// Camera horizontal inverted data
    /// </summary>
    public static bool horizontalInverted;
    /// <summary>
    /// Camera vertical inverted data
    /// </summary>
    public static bool verticalInverted;
    /// <summary>
    /// firstperson Camera horizontal inverted data
    /// </summary>
    public static bool fpHorizontalInverted;
    /// <summary>
    /// firstperson Camera vertical inverted data
    /// </summary>
    public static bool fpVerticalInverted;
    /// <summary>
    /// Binded Keys
    /// </summary>
    public static SingleKeyBinding[] bindedKeys;
    [HideInInspector] public static Dictionary<string, int> keyMap;

    void Awake()
    {
        keyBindingPath = Application.persistentDataPath + "/Settings/keyBinding.dat";

        if (keyBinding == null)
        {
            DontDestroyOnLoad(gameObject);
            keyBinding = this;
            LoadKeyBindings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < bindedKeys.Length; i++)
        {
            bindedKeys[i].pressed = Input.GetKey(bindedKeys[i].key);
        }
    }

    /// <summary>
    /// Returns true while the virtual button identified by buttonName is held down.
    /// </summary>
    public static bool GetButton(string buttonName)
    {
        int i = keyMap[buttonName];
        return Input.GetKey(bindedKeys[i].key);
    }

    /// <summary>
    /// Returns true during the frame the user pressed down the virtual button identified by buttonName is held down.
    /// </summary>
    public static bool GetButtonDown(string buttonName)
    {
        int i = keyMap[buttonName];
        return !bindedKeys[i].pressed && Input.GetKey(bindedKeys[i].key);
    }

    /// <summary>
    /// Returns true the first frame the user releases the virtual button identified by buttonName is held down.
    /// </summary>
    public static bool GetButtonUp(string buttonName)
    {
        int i = keyMap[buttonName];
        return bindedKeys[i].pressed && !Input.GetKey(bindedKeys[i].key);
    }

    /// <summary>
    /// Replaces old key with new key
    /// </summary>
    /// <param name="oldKey">name of the old Key</param>
    /// <param name="newKey">name of the new Key</param>
    /// <returns>true, if old key was found</returns>
    public static bool ChangeKeyBinding(KeyCode oldKey, KeyCode newKey)
    {
        for (int i = 0; i < bindedKeys.Length; i++)
        {
            if (bindedKeys[i].key == oldKey)
            {
                bindedKeys[i].key = newKey;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Save Settings
    /// </summary>
    public void SaveKeyBindings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(keyBindingPath);

        KeyBindingData kbd = new KeyBindingData
        {
            horizontalInverted = horizontalInverted,
            verticalInverted = verticalInverted,
            fpHorizontalInverted = fpHorizontalInverted,
            fpVerticalInverted = fpVerticalInverted,
            bindedKeys = bindedKeys
        };

        bf.Serialize(file, kbd);
        file.Close();
    }

    /// <summary>
    /// Load Settings
    /// </summary>
    public void LoadKeyBindings()
    {
        if (File.Exists(keyBindingPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(keyBindingPath, FileMode.Open);
            KeyBindingData kbd = (KeyBindingData)bf.Deserialize(file);
            file.Close();

            horizontalInverted = kbd.horizontalInverted;
            verticalInverted = kbd.verticalInverted;
            fpHorizontalInverted = kbd.fpHorizontalInverted;
            fpVerticalInverted = kbd.fpVerticalInverted;
            bindedKeys = kbd.bindedKeys;

            keyMap = new Dictionary<string, int>();
            for (int i = 0; i < bindedKeys.Length; i++)
            {
                keyMap.Add(bindedKeys[i].action, i);
            }
        }
        else
        {
            LoadKeyBindingDefaultData();
        }
    }

    /// <summary>
    /// Revert Settings
    /// </summary>
    public void RevertKeyBindings()
    {
        LoadKeyBindingDefaultData();
    }

    private void LoadKeyBindingDefaultData()
    {
        horizontalInverted = keyBindingDefaultData.horizontalInverted;
        verticalInverted = keyBindingDefaultData.verticalInverted;
        fpHorizontalInverted = keyBindingDefaultData.fpHorizontalInverted;
        fpVerticalInverted = keyBindingDefaultData.fpVerticalInverted;
        bindedKeys = keyBindingDefaultData.bindedKeys;

        keyMap = new Dictionary<string, int>();
        for (int i = 0; i < bindedKeys.Length; i++)
        {
            keyMap.Add(bindedKeys[i].action, i);
        }
    }
}

[Serializable]
public class KeyBindingData
{
    public bool horizontalInverted;
    public bool verticalInverted;
    public bool fpHorizontalInverted;
    public bool fpVerticalInverted;
    public SingleKeyBinding[] bindedKeys;
}

[CreateAssetMenu(menuName = "Data/KeyBinding Default Data")]
public class KeyBindingDefaultData : ScriptableObject
{
    public bool horizontalInverted;
    public bool verticalInverted;
    public bool fpHorizontalInverted;
    public bool fpVerticalInverted;
    public SingleKeyBinding[] bindedKeys;
}

[Serializable]
public struct SingleKeyBinding
{
    public string action;
    public KeyCode key;
    public bool pressed;

    public bool IsEqual(SingleKeyBinding cKA)
    {
        return this.key == cKA.key && this.action == cKA.action;
    }
}
