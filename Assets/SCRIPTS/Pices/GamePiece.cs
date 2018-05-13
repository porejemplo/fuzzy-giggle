using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    #region Variables
    private int _lives = 10;

    /// <value>
    /// The Lives property gets/sets the value of the string field, _lives.
    /// </value>
    public int Lives
    {
        get { return _lives; }
        set
        {
            _lives = Mathf.Clamp(value, 0, 10);
            if (_lives == 0)
                dead = true;
        }
    }
    
    protected bool dead = false;

    public Token token;
    #endregion

    #region Funciones del padre
    /// <summary>
    /// Realiza la acción del la ficha a la que se le pase como referencia.
    /// </summary>
    /// <param name="other">Ficha sobre la que se realiza la acción</param>
    /// <returns>devuelve true si la otra pieza ha muerto</returns>
    public virtual bool Action (Tile other)
    {
        return Action(other.Id.GetComponent<GamePiece>());
    }

    /// <summary>
    /// Realiza la acción del la ficha a la que se le pase como referencia.
    /// </summary>
    /// <param name="other">Ficha sobre la que se realiza la acción</param>
    /// <returns>devuelve true si la otra pieza ha muerto</returns>
    public virtual bool Action (GamePiece other)
    {
        return other.Damage(-Lives);
    }

    /// <summary>
    /// Función para palicar restar/sumar vida a las piezas de juego
    /// </summary>
    /// <param name="pts">Puntos que queremos modificar (negativo resta, positivo suma)</param>
    /// <returns>devuelve true si la pieza ha muerto</returns>
    public virtual bool Damage (int pts)
    {
        return (Lives <=0);
    }

    /// <summary>
    /// Todo lo que ocurre cuando se muere
    /// El sentido de la vida
    /// </summary>
    protected virtual void Die()
    {
        //Mierdas de la muerte y tal
        Destroy(gameObject);
    }
    #endregion

    #region Movement
    protected bool mover = false;
    public AnimationCurve speedInterpolation;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    public void updateMovement(float t)
    {
        if (mover == true)
        {
            t = speedInterpolation.Evaluate(t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }

        if (t >= 1)
        {
            if (dead) Die();

            mover = false;
        }
    }
    // public bool endMovementMode(){
    //         if (dead) Die();

    //         mover = false;
    //         return dead;
    // }
    public void setMovementMode(Vector2 target, float damage = 0)
    {
        startPosition = transform.position;
        targetPosition = target;
        mover = true;
    }
#endregion
}
