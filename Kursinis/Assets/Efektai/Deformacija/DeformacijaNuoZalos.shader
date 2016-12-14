Shader "Deformacija/NuoZalos" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
    _DecalTex ("Decal (RGBA)", 2D) = "white" {}
	_Koef("Koef", Float) = 0
	_Koef2("Koef2", Float) = 0
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

	CGPROGRAM
	#pragma surface surf Lambert vertex:vert addshadow

	sampler2D _MainTex;
	sampler2D _DecalTex;
	float _Koef;
	float _Koef2;

	struct Input {
		float2 uv_MainTex : TEXCOORD0;
		float2 uv_DecalTex :   TEXCOORD1;
	};



	void vert (inout appdata_full v) 
	{
		if (_Koef != 1)
		{
			float scale = 1 / length(_Object2World[0].xyz);
			float to = v.vertex.x + v.vertex.y + v.vertex.z;
			float f = to * _Koef;
			v.vertex.xyz += v.vertex.xyz * 0.12 * f * scale;
		}
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
