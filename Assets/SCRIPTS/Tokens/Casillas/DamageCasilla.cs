using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCasilla : InventoryPosition
{
    public InventoryManager iM;

    public override bool setPosition(Token t)
    {
        if (!t)
        {
            Clear();
            return false;
        }
        else if (t.tipe != AcceptedTipe)
            return false;

        iM.Ataque = t.value;

        return base.setPosition(t);
    }
}
