Shader "Fonas/Red" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_Koef("Koef", Float) = 0

}

SubShader {
	Pass {
		ZTest Always
		Cull Off 
		ZWrite Off
				
		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag
		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		float _Koef;

		fixed4 frag (v2f_img i) : SV_Target
		{	
			if (_Koef == 1)
			{
			fixed4 original = tex2D(_MainTex, i.uv);
	
			fixed Y = dot (fixed3(0.3, 0.2, 0.4), original.rgb);
			fixed4 convert = float4 (1, 0, 0, 0.0);
			fixed4 output = convert - Y;
			output.a = original.a;
	
			return output;
			};
			fixed4 original = tex2D(_MainTex, i.uv);
			return original;
		}
		ENDCG

		}
}

Fallback off

}
