﻿Shader"Tutorial/Outline" {

    Properties {

        _Color ("Color", Color) = (1, 1, 1, 1)
        _Glossiness ("Smoothness", Range(0, 1)) = 0.5
        _Metallic ("Metallic", Range(0, 1)) = 0

        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0.03

    }

    Subshader {

        Tags {
            "RenderType" = "Opaque"
        }

CGPROGRAM

        

        ENDCG

        Pass {

Cull Front

            CGPROGRAM

            #pragma vertex VertexProgram
            #pragma fragment FragmentProgram

half _OutlineWidth;

float4 VertexProgram(
                    float4 position : POSITION,
                    float3 normal : NORMAL) : SV_POSITION
{

    position.xyz += normal * _OutlineWidth;

    return UnityObjectToClipPos(position);

}

half4 _OutlineColor;

half4 FragmentProgram() : SV_TARGET
{
    return _OutlineColor;
}

            ENDCG

        }

    }

}