using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPvP()
    {
        SceneManager.LoadScene("PlayableScene");
    }
    public void loadPvAI()
    {
        SceneManager.LoadScene("LearningSceneVsPlayer");
    }
    public void loadAIvAI()
    {
        SceneManager.LoadScene("LearningScene");
    }
}
