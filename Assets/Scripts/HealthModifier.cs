using UnityEngine;

// Класс позволяет объектам менять здоровье у других
public class HealthModifier : MonoBehaviour
{
    [SerializeField] private int deltaHealth;

    // Функция для изменения здоровья у игрового объекта
    public void Apply(GameObject targer)
    {
        var healthComponent = targer.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.ModifyHealth(deltaHealth);
        }
    }
}
