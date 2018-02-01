using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [HideInInspector] public Text buttonText;

    private void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                if (kcode != KeyCode.Mouse0 && kcode != KeyCode.Mouse1)
                {
                    gameObject.SetActive(false);
                    buttonText.text = kcode.ToString();
                }
            }
        }
    }
}
