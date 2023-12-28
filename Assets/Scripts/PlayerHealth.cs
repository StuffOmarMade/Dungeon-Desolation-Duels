using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //for now
    [SerializeField]
    int damage = 5;

    private void Update()
    {
        SetHealth();
    }

    private void SetHealth() 
    {
        if(GetComponent<PlayerCollision>().IsHurt)
        {
            GetComponent<Player>().CurrentHealthPoints -= damage;
            GetComponent<PlayerCollision>().IsHurt = false;
        }
    }
}
