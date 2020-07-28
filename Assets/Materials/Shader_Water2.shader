Shader "Unlit/Shader_Water2"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float WaveletNoise(float2 p, float z, float k) {
                float d = 0., s = 1., m = 0., a;
                for (float i = 0.; i < 4.; i++) {
                    float2 q = p * s, g = frac(floor(q) * float2(123.34, 233.53));
                    g += dot(g, g + 23.234);
                    a = frac(g.x * g.y) * 1e3;// +z*(mod(g.x+g.y, 2.)-1.); // add vorticity
                    q = mul((frac(q) - .5), float2x2(cos(a), -sin(a), sin(a), cos(a)));
                    d += sin(q.x * 10. + z) * smoothstep(.25, .0, dot(q, q)) / s;
                    p = mul(p,float2x2(.54, -.84, .84, .54) + i);
                    m += 1. / s;
                    s *= k;
                }
                return d / m;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;

                float3 col = 0.0f;

                col += WaveletNoise(uv * 5., _Time.y, 1.22) * .5 + .5;
                if (col.r > .99) col = float3(1, 0, 0);
                if (col.r < 0.01) col = float3(0, 0, 1);

                return float4(col, 1.0);
            }
            ENDCG
        }
    }
}
