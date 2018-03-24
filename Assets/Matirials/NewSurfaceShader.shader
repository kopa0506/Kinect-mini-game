Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		[PerRendererData]_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Cutoff("Shadow alpha cutoff", Range(0,1)) = 0.5
		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags {  "Queue"="Geometry"
				"RenderType"="Transparent"}
		LOD 200
		Cull Off
		CGPROGRAM
		// Lambert lighting model, and enable shadows on all light types
		
		#pragma surface surf Lambert addshadow fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		fixed _Cutoff;
		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			clip(o.Alpha-_Cutoff);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
