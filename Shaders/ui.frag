#version 330

in vec2 texCoord;

out vec4 outputColor;

uniform vec4 color;
uniform sampler2D texture0;

void main()
{
    
    vec4 textureColor = texture(texture0, texCoord); 
    outputColor = textureColor * color;

}