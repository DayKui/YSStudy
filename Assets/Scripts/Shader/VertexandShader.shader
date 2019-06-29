Shader "unlit/VertexandShader" {
	Properties {
		_MainTex("Texture",2D)="white"{}
	}
	SubShader 
	{

		Tags{"LightMode"="ForwardBase"}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "UnityLightingCommon.cginc"
			struct v2f
			{
				float2 uv:TEXCOORD0;
				float4 vertex:SV_POSITION;
				fixed4 diff:COLOR0;
				fixed3 ambient:COLOR1;
			};
			
			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata_base v)
			{
				v2f o;
				o.vertex=UnityObjectToClipPos(v.vertex);
				o.uv=TRANSFORM_TEX(v.texcoord,_MainTex);
				//计算漫反射环境光的颜色
				half3 worldNormal=UnityObjectToWorldNormal(v.normal);
				half nl=max(0,dot(worldNormal,_WorldSpaceLightPos0.xyz));
				o.diff=nl*_LightColor0;
				o.ambient=ShadeSH9(half4(worldNormal,1));
				return o;
			}

			fixed4 frag(v2f i):SV_Target
			{
				fixed4 col=tex2D(_MainTex,i.uv);
				//增加漫反射以及环境光
				fixed3 lighting=i.diff+i.ambient;
				col.rgb*=lighting;
				return col;
			}
			ENDCG
		}
	}
}
