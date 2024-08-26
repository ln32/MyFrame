using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(NamedArrayAttribute))]
public class DataHandlerDrawer : PropertyDrawer
{

    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        try
        {
            int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
            label = new GUIContent(((NamedArrayAttribute)attribute).names[pos]);
        }
        catch
        {
            EditorGUI.ObjectField(rect, property, label);
        }

        EditorGUI.PropertyField(rect, property, label);
    }
}

