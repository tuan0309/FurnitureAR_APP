using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private TextMeshProUGUI totalPriceText;
    [SerializeField] private Button minusButton;
    [SerializeField] private Button plusButton;

    private float quantity = 1;
    private float price;
    void Start()
    {
        float price = LabelManager.Instance.price;
        Sprite image = LabelManager.Instance.itemImage;
        string itemName = LabelManager.Instance.itemName;

        priceText.text = $"{price}$";
        itemImage.sprite = image;
        itemNameText.text = itemName;

        UpdateQuantityAndTotalPrice();

        minusButton.onClick.AddListener(OnMinusButtonClicked);
        plusButton.onClick.AddListener(OnPlusButtonClicked);
    }
    void UpdateQuantityAndTotalPrice()
    {
        float price = LabelManager.Instance.price;
        quantityText.text = quantity.ToString();

        float totalPrice = price * quantity;
        totalPriceText.text = $"{totalPrice}$";
    }

    void OnMinusButtonClicked()
    {
        if (quantity > 1)
        {
            quantity--;
            UpdateQuantityAndTotalPrice();
        }
    }

    void OnPlusButtonClicked()
    {
        quantity++;
        UpdateQuantityAndTotalPrice();
    }
}

