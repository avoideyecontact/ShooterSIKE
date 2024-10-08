using TMPro;
using UnityEngine;

// Класс для обновления пользовательского интерфейса
public class UserInterfaceHandler : MonoBehaviour
{
    // Текст очков игрока
    public TMP_Text scoreText;
    // Текст здоровья игрока
    public TMP_Text healthText;
    // Объект игрока
    public GameObject Player;

    private Health healthComponent;
    private Score scoreComponent;

    private void Start()
    {
        healthComponent = Player.GetComponent<Health>();
        scoreComponent = Player.GetComponent<Score>();
        UpdateUI();
    }

    // Функция для обновления интерфейса
    public void UpdateUI()
    {
        healthText.SetText($"{healthComponent.health}+");
        scoreText.SetText($"{scoreComponent.score}₪");
    }
}
