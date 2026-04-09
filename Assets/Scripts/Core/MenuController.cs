using UnityEngine;
/*
 script para el botón de PLAY    
 
 */
public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneFlowManager.Instance.LoadNextScene();
    }
}
