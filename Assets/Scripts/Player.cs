using UnityEngine;

public class Player : MonoBehaviour, IGameObject
{
    private int _level;
    private int _currentHealthPoints;
    private int _maximumHealthPoints;
    private int _damage;

    // for now
    [SerializeField]
    private float _movementSpeed;

    //private int _maximumAmmo;
    //private int _ammoLeft;
    //private bool _isOutOfAmmo;

    public int Level { get { return _level; } set { if (value >= 1) _level = value; } }
    public int CurrentHealthPoints { get { return _currentHealthPoints; } set { if (value >= 0) _currentHealthPoints = value; } }
    public int MaximumHealthPoints { get { return _maximumHealthPoints; } set { if (value >= 0) _maximumHealthPoints = value; } }
    public int Damage { get { return _damage; } set { if (value >= 0) _damage = value; } }
    
    public float MovementSpeed { get { return _movementSpeed; } set { if (value >= 0) _movementSpeed = value; } }
    //public int AmmoLeft { get { return _ammoLeft; } set { if (value >= 0) _ammoLeft = value; } }
    //public int MaximumAmmo { get { return _maximumAmmo; } set { if (value >= 0) _maximumAmmo = value; } }

    public Player(int maximumHealthPoints, int damage, float movementSpeed)
    {
        MaximumHealthPoints = maximumHealthPoints;
        Damage = damage;
        MovementSpeed = movementSpeed;
    }
}
