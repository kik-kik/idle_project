using UnityEngine;
using UnityEngine.UI;

public class DisableObject : MonoBehaviour {

    Button disableButton;


	void Start () {
        disableButton = GetComponent<Button>();
        disableButton.onClick.AddListener(DisableObjectMethod);
	}

    /// <summary>
    /// This method disables the parent gameobject
    /// </summary>
    void DisableObjectMethod()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
