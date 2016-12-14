       Shader "Vertex Modifier" {
         Properties {
           _MainTex ("Texture", 2D) = "white" {}
           _Ampl ("Amplitude", Float) = 1.0
		   _Greitis ("Daznis", Float) = 1.0

         }
         SubShader {
           Tags { "RenderType" = "Opaque" }
           CGPROGRAM
           #pragma surface surf Lambert vertex:vert
           struct Input {
               float2 uv_MainTex;
           };
     
           // Access the shaderlab properties
		   float _Greitis;
           float _Ampl;
           sampler2D _MainTex;
     
           void vert (inout appdata_full v) {
				float phase = _Time * _Greitis*60;
				// v.vertex.y = sin(phase + offset)*0.25;
				if(v.vertex.x == 0 && v.vertex.z == 0)
				{
				v.vertex.y += sin(phase)*_Ampl;
				}
               
           }
     
           // Surface shader function
           void surf (Input IN, inout SurfaceOutput o) {
               o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
           }
           ENDCG
         }
       }