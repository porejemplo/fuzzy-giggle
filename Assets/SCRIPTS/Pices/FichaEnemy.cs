using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaEnemy : GamePiece
{
    public AnimationCurve LiveQuality;

    [Header("Reference")]
    public TextMesh text;
    public SpriteRenderer image;

    public void Start()
    {
        Lives = token.value;
        text.text = token.value.ToString();
        image.sprite = token.arte;
        image.color = token.color;

        //Lives = Mathf.CeilToInt(LiveQuality.Evaluate(Random.value));
    }

    public override bool Action(Tile other)
    {
        return base.Action(other);
    }

    public override bool Damage(int pts)
    {
        Lives += pts;

        text.text = Lives.ToString();

        return base.Damage(pts);
    }

    protected override void Die()
    {
        text.text = Lives.ToString();
        base.Die();
    }
}
