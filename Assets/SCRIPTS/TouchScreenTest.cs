using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenTest : MonoBehaviour
{
    public RectTransform gameArea;

    public bool enJuego = false;

    // Update is called once per frame
    void Update ()
    {
        transform.position = Input.mousePosition;

        enJuego = gameArea.rect.Contains(transform.position);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(0, 1, 0, 0.5F);
    //    Gizmos.DrawCube(gameArea.rect.center, gameArea.rect.size);
    //}
}
