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

    public string label;

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
