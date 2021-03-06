﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Hidden/SSAO2D"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}

	CGINCLUDE
		#pragma fragmentoption ARB_precision_hint_fastest
		#pragma exclude_renderers flash
		#include "UnityCG.cginc"
	ENDCG

	SubShader
	{
		Cull Off ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

            sampler2D _CameraDepthTexture;
            half intensity;
            half spread;
			half2 offset;
			half cutoff;
			half threshold;

			static const fixed2 samples[16] = {
					fixed2(0.0, 1.0 * _ScreenParams.x/_ScreenParams.y),
					fixed2(1.0, 0.0),
					fixed2(0.0, -1.0* _ScreenParams.x/_ScreenParams.y),
					fixed2(-1.0, 0.0),
					fixed2(0.383, 0.924 * _ScreenParams.x/_ScreenParams.y),
					fixed2(0.707, 0.707 * _ScreenParams.x/_ScreenParams.y),
					fixed2(0.924, 0.383 * _ScreenParams.x/_ScreenParams.y),
					fixed2(0.924, -0.383* _ScreenParams.x/_ScreenParams.y),
					fixed2(0.707, -0.707* _ScreenParams.x/_ScreenParams.y),
					fixed2(0.383, -0.924* _ScreenParams.x/_ScreenParams.y),
					fixed2(-0.383, -0.924* _ScreenParams.x/_ScreenParams.y),
					fixed2(-0.707, -0.707 * _ScreenParams.x/_ScreenParams.y),
					fixed2(-0.924, -0.383* _ScreenParams.x/_ScreenParams.y),
					fixed2(-0.924, 0.383 * _ScreenParams.x/_ScreenParams.y),
					fixed2(-0.707, 0.707 * _ScreenParams.x/_ScreenParams.y),
					fixed2(-0.383, 0.924 * _ScreenParams.x/_ScreenParams.y)
			};

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

			v2f vert (appdata v)
			{
				v2f o;

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;


			fixed4 frag (v2f i) : SV_Target
			{
				fixed baseDepth = tex2D(_CameraDepthTexture, i.uv).r;
				fixed ambientColor = 1.0;
				offset+=i.uv;
				for (int s=0; s<16; s++){
					fixed diff = baseDepth - tex2D(_CameraDepthTexture, offset + samples[s] * spread).r; 
					if (diff > threshold && diff < cutoff)
					{
						ambientColor -= (cutoff - clamp(diff, cutoff, threshold))*intensity;
					}
				}
				fixed4 col = tex2D(_MainTex, i.uv);
				return fixed4(col.r*ambientColor,col.g*ambientColor, col.b*ambientColor, col.a);
			}
			ENDCG
		}
	}
}
