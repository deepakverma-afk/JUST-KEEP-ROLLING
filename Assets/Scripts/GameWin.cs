
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameWin : MonoBehaviour
{
    public GameObject winPanel;

    public float menuDelay = 3f;
    public string mainMenuScene = "MainMenu";

    private bool gameFinished = false;

    void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !gameFinished)
        {
            gameFinished = true;
            StartCoroutine(ShowWinScreen());
        }
    }

    IEnumerator ShowWinScreen()
    {
        yield return new WaitForSeconds(1f);

        winPanel.SetActive(true);

        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(menuDelay);

        Time.timeScale = 1f;

        SceneManager.LoadScene(mainMenuScene);
    }
}
