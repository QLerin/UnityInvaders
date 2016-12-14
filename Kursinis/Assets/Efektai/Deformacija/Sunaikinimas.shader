 Shader "Sunaikinimas" {
    Properties {
      _MainTex ("Texture", 2D) = "red" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
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
          float3 worldPos;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
	  float _Koef;
	  void vert (inout appdata_full v) {
				float scale = 1 / length(_Object2World[0].xyz);
				if(v.vertex.x > 0)
				{
					v.vertex.x += _Koef*scale/8;
				}
				if(v.vertex.x < 0)
				{
					v.vertex.x -= _Koef*scale/8;
				}
				if(v.vertex.z > 0)
				{
					v.vertex.z += _Koef*scale/8;
				}
				if(v.vertex.z < 0)
				{
					v.vertex.z -= _Koef*scale/8;
				}
	   }

      void surf (Input IN, inout SurfaceOutput o) {
          clip (frac((IN.worldPos.y+IN.worldPos.x*0.9) * 50) - _Koef);
		  o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }