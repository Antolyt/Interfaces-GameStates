using System;
using UnityEngine;
using UnityEngine.UI;

public class ReassignKeyPanel : MonoBehaviour
{
    //[HideInInspector] public Text buttonText;
    [HideInInspector] public GameObject reassignButton;

    private void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                if (kcode != KeyCode.Mouse0 && kcode != KeyCode.Mouse1)
                {
                    KeyCode buttonKey = reassignButton.GetComponent<SelectButtonReference>().key;
                    gameObject.SetActive(false);
                    KeyBinding.ChangeKeyBinding(buttonKey, kcode);
                    reassignButton.GetComponentInChildren<Text>().text = kcode.ToString();
                    reassignButton.GetComponent<SelectButtonReference>().key = kcode;
                }
            }
        }
    }
}
