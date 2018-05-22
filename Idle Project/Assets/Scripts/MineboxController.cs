using UnityEngine;

public class MineboxController : MonoBehaviour {

    #region variables
    [SerializeField] private float totalResource = 0f;

    GameObject resourceCounterObject;
    TextMesh resourceCounterTextMesh;
    #endregion

    #region getters_and_setters
    public float TotalResource
    {
        get
        {
            return totalResource;
        }
        set
        {
            totalResource = value;
        }
    }
    #endregion

    private void Start()
    {
        resourceCounterObject = gameObject.transform.Find("Resource Counter").gameObject;

        resourceCounterTextMesh = resourceCounterObject.GetComponent<TextMesh>();
        UpdateResourceCounterTextMesh();
    }

    /// <summary>
    /// This method updates the objects label to display current resource value.
    /// </summary>
    public void UpdateResourceCounterTextMesh()
    {
        resourceCounterTextMesh.text = totalResource.ToString();
    }
}
