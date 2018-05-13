using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(BoolGrid))]
public class Array2DDrawer : PropertyDrawer
{
	const int LineHeight = 18;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PrefixLabel(position, label);
		SerializedProperty data = property.FindPropertyRelative("Rows");
		
		Rect bRec = position;
		bRec.y += Screen.width < 333 ? LineHeight : 0;
		bRec.height = EditorGUIUtility.singleLineHeight;
		bRec.width = 200/3;
		bRec.x = Mid(bRec.width * 3);//position.width - 200;
        if (data.arraySize > 3 && GUI.Button(bRec, "-", EditorStyles.miniButtonLeft))
        {
            data.arraySize--;
        }
        bRec.x += bRec.width;
		EditorGUI.IntField(bRec, data.arraySize);
		bRec.x += bRec.width;
        if (data.arraySize < 7 && GUI.Button(bRec, "+", EditorStyles.miniButtonRight))
        {
            data.arraySize++;
        }

        Rect newposition = position;
        newposition.y += Screen.width < 333 ? LineHeight*2 : LineHeight;
		float x = Mid(LineHeight*data.arraySize);
		newposition.x = x;

        for (int j = 0; j < data.arraySize; j++)
        {
            SerializedProperty col = data.GetArrayElementAtIndex(j).FindPropertyRelative("Cols");
            
			newposition.height = LineHeight;
            if (col.arraySize != data.arraySize)
                col.arraySize = data.arraySize;
            newposition.width = LineHeight;
			
            for (int i = 0; i < col.arraySize; i++)
            {
                EditorGUI.PropertyField(newposition, col.GetArrayElementAtIndex(i), GUIContent.none);
                newposition.x += newposition.width;
            }

            newposition.x = x;
            newposition.y += newposition.width;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
		SerializedProperty data = property.FindPropertyRelative("Rows");
		float f = LineHeight * (data.arraySize + 1);
        return Screen.width < 333 ? f + LineHeight : f;
    }

	private float Mid (float width){
		return (EditorGUIUtility.currentViewWidth/2) - (width/2);
	}
}