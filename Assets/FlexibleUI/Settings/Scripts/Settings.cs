using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour {

    public static Settings settings;
    private string settingsPath;        // Requieres set in Awake
    public SettingsDefaultData settingsDefaultData;

    // General

    // Graphic

    // Sound
    /// <summary>
    /// Sound master volume data
    /// </summary>
    public static int master;
    /// <summary>
    /// Sound music volume data
    /// </summary>
    public static int music;
    /// <summary>
    /// Sound effects volume data
    /// </summary>
    public static int effects;
    /// <summary>
    /// Sound voice volume data
    /// </summary>
    public static int voice;

    void Awake()
    {
        settingsPath = Application.persistentDataPath + "/Settings/settings.dat";

        if (settings == null)
        {
            DontDestroyOnLoad(gameObject);
            settings = this;
            LoadSettings();
        } else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Save Settings
    /// </summary>
    public void SaveSettings()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(settingsPath);

        SettingsData sd = new SettingsData
        {
            master = Settings.master,
            music = Settings.music,
            effects = Settings.effects,
            voice = Settings.voice
        };

        bf.Serialize(file, sd);
        file.Close();
    }

    /// <summary>
    /// Load Settings
    /// </summary>
    public void LoadSettings()
    {
        if (File.Exists(settingsPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(settingsPath, FileMode.Open);
            SettingsData sd = (SettingsData)bf.Deserialize(file);
            file.Close();

            master = sd.master;
            music = sd.music;
            effects = sd.effects;
            voice = sd.voice;
        }
        else
        {
            LoadSettingsDefaultData();
        }
    }

    /// <summary>
    /// Revert Settings
    /// </summary>
    public void RevertSettings()
    {
        LoadSettingsDefaultData();
    }

    private void LoadSettingsDefaultData()
    {
        master = settingsDefaultData.master;
        music = settingsDefaultData.music;
        effects = settingsDefaultData.effects;
        voice = settingsDefaultData.voice;
    }
}


[Serializable]
public class SettingsData
{
    public int master;
    public int music;
    public int effects;
    public int voice;
}

[CreateAssetMenu(menuName = "Data/Settings Default Data")]
public class SettingsDefaultData : ScriptableObject
{
    public int master;
    public int music;
    public int effects;
    public int voice;
}