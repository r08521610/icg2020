// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/PhongShading"
{
    Properties
    {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Tex ("Pattern", 2D) = "white" {}

        _Shininess ("Shininess", Float) = 10

        _Ka ("Ka", Float) = (1, 1, 1, 1)
        _Kd ("Kd", Float) = (1, 1, 1, 1)
        _Ks ("Ks", Float) = (1, 1, 1, 1)

        _SpecColor ("Specular Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Pass {
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                uniform float4 _LightColor0;

                sampler2D _Tex;
                float4 _Tex_ST;

                uniform float4 _Color;
                uniform float4 _SpecColor;
                uniform float _Shininess;

                uniform float4 _Ka;
                uniform float4 _Kd;
                uniform float4 _Ks;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                };
                struct v2f
                {
                    float4 pos : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                    float4 posWorld : TEXCOORD1;
                };
                v2f vert(appdata v)
                {
                    v2f o;
                    // Calculate the world position for our point
                    o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                    // Caculate the normal
                    o.normal = normalize(mul(float4(v.normal, 0), unity_WorldToObject).xyz);
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _Tex);

                    return o;
                }
                fixed4 frag(v2f i) : Color
                {
                    float3 normalDirection = i.normal;
                    float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz - i.posWorld.xyz * _WorldSpaceLightPos0.w);

                    // Ambient
                    float3 ambientLighting = UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb * _Ka.rgb;

                    // Diffuse Reflection
                    float3 diffuseReflection = _LightColor0.rgb * _Kd.rgb * max(0, dot(normalDirection, lightDirection));

                    float3 viewDirection = normalize(_WorldSpaceCameraPos - i.posWorld.xyz);
                    // Specular
                    float3 specularReflection;

                    if (dot(i.normal, lightDirection) < 0)
                    {
                        specularReflection = float3(0, 0, 0);
                    }
                    else
                    {
                        specularReflection = _LightColor0.rgb * _SpecColor.rgb * pow(
                            max(0, dot(reflect(-lightDirection, normalDirection), viewDirection)),
                            _Shininess
                        ) * _Ks.rgb;
                    }

                    float3 color = ambientLighting + diffuseReflection * tex2D(_Tex, i.uv) + specularReflection;
                    return float4(color, 1);
                }
            ENDCG
        }
        Pass {
            Tags { "LightMode" = "ForwardAdd" }
            Blend One One // Additive blending

            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                uniform float4 _LightColor0;

                sampler2D _Tex;
                float4 _Tex_ST;

                uniform float4 _Color;
                uniform float4 _SpecColor;
                uniform float _Shininess;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                };
                struct v2f
                {
                    float4 pos : POSITION;
                    float3 normal : NORMAL;
                    float2 uv : TEXCOORD0;
                    float4 posWorld : TEXCOORD1;
                };
                v2f vert(appdata v)
                {
                    v2f o;
                    // Calculate the world position for our point
                    o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                    // Caculate the normal
                    o.normal = normalize(mul(float4(v.normal, 0), unity_WorldToObject).xyz);
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _Tex);

                    return o;
                }
                fixed4 frag(v2f i) : Color
                {
                    float3 normalDirection = i.normal;
                    float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz - i.posWorld.xyz * _WorldSpaceLightPos0.w);

                    // Ambient
                    float3 ambientLighting = UNITY_LIGHTMODEL_AMBIENT.rgb * _Color.rgb;

                    // Diffuse Reflection
                    float3 diffuseReflection = _LightColor0.rgb * _Color.rgb * max(0, dot(normalDirection, lightDirection));

                    float3 viewDirection = normalize(_WorldSpaceCameraPos - i.posWorld.xyz);
                    // Specular
                    float3 specularReflection;

                    if (dot(i.normal, lightDirection) < 0)
                    {
                        specularReflection = float3(0, 0, 0);
                    }
                    else
                    {
                        specularReflection = _LightColor0.rgb * _SpecColor.rgb * pow(
                            max(0, dot(reflect(-lightDirection, normalDirection), viewDirection)),
                            _Shininess
                        );
                    }

                    float3 color = ambientLighting + diffuseReflection * tex2D(_Tex, i.uv) + specularReflection;
                    return float4(color, 1);
                }
            ENDCG
        }
    }
}
