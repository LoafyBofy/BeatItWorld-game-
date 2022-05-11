using UnityEngine;

public class Fireball : ProjectileBase
{
    [SerializeField] private byte fireballDamage;
    private static byte _fireballDamage;

    private void Awake()
    {
        _fireballDamage = fireballDamage;
    }

    public static byte FireballDamage { get { return _fireballDamage; } }
}
