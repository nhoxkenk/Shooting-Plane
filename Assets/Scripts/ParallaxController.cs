using UnityEngine;

namespace PlaneShooter
{
    public class ParallaxController:MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds;   //Array of background layers
        [SerializeField] float smoothing = 10f;     //How smooth the parallax effect is
        [SerializeField] float multiplier = 10f;    //How much the parallax effect increments per layer

        Transform cam;  //Reference to the mainh camera
        Vector3 previousCamPos; //Position of the camera in the previous frame

        private void Awake() => cam = Camera.main.transform;

        private void Start() => previousCamPos = cam.position;

        private void Update()
        {
            for(int i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (multiplier * i);
                var targetY = backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
