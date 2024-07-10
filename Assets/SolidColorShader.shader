Shader "Custom/SolidColorShader"

    {
        Properties
        {
            _MainTex("Texture", 2D) = "white" {}  // Textura do sprite
            _Color("Color", Color) = (1, 1, 1, 1)  // Cor a ser aplicada
            _Intensity("Intensity", Range(0, 10)) = 1.0  // Intensidade da cor
        }
            SubShader
            {
                Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
                LOD 100

                Pass
                {
                    Blend SrcAlpha OneMinusSrcAlpha
                    Cull Off
                    ZWrite Off
                    ZTest Always

                    CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #include "UnityCG.cginc"

                    struct appdata_t
                    {
                        float4 vertex : POSITION;
                        float2 texcoord : TEXCOORD0;
                    };

                    struct v2f
                    {
                        float2 texcoord : TEXCOORD0;
                        float4 vertex : SV_POSITION;
                    };

                    sampler2D _MainTex;
                    fixed4 _Color;
                    float _Intensity;

                    v2f vert(appdata_t v)
                    {
                        v2f o;
                        o.vertex = UnityObjectToClipPos(v.vertex);
                        o.texcoord = v.texcoord;
                        return o;
                    }

                    fixed4 frag(v2f i) : SV_Target
                    {
                        fixed4 texColor = tex2D(_MainTex, i.texcoord);
                    // Multiplica a cor pela intensidade e pela cor original da textura
                    fixed4 outputColor = texColor * _Color * _Intensity;
                    return outputColor;
                }
                ENDCG
            }
            }
    }