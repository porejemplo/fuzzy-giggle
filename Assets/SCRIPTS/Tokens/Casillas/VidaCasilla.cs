using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaCasilla : InventoryPosition
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

        token = t;
        //text.text = t.value.ToString();
        iM.Vida += t.value; 

        Visible(true);

        return true;
    }
}
