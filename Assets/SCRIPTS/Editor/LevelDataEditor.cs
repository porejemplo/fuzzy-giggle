using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(NivelScriptableObject))]
public class LevelDataEditor : Editor 
{
    private ReorderableList list;
    private bool[,] array;

    private void OnEnable() {
        list = new ReorderableList(serializedObject, 
                serializedObject.FindProperty("mazmorra"), 
                true, true, true, true);
        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
		{
			var element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y += 2;
			EditorGUI.PropertyField(new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("tT"), GUIContent.none);
			EditorGUI.PropertyField(new Rect(rect.x + 60, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("Id"), GUIContent.none);
			EditorGUI.PropertyField(new Rect(rect.x + rect.width - 30, rect.y, 30, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("cantidad"), GUIContent.none);
		};

		list.drawHeaderCallback = (Rect rect) => {  
    		EditorGUI.LabelField(rect, "Enemy Waves");
		};
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("board"));
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
