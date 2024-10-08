using UnityEngine;
using UnityEngine.Events;

// Класс реализующий здоровье у объекта
public class Health : MonoBehaviour
{
    // Величина здоровья
    public int health;

    [SerializeField] private UnityEvent onDamage;
    [SerializeField] private UnityEvent onHeal;
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private UnityEvent onChange;

    // Функция для изменения здоровья
    public void ModifyHealth(int deltaHealth)
    {
        health += deltaHealth;
        onChange?.Invoke();

        if (deltaHealth < 0)
        {
            onDamage?.Invoke();
        }

        if (deltaHealth > 0)
        {
            onHeal.Invoke();
        }

        if (health <= 0)
        {
            onDie?.Invoke();
        }
    }
}
