using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaduraCasilla : InventoryPosition
{
    public InventoryManager iM;

    public override bool setPosition(Token t)
    {
        if (!t)
        {
            Clear();
            return true;
        }
        else if (t.tipe != AcceptedTipe)
            return false;

        iM.Defensa = t.value;

        return base.setPosition(t);
    }
}
