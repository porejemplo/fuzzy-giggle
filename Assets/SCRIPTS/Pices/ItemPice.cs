using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPice : GamePiece
{
    public AnimationCurve LiveQuality;

    [Header ("Reference")]
    public Text text;
    public Image image;

    public void Start()
    {
        Lives = token.value;
        text.text = token.value.ToString();
        image.sprite = token.arte;
        image.color = token.color;

        //Lives = Mathf.CeilToInt(LiveQuality.Evaluate(Random.value));
    }

    public override bool Action(GamePiece other)
    {
        PlayerPice pp = other as PlayerPice;
        pp.iM.AddCart(token);

        Lives = 0;

        return true;
    }
}
