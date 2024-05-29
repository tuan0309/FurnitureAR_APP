using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarController : MonoBehaviour
{
    public Image progressBar;
    private float progress = 0f;
    private float duration = 3.0f;
    public RectTransform icon;
    public RectTransform loadingBarBackground;

    void Update()
    {
        if (progress < 1.0f)
        {
            progress += Time.deltaTime / duration;
            progressBar.fillAmount = progress;

            float iconPosition = Mathf.Lerp(loadingBarBackground.rect.xMin, loadingBarBackground.rect.xMax, progress);
            icon.anchoredPosition = new Vector2(iconPosition, icon.anchoredPosition.y);
        }
        else
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
