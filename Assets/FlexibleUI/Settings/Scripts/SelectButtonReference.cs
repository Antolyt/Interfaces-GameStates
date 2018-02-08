using UnityEngine;
using UnityEngine.UI;

public class SelectButtonReference : MonoBehaviour
{
    public KeyCode key;

    public void OpenReassignKeyPanel(GameObject reassignButtonPanel)
    {
        reassignButtonPanel.SetActive(true);
        ReassignKeyPanel reassignKeyPanel = reassignButtonPanel.GetComponent<ReassignKeyPanel>();
        reassignKeyPanel.reassignButton = this.gameObject;
        //reassignKeyPanel.buttonText = this.gameObject.GetComponentInChildren<Text>();
    }
}
