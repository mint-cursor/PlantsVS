sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float4 uShaderSpecificData;

float4 main(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    color.a = color.r;

    float2 noise_coords =  float2(coords.x, coords.y + uTime);
    float4 noise = tex2D(uImage1, noise_coords);
    noise.a = noise.r; 

    float4 finalColor = color * noise * 3;
    finalColor.rgb += color.rgb;
    finalColor.rgb *= float3(1.0 ,0.4 ,0.0);


    return finalColor;
}

technique Technique1
{
    pass FireAuraPass
    {
        PixelShader = compile ps_3_0 main();
    }
}

