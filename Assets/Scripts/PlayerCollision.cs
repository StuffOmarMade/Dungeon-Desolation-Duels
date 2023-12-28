using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool _isHurt;

    public bool IsHurt { get { return _isHurt; } set { _isHurt = value; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            _isHurt = true;
        }
    }
}
