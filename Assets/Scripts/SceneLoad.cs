using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private AsyncOperation mAsnycSceneLoad;

    private ParticleSystem ParticleSystem;

    private void AAA()
    {
        ParticleSystem.Play();
    }

    public void MainGameLoad()
    {
        if (mAsnycSceneLoad.progress >= 0.9f)
            mAsnycSceneLoad.allowSceneActivation = true;
    }

    private void Start()
    {
        mAsnycSceneLoad =
           SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        mAsnycSceneLoad.allowSceneActivation = false;
    }
}
