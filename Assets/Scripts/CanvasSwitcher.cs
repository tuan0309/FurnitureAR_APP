using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas canvas1;
    [SerializeField] private Canvas canvas2;
    [SerializeField] private Button switchButton;

    void Start()
    {
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);

        switchButton.onClick.AddListener(SwitchCanvas);
    }

    void SwitchCanvas()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }
}
