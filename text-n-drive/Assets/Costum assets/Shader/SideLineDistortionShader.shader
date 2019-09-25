// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/SideLineDistortion"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_cstWidth ("DisScaling", float) = 5

	}

	SubShader
	{

		Cull Off


		Pass{

		CGPROGRAM

		#pragma vertex vertexFunc
		#pragma fragment fragmentFunc
		#include "UnityCG.cginc"
		//#pragma target 2.0
		//#pragma multi_compile_instancing
		//#pragma multi_compile _ PIXELSNAP_ON
		//#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
		//#include "UnitySprites.cginc"

		struct Vertex
		{
			float4 vertex : POSITION;
			float2 uv_MainTex : TEXCOORD0;
			float2 uv2 : TEXCOORD1;
		};
     
		sampler2D _MainTex;

		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv : TEXCOORD0;
			float4 color : COLOR;
		};

		float _cstWidth;

		v2f vertexFunc(appdata_full v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			o.color = v.color;
			float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
			worldPos.y /= 5;

			if (worldPos.y < 0) {
				o.pos.x = o.pos.x + o.pos.x * -worldPos.y*_cstWidth;
			}

			return o;
		}

		float4 _Color;
		float4 _MaintTex_TexelSize;

		fixed4 fragmentFunc(v2f i) : SV_Target {
			return i.color;
		}


		ENDCG
		}
	}
}
