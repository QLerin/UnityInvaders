
Shader "Deformacija/Svyravimas" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
    _DecalTex ("Decal (RGBA)", 2D) = "white" {}
	
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

	CGPROGRAM
	#pragma surface surf Lambert vertex:vert addshadow

	sampler2D _MainTex;
	sampler2D _DecalTex;
	fixed4 _Color;

	struct Input {
		float2 uv_MainTex : TEXCOORD0;
		float2 uv_DecalTex :   TEXCOORD1;
	};

	 void vert (inout appdata_full v) {
     float4 wpos = mul( _Object2World, v.vertex);
     float4 opos = mul( _Object2World, float4(0,0,0,1) );
     float phase = _Time * 25.0 + opos.x * 0.6 + opos.z * 0.05 ;
     wpos.x = wpos.x + sin(phase) * wpos.y*0.3;
     v.vertex = mul(_World2Object, wpos );
     v.vertex.xyz *= 1.0;
 }


	void surf (Input IN, inout SurfaceOutput o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		fixed4 d = tex2D (_DecalTex, IN.uv_DecalTex);

		o.Albedo = lerp(c, d, d.a);
		o.Alpha = c.a;
	}
	ENDCG
	}

//Fallback "VertexLit"
}
