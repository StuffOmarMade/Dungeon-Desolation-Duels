using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //for now
    [SerializeField]
    int damage = 5;

    public bool IsDead = false;

    private void Update()
    {
        SetHealth();
    }

    private void SetHealth() 
    {
        if(GetComponent<PlayerCollision>().IsHurt && GetComponent<Player>().CurrentHealthPoints > 0)
        {
            GetComponent<Player>().CurrentHealthPoints -= damage;
            GetComponent<PlayerCollision>().IsHurt = false;
            IsDead = false;
        } else if(GetComponent<Player>().CurrentHealthPoints <= 0) 
        {
            Debug.Log("Respawned!!");
            IsDead = true;
        }
    }
}
