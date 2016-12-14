Shader "Deformacija/Padidejimas" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
    _DecalTex ("Decal (RGBA)", 2D) = "white" {}
	_Koef2("Koef2", Float) = 0
	
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

	CGPROGRAM
	#pragma surface surf Lambert vertex:vert addshadow

	sampler2D _MainTex;
	sampler2D _DecalTex;
	float _Koef2;

	struct Input {
		float2 uv_MainTex : TEXCOORD0;
		float2 uv_DecalTex :   TEXCOORD1;
	};

	void vert (inout appdata_full v) 
	{
		float4x4 matrixS = {
			1.5, 0, 0, 0,
			0, 1.5, 0, 0,
			0, 0, 1.5, 0,
			0, 0, 0, 1 
		};
		v.vertex = mul(float4(v.vertex.xyz, 1.0f), matrixS);
	}


	void surf (Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
		fixed4 d = tex2D (_DecalTex, IN.uv_DecalTex);

		o.Albedo = lerp(c, d, _Koef2);
		o.Alpha = c.a;
	}
	ENDCG
	}

	Fallback "VertexLit"
}
