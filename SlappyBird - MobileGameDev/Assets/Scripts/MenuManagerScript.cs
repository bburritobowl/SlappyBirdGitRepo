using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public void BirdClick()
    {
        SceneManager.LoadScene("BirbLevel");
    }

    public void TannerClick()
    {
        SceneManager.LoadScene("TannerLevel");
    }
}
















