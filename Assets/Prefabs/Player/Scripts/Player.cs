using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    public float maxHealth = 100f;
    float currentHealth;

    [Header("Referencias de Vida")]
    public Slider healthBar;
    public Image healthFillImage;

    public float maxOxygen = 100f;
    public float oxygenDrainRate = 1f;
    float currentOxygen;
    float oxygenMultiplier = 1f;

    [Header("Referencias de Oxígeno")]
    public Slider oxygenBar;
    public Image oxygenFillImage;
    #endregion

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        currentOxygen = maxOxygen;
        oxygenBar.maxValue = maxOxygen;
        oxygenBar.value = currentOxygen;

        UpdateVisuals();
    }

    #region Vida Jugador
    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthBar.value = currentHealth;
        UpdateVisuals();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        UpdateVisuals();

        if (currentHealth <= 0) Die();
    }

    void Die() => Debug.Log("Jugador muerto");
    #endregion

    #region Oxigeno Jugador
    void Update()
    {
        DrainOxygen();
        UpdateVisuals(); // Mantiene el fill sincronizado cada frame
    }

    void DrainOxygen()
    {
        currentOxygen -= oxygenDrainRate * oxygenMultiplier * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
        oxygenBar.value = currentOxygen;

        if (currentOxygen <= 0) Debug.Log("Sin oxígeno");
    }

    public void AddOxygen(float amount)
    {
        currentOxygen = Mathf.Min(currentOxygen + amount, maxOxygen);
        oxygenBar.value = currentOxygen;
        UpdateVisuals();
    }

    public void SetOxygenDrainMultiplier(float multiplier)
    {
        oxygenMultiplier = Mathf.Max(multiplier, 1f);
    }
    #endregion

    void UpdateVisuals()
    {
        if (healthFillImage != null)
            healthFillImage.fillAmount = currentHealth / maxHealth;

        if (oxygenFillImage != null)
            oxygenFillImage.fillAmount = currentOxygen / maxOxygen;
    }
}