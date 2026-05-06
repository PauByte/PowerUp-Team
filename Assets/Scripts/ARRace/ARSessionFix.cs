using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections;

public class ARSessionFix : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null;

        ARSession session = FindFirstObjectByType<ARSession>();

        if (session != null)
        {
            session.enabled = false;
            yield return null;
            session.enabled = true;
        }
    }
}
