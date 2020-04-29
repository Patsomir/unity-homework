﻿Shader "Unlit/SharpPixelizationShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Width("PixelsOnWidth", Int) = 600
        _Height("PixelsOnHeight", Int) = 400
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fog

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                int _Width;
                int _Height;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float u = floor(i.uv.x * _Width) / _Width;
                    float v = floor(i.uv.y * _Height) / _Height;
                    fixed4 col = tex2D(_MainTex, fixed2(u, v));
                    return col;
                }
                ENDCG
            }
        }
}
