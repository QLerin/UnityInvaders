    Shader "New Shader" {
        Properties {
            _MainTex ("Base (RGB)", 2D) = "white" {}
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 200
           
            CGPROGRAM
            #pragma surface surf Lambert
     
            sampler2D _MainTex;
     
            struct Input {
                float2 uv_MainTex;
            };
     
            void surf (Input IN, inout SurfaceOutput o) {
                fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
				fixed Y = dot (fixed3(0.3, 0.2, 0.4), c.rgb);
				 c= float4 (1, 0, 0, 0.0);
				//o = convert - Y;
                o.Emission = c.rgb;
                o.Alpha = c.a;
            }
            ENDCG
        }
        FallBack "Diffuse"
    }
