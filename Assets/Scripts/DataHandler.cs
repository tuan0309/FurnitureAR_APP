using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> _items;
    [SerializeField] private Button addButton;


    private int id = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    private async void Start()
    {
        _items = new List<Item>();
        string label = LabelManager.Instance.label; // Lấy label từ LabelManager
        await Get(label);
        CreateButtons();

        addButton.onClick.AddListener(OnAddButtonClicked);
    }

    void CreateButtons()
    {
        foreach (Item i in _items)
        {
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = id;
            b.ButtonTexture = i.itemImage;
            id++;
        }
        buttonContainer.GetComponent<UIContentFitter>().Fit();
    }

    public void SetFurniture(int id)
    {
        if (id >= 0 && id < _items.Count)
        {
            furniture = _items[id].itemPrefab;
            LabelManager.Instance.itemName = _items[id].itemName;
            LabelManager.Instance.price = _items[id].price;
            LabelManager.Instance.itemImage = _items[id].itemImage;
        }
        else
        {
            Debug.LogError("Invalid furniture id. Make sure the id is within the range of available items.");
        }
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

    public async Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            _items.Add(obj);
        }
    }
    private void OnAddButtonClicked()
    {
        SceneManager.LoadScene("Cart_Scene");
    }
}
