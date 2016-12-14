Shader "Custom/Fonas" {
Properties{
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #pragma target 3.0

            #include "UnityCG.cginc"

			uniform sampler2D _MainTex;
            
            float4 frag(v2f_img i) : SV_Target {
                float2 mcoord;
                float2 coord = float2(0.0,0.0);
                mcoord.x = ((1.0-i.uv.x)*3.5)-2.5;
                mcoord.y = (i.uv.y*2.0)-1.0;
                float iteration = 0.0;
                const float _MaxIter = 30.0;
                const float PI = 3.14159;
                float xtemp;
                for ( iteration = 0.0; iteration < _MaxIter; iteration += 1.0) {
                    if ( coord.x*coord.x + coord.y*coord.y > 100.0*(cos(fmod(0,2.0*PI))+1.0) )
                    break;
                    xtemp = coord.x*coord.x - coord.y*coord.y + mcoord.x - 0.52;
                    coord.y = 2.0*coord.x*coord.y + mcoord.y;
                    coord.x = xtemp;

                }
                float val = fmod((iteration/_MaxIter),1.0);
                float4 color;

                color.r = clamp((0.1*abs(fmod(2.0*val,1.0)-0.5)),0.0,1.0);
                color.g = clamp((0.1*abs(fmod(2.0*val+(1.0/3.0),1.0)-0.5)),0.0,1.0);
                color.b = clamp((1*abs(fmod(2.0*val-(1.0/3.0),1.0)-0.5)),0.0,1.0);
                color.a = 1.0;
                fixed4 c = tex2D(_MainTex, i.uv)* color;
				return c;
            }
            ENDCG
        }
    }
}