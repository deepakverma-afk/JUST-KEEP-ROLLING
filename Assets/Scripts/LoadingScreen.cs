
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Loading screen started!");
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(1.5f);

        Debug.Log("Attempting to load Game...");

        AsyncOperation operation =
            SceneManager.LoadSceneAsync("Game");

        if (operation == null)
        {
            Debug.LogError("Game scene could not be loaded!");
            yield break;
        }

        while (!operation.isDone)
        {
            Debug.Log("Loading progress: " + operation.progress);
            yield return null;
        }

        Debug.Log("Game loaded!");
    }
}
