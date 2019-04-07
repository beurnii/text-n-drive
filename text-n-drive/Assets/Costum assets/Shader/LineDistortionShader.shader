// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Custom/LineDistortion"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_cstWidth("DisScaling", float) = 5
		//_lengthDis("Length Distortion Scaler", float) = 1
		_initHeight("Initial Height", float) = 0
		_sideSpeed("Side Speed", float) = 2.5
	}

	SubShader
	{

		Cull Off


		Pass{

		CGPROGRAM

		#pragma vertex vertexFunc
		#pragma fragment fragmentFunc
		#include "UnityCG.cginc"

     
		sampler2D _MainTex;

		struct v2f {
			float4 pos : SV_POSITION;
			half2 uv : TEXCOORD0;
			float4 color : COLOR;
		};

		float _cstWidth;
		//float _lengthDis = 2;
		float _initHeight;
		float _sideSpeed;

		v2f vertexFunc(appdata_full v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;
			o.color = v.color;

			o.pos.y = pow((o.pos.y - _initHeight /5), 5) * 1 + _initHeight /5;
			o.pos.y *= 1 + abs(o.pos.x)*_sideSpeed;

			o.pos.x = o.pos.x - o.pos.x * (o.pos.y - _initHeight / 5)*_cstWidth;

			return o;
		}

		fixed4 fragmentFunc(v2f i) : SV_Target{
			float4 mainTexture = tex2D(_MainTex, i.uv.xy);


			return mainTexture;
		}


		ENDCG
		}
	}
}
