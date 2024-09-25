using TMPro;
using UnityEngine;

public class UserInterfaceHandler : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public GameObject Player;

    private Health healthComponent;

    private void Start()
    {
        healthComponent = Player.GetComponent<Health>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.SetText($"{healthComponent.health}");
    }
}
