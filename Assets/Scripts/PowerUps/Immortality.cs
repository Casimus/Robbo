using UnityEngine;

[CreateAssetMenu(fileName = "Immortality", menuName = "Powerups/Immortality")]
public class Immortality : Powerup
{
    [SerializeField] private PowerupStats speedBoost;

    public float GetSpeedBoost() => speedBoost.GetValue();
}
