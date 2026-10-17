using UnityEngine;

// Gives the player a speed boost for a limited time
public class PlayerPowerUps : MonoBehaviour
{

    [SerializeField] private float boostMultiplier = 1.5f; // 50% faster

    // Seconds of boost left. The HUD reads it; only this script changes it
    public float SpeedTimeLeft {get; private set;}

    private PlayerMovement movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Called by the pickup. Collecting another boost restarts the timer
    public void ActivateSpeedBoost(float duration) 
    {
        SpeedTimeLeft = duration;
        movement.SpeedMultiplier = boostMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedTimeLeft <= 0f) return; // No boost running

        SpeedTimeLeft -= Time.deltaTime;

        if (SpeedTimeLeft <= 0f) 
        {
            movement.SpeedMultiplier = 1f; // Back to normal speed
        }
    }
}
