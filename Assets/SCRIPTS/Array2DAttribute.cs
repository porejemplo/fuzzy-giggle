using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array2DAttribute : PropertyAttribute
{
	public int ancho = 2;
	public int alto = 2;
	public bool ShowEditRange;

	public Array2DAttribute(int x, int y){
		ancho = x;
		alto = y;
	}
}
