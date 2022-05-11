using UnityEngine;

public class StunWave : ProjectileBase
{
    [SerializeField] private byte stunDuration;
    private static byte _stunDuration;

    private void Awake()
    {
        _stunDuration = stunDuration;
    }

    public static byte StunDuration { get { return _stunDuration; } }
}
