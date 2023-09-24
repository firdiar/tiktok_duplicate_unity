using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SetScreenResolution : MonoBehaviour
{
    private async void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(432, 936, false);
        Screen.fullScreen = false;
#endif
        await Task.Delay(500);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
