using UnityEngine;

//-////////////////////////////////////////////////////
///
/// Scriptable Object use to represent floats that can
/// be use to handle communication within scripts while
/// staying modular.
///
[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    //[System.NonSerialized]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize(){}
}