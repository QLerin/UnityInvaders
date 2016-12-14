Shader "Cg shader for vertex blending" {
   SubShader {
      Pass {   
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         #include "UnityCG.cginc"
 
         // Uniforms set by a script
         uniform float4x4 _Trafo0; // model transformation of bone0
         uniform float4x4 _Trafo1; // model transformation of bone1
 
         struct vertexInput {
            float4 vertex : POSITION;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 col : COLOR;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
            float weight0 = input.vertex.z + 0.5; 
               // depends on the mesh
            float4 blendedVertex = 
               weight0 * mul(_Trafo0, input.vertex) 
               + (1.0 - weight0) * mul(_Trafo1, input.vertex);
 
            output.pos = mul(UNITY_MATRIX_VP, blendedVertex);
 
            output.col = float4(weight0, 1.0 - weight0, 0.0, 1.0); 
               // visualize weight0 as red and weight1 as green
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
            return input.col;
         }
 
         ENDCG
      }
   }
}