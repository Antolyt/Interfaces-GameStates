using UnityEngine;
using UnityEngine.UI;

public class SelectButtonReference : MonoBehaviour
{
    [SerializeField] Text buttonText;

    public void OpenReassignButtenPanel(GameObject reassignButtonPanel)
    {
        reassignButtonPanel.SetActive(true);
        reassignButtonPanel.GetComponent<SelectButton>().buttonText = buttonText;
    }
}
