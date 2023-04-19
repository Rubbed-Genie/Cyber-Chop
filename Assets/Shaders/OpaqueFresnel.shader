// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9472,x:33533,y:32633,varname:node_9472,prsc:2|emission-4162-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8185,x:32313,y:32678,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_8185,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:9440,x:32590,y:32743,varname:node_9440,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:8496,x:32590,y:32604,varname:node_8496,prsc:2,ntxv:0,isnm:False|TEX-8185-TEX;n:type:ShaderForge.SFN_Fresnel,id:3929,x:32667,y:32972,varname:node_3929,prsc:2|EXP-9803-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9803,x:32589,y:33134,ptovrint:False,ptlb:FresnelValue,ptin:_FresnelValue,varname:node_9803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:78,x:32743,y:33199,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_78,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Power,id:8458,x:32850,y:33015,varname:node_8458,prsc:2|VAL-3929-OUT,EXP-78-OUT;n:type:ShaderForge.SFN_Add,id:4162,x:33074,y:32767,varname:node_4162,prsc:2|A-292-RGB,B-9736-OUT;n:type:ShaderForge.SFN_Multiply,id:5176,x:33050,y:32983,varname:node_5176,prsc:2|A-9440-RGB,B-8458-OUT;n:type:ShaderForge.SFN_Color,id:292,x:32972,y:32577,ptovrint:False,ptlb:Colour,ptin:_Colour,varname:node_292,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9736,x:33266,y:32999,varname:node_9736,prsc:2|A-5176-OUT,B-69-OUT;n:type:ShaderForge.SFN_ValueProperty,id:69,x:33063,y:33165,ptovrint:False,ptlb:FresnalIntescity,ptin:_FresnalIntescity,varname:node_69,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;proporder:8185-9803-78-292-69;pass:END;sub:END;*/

Shader "Custom/OpaqueFresnel" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _FresnelValue ("FresnelValue", Float ) = 1
        _FresnelPower ("FresnelPower", Float ) = 1
        _Colour ("Colour", Color) = (0,0,0,1)
        _FresnalIntescity ("FresnalIntescity", Float ) = 1.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _FresnelValue;
            uniform float _FresnelPower;
            uniform float4 _Colour;
            uniform float _FresnalIntescity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = (_Colour.rgb+((i.vertexColor.rgb*pow(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelValue),_FresnelPower))*_FresnalIntescity));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
