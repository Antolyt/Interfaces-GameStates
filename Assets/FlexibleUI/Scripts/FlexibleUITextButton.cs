using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class FlexibleUITextButton : FlexibleUI
{
    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning
    }

    Button button;
    Image image;
    [SerializeField]Text text;

    public ButtonType buttonType;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        button = GetComponent<Button>();
        image = GetComponent<Image>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = skinData.buttonSpriteState;

        text.font = skinData.font;
        text.fontStyle = skinData.fontStyle;
        text.fontSize = skinData.fontSize;

        switch (buttonType)
        {
            case ButtonType.Confirm:
                image.color = skinData.confirmColor;
                break;
            case ButtonType.Decline:
                image.color = skinData.declineColor;
                break;
            case ButtonType.Warning:
                image.color = skinData.warningColor;
                break;
            default:
                image.color = skinData.defaultColor;
                break;
        }
    }
}
