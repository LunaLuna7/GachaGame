using System;

//-////////////////////////////////////////////////////
///
/// Float wrapper that is use to provide more functionality to
/// FloatValue by adding the option of using a constant value
/// instead of the Scriptable Obj
///
[Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public float Value
    {
        get { return useConstant ? ConstantValue : Variable.RuntimeValue; }
        set {Variable.RuntimeValue = value;}
    }

}
