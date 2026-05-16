using UnityEngine;

public class VRGazeDetector : MonoBehaviour
{
    public float gazeTime = 1f;

    private float timer = 0f;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("VRTarget"))
            {
                timer += Time.deltaTime;

                if (timer >= gazeTime)
                {
                    Destroy(hit.collider.gameObject);
                    timer = 0f;
                }
            }
            else
            {
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
}