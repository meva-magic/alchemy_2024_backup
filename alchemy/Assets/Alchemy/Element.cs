using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Alchemy/Element")]
public class Element : ScriptableObject
{
    public string elementName;
    public Sprite icon;

    public Element[] combinableWith;
    public Element resultElement;
}
