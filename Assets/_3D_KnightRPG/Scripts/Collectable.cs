public class Collectable : UnityEngine.MonoBehaviour
{
    public enum Type : System.UInt32
    {
        Undefined = 0,
        Material = 1,
        Leaf = 2
    }

    [UnityEngine.SerializeField]
    protected Type collectableType = Type.Undefined;
    protected System.UInt16 count;

    private void Awake()
    {
        count = 0;
    }

    public bool Compare(ref Collectable other)
    {
        bool result = false;

        if(this.collectableType == other.collectableType)
        {
            result = true;
        }

        return result;
    }

    public void IncrementCount()
    {
        ++count;
    }

    public System.UInt16 GetCount()
    {
        return count;
    }
}

public struct Collectable_UI
{
    public Collectable collectable;
    public UnityEngine.UI.Image bgImage;
    public TMPro.TextMeshProUGUI textMesh;
}
