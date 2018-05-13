using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel")]
public class NivelScriptableObject : ScriptableObject
{
	[SerializeField]
	public BoolGrid board;
	public List<pice> mazmorra = new List<pice>();
}

[System.Serializable]
public class BoolGrid 
{
    [System.Serializable]
    public class BoolRow {
        public bool[] Cols; // The wrapped array.
    }

    public BoolRow[] Rows = new BoolRow[5]; // The 2D array.

	public bool this[int rowIndex, int colIndex] {
        get { return Rows[rowIndex].Cols[colIndex]; }
        set { Rows[rowIndex].Cols[colIndex] = value; }
    }
}