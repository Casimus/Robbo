
using UnityEngine;
[CreateAssetMenu(fileName = "Magnet", menuName = "Powerups/Magnet")]
public class Magnet : Powerup
{
    [SerializeField] private PowerupStats magnetRange;
    public float GetMagnetRange() => magnetRange.GetValue();

    [SerializeField] private PowerupStats magnetSpeed;
    public float GetMagnetSpeed() => magnetSpeed.GetValue();

}
