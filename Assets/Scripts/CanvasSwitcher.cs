using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    [SerializeField] private Canvas canvas1;
    [SerializeField] private Canvas canvas2;
    [SerializeField] private Button switchButton;

    void Start()
    {
        // Đảm bảo canvas1 được hiển thị và canvas2 bị ẩn khi bắt đầu
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);

        // Thêm sự kiện khi nút được nhấn
        switchButton.onClick.AddListener(SwitchCanvas);
    }

    void SwitchCanvas()
    {
        // Ẩn canvas1 và hiển thị canvas2
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }
}
