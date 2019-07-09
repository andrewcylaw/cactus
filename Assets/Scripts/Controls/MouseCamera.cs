using UnityEngine;

namespace Controls {
    public class MouseCamera : MonoBehaviour {

        public float speed;
        public int cameraMouseDelta; // In pixels
        public int lBound, rBound; // Left right camera bounds
        public Camera mainCamera;
    
        /**
         * Checks if the user's mouse is on one of the left/right edges and moves the camera.
         */
        void Update() {
            if (Input.mousePosition.x >= Screen.width - cameraMouseDelta && mainCamera.transform.position.x < rBound) {
                mainCamera.transform.position += Time.deltaTime * speed * Vector3.right;
            } else if (Input.mousePosition.x <= cameraMouseDelta && mainCamera.transform.position.x > lBound) {
                mainCamera.transform.position += Time.deltaTime * speed * Vector3.left;
            }
        }
    }
}
