using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour {

    public KeyBinding KeyBinding;

    // GameObjects //
    // Sound
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider effectsSlider;
    public Slider voiceSlider;

    // Controls
    public GameObject horizontalButtonToggle;
    public GameObject verticalButtonToggle;
    public GameObject fpHorizontalButtonToggle;
    public GameObject fpVerticalButtonToggle;
    public GameObject[] keyAssignFields;

    // Use this for initialization
    void Start () {
        masterSlider.value = Settings.master;
        musicSlider.value = Settings.music;
        effectsSlider.value = Settings.effects;
        voiceSlider.value = Settings.voice;

        SetToggleButton(horizontalButtonToggle, !KeyBinding.horizontalInverted);
        SetToggleButton(verticalButtonToggle, !KeyBinding.verticalInverted);
        SetToggleButton(fpHorizontalButtonToggle, !KeyBinding.fpHorizontalInverted);
        SetToggleButton(fpVerticalButtonToggle, !KeyBinding.fpVerticalInverted);

        for (int i = 0; i < keyAssignFields.Length && i < KeyBinding.bindedKeys.Length; i++)
        {
            Transform key = keyAssignFields[i].transform.Find("Key");
            key.GetComponentInChildren<Text>().text = KeyBinding.bindedKeys[i].key.ToString();
            key.GetComponent<SelectButtonReference>().key = KeyBinding.bindedKeys[i].key;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Sets the ToggleButton on pressed left, if true, or right, if false
    /// </summary>
    /// <param name="toggleButton">ToggleButton from Prefab</param>
    /// <param name="left">Is left pressed</param>
    private void SetToggleButton(GameObject toggleButton, bool left)
    {
        Button[] buttons = toggleButton.GetComponentsInChildren<Button>();
        buttons[0].interactable = !left;
        buttons[1].interactable = left;
    }

    #region UI Events to change values in settings and keyBinding
    public void SetMaster()
    {
        Settings.master = (int)masterSlider.value;
    }

    public void SetMusic()
    {
        Settings.music = (int)musicSlider.value;
    }

    public void SetEffects()
    {
        Settings.effects = (int)effectsSlider.value;
    }

    public void SetVoice()
    {
        Settings.voice = (int)voiceSlider.value;
    }

    public void SetHorizontalInverted(bool inverted)
    {
        KeyBinding.horizontalInverted = inverted;
    }

    public void SetVerticalInverted(bool inverted)
    {
        KeyBinding.verticalInverted = inverted;
    }

    public void SetFpHorizontalInverted(bool inverted)
    {
        KeyBinding.fpHorizontalInverted = inverted;
    }

    public void SetFpVerticalInverted(bool inverted)
    {
        KeyBinding.fpVerticalInverted = inverted;
    }

    public void RevertKeyBindings()
    {
        KeyBinding.RevertKeyBindings();
        for (int i = 0; i < keyAssignFields.Length && i < KeyBinding.bindedKeys.Length; i++)
        {
            Transform key = keyAssignFields[i].transform.Find("Key");
            key.GetComponentInChildren<Text>().text = KeyBinding.bindedKeys[i].key.ToString();
            key.GetComponent<SelectButtonReference>().key = KeyBinding.bindedKeys[i].key;
        }
    }
    #endregion
}
