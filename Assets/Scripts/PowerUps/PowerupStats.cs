using UnityEngine;

[CreateAssetMenu(fileName = "NewPowerupStats", menuName = "Powerups/PowerupStats")]
public class PowerupStats : ScriptableObject
{
    [SerializeField] private float value;
    
    public float GetValue() => value;
    
}
