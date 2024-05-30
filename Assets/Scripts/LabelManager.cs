using UnityEngine;

public class LabelManager : MonoBehaviour
{
    private static LabelManager instance;
    public static LabelManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("LabelManager");
                instance = go.AddComponent<LabelManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    public string itemName;
    public string label;
    public float price;
    public Sprite itemImage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
