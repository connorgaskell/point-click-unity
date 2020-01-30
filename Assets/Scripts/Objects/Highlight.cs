using UnityEngine;

public class Highlight : MonoBehaviour {

    public Renderer rend;

    void OnMouseOver() {
        rend.material.shader = Shader.Find("Outlined/Diffuse");
    }

    void OnMouseExit() {
        rend.material.shader = Shader.Find("Diffuse");
    }
    
}
