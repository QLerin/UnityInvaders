Shader "Blend/Blyksejimas" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
    _DecalTex ("Decal (RGBA)", 2D) = "red" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

	CGPROGRAM
	#pragma surface surf Lambert vertex:vert addshadow

	sampler2D _MainTex;
	sampler2D _DecalTex;

	struct Input {
		float2 uv_MainTex : TEXCOORD0;
		float2 uv_DecalTex :   TEXCOORD1;
	};



	void vert (inout appdata_full v) 
	{

	}


	void surf (Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex); 
		fixed4 d = tex2D (_DecalTex, IN.uv_DecalTex); 
		float k = abs(sin(60*_Time));
		o.Albedo = lerp(c, d, k);
		o.Alpha = c.a;
	}
		ENDCG
}

Fallback "VertexLit"
}
