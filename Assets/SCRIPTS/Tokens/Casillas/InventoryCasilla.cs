using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCasilla : InventoryPosition
{
    public override bool setPosition(Token t)
    {
        if (!t)
        {
            Clear();
            return false;
        }
        else if (token != null)
            return false;

        return base.setPosition(t);
    }
}
