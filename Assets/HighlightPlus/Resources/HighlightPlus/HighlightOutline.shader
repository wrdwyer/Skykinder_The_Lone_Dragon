Shader "HighlightPlus/Geometry/Outline" {
Properties {
    _MainTex ("Texture", Any) = "white" {}
    _OutlineColor ("Outline Color", Color) = (0,0,0,1)
    _OutlineWidth ("Outline Offset", Float) = 0.01
    _OutlineDirection("Outline Direction", Vector) = (0,0,0)
    _OutlineGradientTex("Outline Gradient Tex", 2D) = "white" {}
    _Color ("Color", Color) = (1,1,1) // not used; dummy property to avoid inspector warning "material has no _Color property"
    _Cull ("Cull Mode", Int) = 2
    _ConstantWidth ("Constant Width", Float) = 1
	_OutlineZTest("ZTest", Int) = 4
}
    SubShader
    {
        Tags { "Queue"="Transparent+120" "RenderType"="Transparent" "DisableBatching"="True" }

        Pass
        {
            Name "Outline"
            Stencil {
                Ref 2
                Comp NotEqual
                Pass replace
                ReadMask 2
                WriteMask 2
            }

            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            Cull [_Cull]
            ZTest [_OutlineZTest]

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile_local _ HP_ALPHACLIP
            #pragma multi_compile_local _ HP_OUTLINE_GRADIENT_WS HP_OUTLINE_GRADIENT_LS
            #include "UnityCG.cginc"
            #include "CustomVertexTransform.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                fixed yt : TEXCOORD0;
				UNITY_VERTEX_OUTPUT_STEREO
            };

            fixed4 _OutlineColor;
            sampler2D _OutlineGradientTex;

            float _OutlineWidth;
            float _ConstantWidth;
            float _OutlineVertexWidth;
            fixed2 _OutlineVertexData;

            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(float4, _OutlineDirection)
            UNITY_INSTANCING_BUFFER_END(Props)
            
            v2f vert (appdata v)
            {
                v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_OUTPUT(v2f, o);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                #if HP_OUTLINE_GRADIENT_WS
                    float posy = mul(unity_ObjectToWorld, v.vertex).y;
                    o.yt = saturate( (posy - _OutlineVertexData.x) / _OutlineVertexData.y);
                #else
                    o.yt = saturate( (v.vertex.y - _OutlineVertexData.x) / _OutlineVertexData.y);
                #endif

                v.vertex.xyz += v.normal * _OutlineVertexWidth;
                o.pos = ComputeVertexPosition(v.vertex);
				float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(normalize(norm.xy));
				float z = lerp(UNITY_Z_0_FAR_FROM_CLIPSPACE(o.pos.z), 2.0, UNITY_MATRIX_P[3][3]);
                z = _ConstantWidth * (z - 2.0) + 2.0;

                float4 outlineDirection =  UNITY_ACCESS_INSTANCED_PROP(Props, _OutlineDirection); 
                #if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED) || defined(SINGLE_PASS_STEREO)
                    outlineDirection.x *= 2.0;
                #endif
				o.pos.xy += offset * z * _OutlineWidth + outlineDirection.xy * z;
                return o;
            }

            
            fixed4 frag (v2f i) : SV_Target
            {
                #if HP_OUTLINE_GRADIENT_WS || HP_OUTLINE_GRADIENT_LS
                    half4 color = tex2D(_OutlineGradientTex, float2(i.yt, 0));
                    color.a *= _OutlineColor.a;
                #else
                    half4 color = _OutlineColor;
                #endif
                return color;
            }
            ENDCG
        }

        Pass
        {
            Name "Outline Clear Stencil"
            Stencil {
                Ref 2
                Comp Always
                Pass zero
            }

            ColorMask 0
            ZWrite Off
            Cull [_Cull]
            ZTest Always

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "CustomVertexTransform.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            fixed4 _OutlineColor;
            float _OutlineWidth;
            float2 _OutlineDirection;
            float _ConstantWidth;
            float _OutlineVertexWidth;
            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                v.vertex.xyz += v.normal * _OutlineVertexWidth;
                o.pos = ComputeVertexPosition(v.vertex);
                float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                float2 offset = TransformViewToProjection(normalize(norm.xy));
                float z = lerp(UNITY_Z_0_FAR_FROM_CLIPSPACE(o.pos.z), 2.0, UNITY_MATRIX_P[3][3]);
                z = _ConstantWidth * (z - 2.0) + 2.0;
                o.pos.xy += offset * z * _OutlineWidth + _OutlineDirection * z;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                return 0;
            }
            ENDCG
        }
    }
}