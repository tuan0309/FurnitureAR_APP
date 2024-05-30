using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void OnChairButtonClicked()
    {
        LabelManager.Instance.label = "Chair";
        SceneManager.LoadScene("AR_Scene");
    }

    public void OnFurnituresButtonClicked()
    {
        LabelManager.Instance.label = "Furnitures";
        SceneManager.LoadScene("AR_Scene");
    }

    public void OnOfficeChairButtonClicked()
    {
        LabelManager.Instance.label = "OfficeChair";
        SceneManager.LoadScene("AR_Scene");
    }
}
