using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TItleUI : MonoBehaviour
{
    public void Enter() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit() 
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif

        Application.Quit();
    }
}
