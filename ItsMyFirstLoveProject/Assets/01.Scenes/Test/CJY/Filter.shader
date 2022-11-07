Shader "Custom/Filter"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        [Enum(Equal,3,NotEqual,6)] _OtherObj ("Stencil Test", int) = 6
    }
    SubShader
    {
        Color [_Color]
        Stencil{
            Ref 1
            Comp [_StencilComp]
        }

        Pass
        {
        }
    }
}
