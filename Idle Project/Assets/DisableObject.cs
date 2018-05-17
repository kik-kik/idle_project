using UnityEngine;
using UnityEngine.UI;

public class DisableObject : MonoBehaviour {

    private Button disableButton;

	// Use this for initialization
	void Start () {
        disableButton = GetComponent<Button>();
        disableButton.onClick.AddListener(DisableObjectMethod);
	}



    void DisableObjectMethod()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
