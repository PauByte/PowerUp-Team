using UnityEngine;

public class MobileGyroVR : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        EnableGyro();
#endif
    }

    void Update()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (gyroEnabled)
        {
            transform.localRotation =
                gyro.attitude * Quaternion.Euler(90f, 0f, 0f);
        }
#endif
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroEnabled = true;
            return true;
        }

        return false;
    }
}