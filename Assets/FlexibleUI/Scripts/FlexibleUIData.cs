using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/Flexible UI Data")]
public class FlexibleUIData : ScriptableObject
{
    [Header("Button Color")]
    public Sprite buttonSprite;
    public SpriteState buttonSpriteState;

    public Color defaultColor;
    public Color confirmColor;
    public Color declineColor;
    public Color warningColor;

    [Header("Button Icon")]
    public Sprite defaultIcon;
    public Sprite confirmIcon;
    public Sprite declineIcon;
    public Sprite warningIcon;

    [Header("Button Text")]
    public Font font;
    public FontStyle fontStyle;
    public int fontSize;
}
