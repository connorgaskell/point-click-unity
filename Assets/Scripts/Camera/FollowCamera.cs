using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private Transform camPivot;

    private Vector3 localRotation;
    private float cameraDistance = 5f;

    public Transform player;
    public float mouseSensitivity = 3.0f;
    public float scrollSensitivity = 2.0f;
    public float orbitDampening = 10.0f;
    public float scrollDampening = 6.0f;
    public float minZoom = 2.0f;
    public float maxZoom = 20.0f;

    void Start() {
        camPivot = transform.parent;
    }

    void LateUpdate() {
        float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
        scrollAmount *= cameraDistance * 0.3f;

        cameraDistance += scrollAmount * -1f;
        cameraDistance = Mathf.Clamp(cameraDistance, minZoom, maxZoom);

        if(Input.GetMouseButton(2)) {
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                localRotation.y = Mathf.Clamp(localRotation.y, 10.0f, 90.0f);
            }
        }

        camPivot.rotation = Quaternion.Lerp(
            camPivot.rotation, 
            Quaternion.Euler(localRotation.y, localRotation.x, 0), 
            orbitDampening * Time.deltaTime
        );

        camPivot.localPosition = new Vector3(
            Mathf.Lerp(camPivot.localPosition.x, player.position.x, orbitDampening * Time.deltaTime),
            1f,
            Mathf.Lerp(camPivot.localPosition.z, player.position.z, orbitDampening * Time.deltaTime)
        );

        transform.localPosition = new Vector3(
            0f, 
            0f, 
            Mathf.Lerp(transform.localPosition.z, cameraDistance * -1f, scrollDampening * Time.deltaTime)
        );
    }

}
