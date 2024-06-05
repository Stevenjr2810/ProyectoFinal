using UnityEngine;
using UnityEngine.UI; // Asegúrate de usar el espacio de nombres de UI

public class GameController : MonoBehaviour
{
    public Button swordButton;
    public Button bowButton;
    public Button magicButton;

    public Animator characterAnimator;
    public Health enemyHealth; // Referencia al componente Health del enemigo
    public PlayerMana playerMana; // Referencia al componente PlayerMana del jugador
    public PlayerHealth playerHealth; // Referencia al componente PlayerHealth del jugador

    void Start()
    {
        // Añadir listeners a los botones para llamar a las funciones respectivas
        swordButton.onClick.AddListener(() => AttackEnemy("SwordAttack", 10));
        bowButton.onClick.AddListener(() => AttackEnemy("BowAttack", 8));
        magicButton.onClick.AddListener(() => MagicAttack());
    }

    void AttackEnemy(string animationName, int damage)
    {
        // Reproduce la animación correspondiente
        characterAnimator.SetTrigger(animationName);

        // Reduce la salud del enemigo
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    void MagicAttack()
    {
        int magicDamage = 15;
        int manaCost = 20;

        // Verifica si el jugador tiene suficiente maná
        if (playerMana.GetMana() >= manaCost)
        {
            // Reproduce la animación de ataque mágico
            characterAnimator.SetTrigger("MagicAttack");

            // Reduce la salud del enemigo
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(magicDamage);
            }

            // Reduce el maná del jugador
            playerMana.UseMana(manaCost);
        }
        else
        {
            Debug.Log("Not enough mana!");
        }
    }
}
