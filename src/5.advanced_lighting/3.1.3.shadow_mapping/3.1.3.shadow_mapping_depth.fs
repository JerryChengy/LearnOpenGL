#version 430 core
layout(binding=0,rgba32f) uniform image2D output_buffer;
in vec4 FragPosLightSpace;
void main()
{             
     vec3 projCoords = FragPosLightSpace.xyz / FragPosLightSpace.w;
        projCoords = projCoords * 0.5 + 0.5;
float currentDepth = projCoords.z;
ivec2 size = imageSize(output_buffer);
        imageStore(output_buffer,ivec2(size.x * projCoords.x, size.y * projCoords.y),vec4(currentDepth, 0,0,1));    
    // gl_FragDepth = gl_FragCoord.z;
}