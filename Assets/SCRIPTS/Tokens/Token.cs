using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Token")]
public class Token : ScriptableObject
{
    //public new string name;

    public itemTipe tipe;

    [Range(1,10)]
    public int value;
    public Color color;

    public Sprite arte;
}

public enum itemTipe
{
    Ataque,
    Vida,
    Defensa,
    All
}