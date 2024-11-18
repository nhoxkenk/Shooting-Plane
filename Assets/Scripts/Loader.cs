using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlaneShooter
{
    public static class Loader
    {
        static string targetSceneName;
        public static void Load(string sceneName)
        {
            targetSceneName = sceneName;
            SceneManager.LoadScene("Loading");
            Timing.RunCoroutine(LoadTargetScene());
        }

        static IEnumerator<float> LoadTargetScene()
        {
            yield return Timing.WaitForOneFrame;
            SceneManager.LoadScene(targetSceneName);
        }
    }

}
