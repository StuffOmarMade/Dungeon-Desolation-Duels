public interface IGameObject
{
    public int Level { get; set; }
    public int CurrentHealthPoints { get; set; }
    public int MaximumHealthPoints { get; set; }
    public int Damage { get; set; }
    public float MovementSpeed { get; set; }

    public void void_Shoot();
}
