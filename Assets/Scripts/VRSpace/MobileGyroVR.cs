using UnityEngine;

public class MobileGyroVR : MonoBehaviour
{
    private Gyroscope gyro;

    void Start()
    {
        // bloquear orientación
        Screen.orientation =
            ScreenOrientation.Portrait;

        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortraitUpsideDown = false;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        if (gyro != null)
        {
            Quaternion deviceRotation = gyro.attitude;

            transform.localRotation =
                Quaternion.Euler(90, 0, 0) *
                new Quaternion(
                    -deviceRotation.x,
                    -deviceRotation.y,
                    deviceRotation.z,
                    deviceRotation.w
                );
        }
    }
}