using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero2 : MonoBehaviour
{
    public RectTransform rect;
    public Canvas c;

    public Rect r;
	// Use this for initialization
	void Start ()
    {
        r = RectTransformUtility.PixelAdjustRect(rect, c);
	}
}
