using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPiece : GamePiece
{
    public TextMesh tM;

    public AnimationCurve LiveQuality;

    public void Awake()
    {
        Lives = Mathf.CeilToInt(LiveQuality.Evaluate(Random.value));
        tM.text = Lives.ToString();
    }

    public override bool Action(GamePiece other)
    {
        PlayerPice pp = other as PlayerPice;
        pp.iM.AddCart(token);
        //pp.atackDamage = Lives;

        Lives = 0;

        return true;
    }

    protected override void Die()
    {
        tM.text = Lives.ToString();
        base.Die();
    }
}
