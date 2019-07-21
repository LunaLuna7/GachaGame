using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : PropertyDrawer
{
    //-////////////////////////////////////////////////////
    ///
    /// Handles all the drawing in the console
    ///
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        bool useConstant = property.FindPropertyRelative("useConstant").boolValue;

        // Draws the label text in the left
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        //The square button
        var rect = new Rect(position.position, Vector2.one * 20);

        // The pop up window when we click the square
        if (EditorGUI.DropdownButton(rect, new GUIContent(EditorGUIUtility.IconContent("animationdopesheetkeyframe")),
         FocusType.Keyboard, new GUIStyle(){fixedWidth = 50f, border = new RectOffset(1,1,1,1)}))
        {
            GenericMenu menu = new GenericMenu();

            menu.AddItem(new GUIContent("Constant"), useConstant, () => SetProperty(property, true));
            menu.AddItem(new GUIContent("Variable"), !useConstant, () => SetProperty(property, false));
            menu.ShowAsContext();
       }

        //Manages the reference to the object that is being use for reference(the field in the right side of the console row)
        position.position += Vector2.right * 15;
        float value = property.FindPropertyRelative("ConstantValue").floatValue;

        //if use constant then we show a string and make the constant value = to float of such string
        if (useConstant)
        {
           string newValue = EditorGUI.TextField(position, value.ToString());
           float.TryParse(newValue, out value);
           property.FindPropertyRelative("ConstantValue").floatValue = value;
        }
        //We show the reference to the scriptable object
        else
        {
            EditorGUI.ObjectField(position, property.FindPropertyRelative("Variable"), GUIContent.none);
        }

        EditorGUI.EndProperty();

   }

    //-////////////////////////////////////////////////////
    ///
    /// Changes the actual value of a script with the given property
    ///
    private void SetProperty(SerializedProperty property, bool value)
    {
        var propRelative = property.FindPropertyRelative("useConstant");
        propRelative.boolValue = value;
        property.serializedObject.ApplyModifiedProperties();
    }
}
