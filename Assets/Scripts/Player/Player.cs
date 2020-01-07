using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public LayerMask groundLayer;

    Camera cam;
    PlayerNavigation nav;

    void Start() {
        cam = Camera.main;
        nav = GetComponent<PlayerNavigation>();
    }

    void Update() {
        if(Input.GetMouseButton(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, groundLayer)) {
                nav.MoveTo(hit.point);
            }
        }

        if(Input.GetMouseButtonDown(1)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) {
                
            }
        }
    }
}
