#version 430 core
layout(binding=0,rgba32f) uniform image2D output_buffer;

in VS_OUT {
    vec3 FragPos;
    vec2 TexCoords;
    vec4 FragPosLightSpace;
} fs_in;

bool bwritedepth;

void main()
{             
   // if(bwritedepth==1)
    {
        vec3 projCoords = fs_in.FragPosLightSpace.xyz / fs_in.FragPosLightSpace.w;
        projCoords = projCoords * 0.5 + 0.5;
//        projCoords.x -= 0.5;
//        projCoords.y -= 0.5;
        float currentDepth = projCoords.z;
        ivec2 size = imageSize(output_buffer);
        imageStore(output_buffer,ivec2(size.x * projCoords.x, size.y * projCoords.y),vec4(currentDepth, 0,0,1));    
    }
}