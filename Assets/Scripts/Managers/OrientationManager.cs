using UnityEngine;

public class OrientationManager : MonoBehaviour
{
    public bool usePortrait = false;

    void Awake()
    {
        if (usePortrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation =
                ScreenOrientation.LandscapeLeft;
        }
    }
}