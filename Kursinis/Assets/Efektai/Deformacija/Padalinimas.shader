 Shader "Padalinimas" {
    Properties {
      _MainTex ("Texture", 2D) = "red" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
	  _Koef("Koef", Float) = 0.001
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Cull Off
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 worldPos;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
	  float _Koef;
      void surf (Input IN, inout SurfaceOutput o) {
		  float value = 1;
		  if ((IN.worldPos.x) > 0.3 && (IN.worldPos.x) < 1.1 )
		  {
			value = 0;
		  }
          clip (value - 0.9);
		  o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }