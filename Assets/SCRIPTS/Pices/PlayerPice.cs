using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPice : GamePiece
{
    [HideInInspector]
    public InventoryManager iM;
    public static PlayerPice player;

    public override bool Action(Tile other)
    {
        if (other.tT == TileTipe.Item)
        {
            other.Id.GetComponent<GamePiece>().Action(this);

            return true;
        }
        return other.Id.GetComponent<GamePiece>().Damage(-iM.PerderFilo());
    }

    public override bool Damage(int pts)
    {
        if (pts <= 0 && iM.Defensa > 0)
        {
            int a = iM.Defensa;
            iM.Defensa += pts;
            
            if (iM.Defensa <= 0)
            {
                iM.Vida += (pts + a);
            }
            return base.Damage(pts);
        }
        iM.Vida += pts;
        
        return base.Damage(pts);
    }
}
