using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private bool invisible = false;
    [SerializeField] private GameObject optionButton;
    [SerializeField] private GameObject rankButton;
    [SerializeField] private GameObject exitButton;
    public void ToggleInvisible()
    {
        invisible = !invisible;
        optionButton.SetActive(invisible);
        rankButton.SetActive(invisible);
        exitButton.SetActive(invisible);
    }
}
