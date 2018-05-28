using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    #region Constantes
    private const int filoPerdido = 1;
    private const float aumentoDePorcentage = 0.1f;
    #endregion

    [Header("Casillas")]
    public InventoryPosition ArmaUI;
    public InventoryPosition VidaUI;
    public InventoryPosition ArmaduraUI;
    public InventoryPosition[] Items;
    //public InventoryPosition Item1UI;
    //public InventoryPosition Item2UI;
    //public InventoryPosition Item3UI;

    #region Valores
    int _vida = 10;
    int _ataque = 3;
    int _defensa = 5;

    public int Vida
    {
        get { return _vida; }
        set
        {
            _vida = Mathf.Clamp(value, 0, 10);
            VidaUI.text.text = _vida.ToString();
            if (_vida <= 0)
                endGame();
        }
    }

    public int Ataque
    {
        get { return _ataque; }
        set
        {
            porcentage = 0;
            _ataque = Mathf.Clamp(value, 3, 10);
            ArmaUI.text.text = _ataque.ToString();
        }
    }

    public int Defensa
    {
        get { return _defensa; }
        set
        {
            _defensa = Mathf.Clamp(value, 0, 10);
            ArmaduraUI.text.text = _defensa.ToString();
        }
    }
    #endregion

    private float porcentage = 0;
    public int PerderFilo()
    {
        if (Ataque < 3)
            return Ataque;
        else if (Random.value < porcentage)
        {
            Ataque -= filoPerdido;
            return Ataque + filoPerdido;
        }
        porcentage += aumentoDePorcentage;

        return Ataque;
    }

    /// <summary>
    /// Pasa de una ficha a una carta y la coloca en el inventario.
    /// </summary>
    /// <param name="t">La información de la unidad</param>
    public void AddCart (Token t)
    {
        foreach (InventoryPosition ip in Items)
        {
            if (ip.setPosition(t)) return;
        }
    }

    private void endGame()
    {
        Debug.Log("Fin");
        SceneManager.LoadScene(0);
    }
}
