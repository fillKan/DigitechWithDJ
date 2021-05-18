using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        float ratio = Mathf.Clamp(1024f / Screen.height, 0f, 1f);

        Screen.SetResolution((int)(Screen.width * ratio), (int)(Screen.height * ratio), true, 60);
    }

    public void Load(string name)
    {
        StartCoroutine(ELoad(name));
    }
    private IEnumerator ELoad(string name)
    {
        yield return SceneManager.LoadSceneAsync(name);
    }
}
