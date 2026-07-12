shader_type canvas_item;

uniform float progress : hint_range(0.0, 1.0) = 1.0;
uniform sampler2D noise_texture; 
uniform float noise_strength : hint_range(0.0, 1.0) = 0.3; 
uniform vec2 noise_speed = vec2(0.1, 0.1);

void fragment() {
	float noise_strengt = noise_strength * (1.0+0.1*sin(TIME));
    vec4 tex_color = texture(TEXTURE, UV);
    
    vec2 center = vec2(0.5, 0.5);
    float base_dist = distance(UV, center);
	
	vec2 moving_uv = UV + (TIME * noise_speed);
    
    float noise_val = texture(noise_texture, UV).r;
    
    float distorted_dist = base_dist + (noise_val - 0.5) * noise_strengt;
    
    float threshold = progress * (0.707 + noise_strengt);
    
    if (distorted_dist > threshold) {
        tex_color.a = 0.0;
    }
    
    COLOR = tex_color;
}