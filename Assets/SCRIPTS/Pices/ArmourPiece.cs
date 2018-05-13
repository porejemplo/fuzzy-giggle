using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPiece : GamePiece
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
        //pp.armour = Lives;

        Lives = 0;

        return true;
    }

    //public override bool Damage(float pts)
    //{
    //    Lives += pts;

    //    //tM.text = Lives.ToString();

    //    return base.Damage(pts);
    //}

    protected override void Die()
    {
        tM.text = Lives.ToString();
        base.Die();
    }
}
