using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPosition : MonoBehaviour
{
    public itemTipe AcceptedTipe;
    public bool drag = true;

    [Header ("Card References")]
    public Text text;
    public Image image;

    //[HideInInspector]
    public Token token;

    public void Start()
    {
        setPosition(token);
    }

    /// <summary>
    /// Modifica los datos de la posición.
    /// </summary>
    /// <param name="t">token para modificar los datos de la posición</param>
    /// <returns>True si se ha cambiado</returns>
    public virtual bool setPosition(Token t)
    {
        //Quitar
        if (!t)
        {
            Clear();
            return false;
        }

        token = t;
        text.text = t.value.ToString();
        image.sprite = t.arte;
        image.color = t.color;

        Visible(true);

        return true;
    }

    /// <summary>
    /// Hace los elementos de la posición invisbles
    /// </summary>
    /// <param name="b">Visibilidad de la ficha</param>
    public virtual void Visible(bool b = false)
    {
        text.enabled = b;
        image.enabled = b;
    }

    /// <summary>
    /// Borra todo el contenido de la posición.
    /// </summary>
    public virtual void Clear()
    {
        token = null;
        text.text = "";
        image.sprite = null;
        image.color = new Color(0,0,0,0);

        Visible();
    }
}
