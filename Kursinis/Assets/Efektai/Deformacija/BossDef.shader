 Shader "Sprogimas/BosoSprogimas" {
    Properties {
      _MainTex ("Texture", 2D) = "red" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
	  _DecalTex ("Decal (RGBA)", 2D) = "red" {}
	  _Koef("Koef", Float) = 0.001
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Cull Off
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
		  float2 uv_DecalTex;
          float3 worldPos;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
	  sampler2D _DecalTex;
	  float _Koef;
	  
	  void vert (inout appdata_full v) {
		    float4x4 matrixS = {
				1+(_Koef*0.8), 0, 0, 0,
				0, 1, 0, 0,
				0, 0, 1+(_Koef*0.8), 0,
				0, 0, 0, 1 
			};
			v.vertex = mul(float4(v.vertex.xyz, 1.0f), matrixS);
	   }
	  
      void surf (Input IN, inout SurfaceOutput o) {
		  float value = 1;
		  if ((IN.worldPos.x) > -_Koef && (IN.worldPos.x) < _Koef )
		  {
			value = -1;
		  }
          clip (value);
		  fixed4 c = tex2D(_MainTex, IN.uv_MainTex); 
		  fixed4 d = tex2D (_DecalTex, IN.uv_DecalTex); 
		  float k = abs(sin(60*_Time));
		  o.Albedo = lerp(c, d, k);
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }