#version 430 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 aTextcoords;

uniform mat4 lightSpaceMatrix;
uniform mat4 model;
 out vec2 texcoords;
 
 out VS_OUT {
     vec3 FragPos;
     vec2 TexCoords;
     vec4 FragPosLightSpace;
 } vs_out;

void main()
{
    vs_out.FragPos = vec3(model * vec4(aPos, 1.0));
    vs_out.TexCoords = aTextcoords;
    vs_out.FragPosLightSpace = lightSpaceMatrix * vec4(vs_out.FragPos, 1.0);
    gl_Position = lightSpaceMatrix * model * vec4(aPos, 1.0);
}