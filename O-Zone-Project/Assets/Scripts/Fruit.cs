using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private CircleCollider2D FruitHitbox;
    [SerializeField] int AttackDamage = 1;
    private GameObject AttackingPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        FruitHitbox = GetComponent<CircleCollider2D>();
        FruitHitbox.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAttackingPlayer(GameObject Player)
    {
        AttackingPlayer = Player;
    }

    public GameObject GetAttackingPlayer()
    {
        return AttackingPlayer;
    }

    public void DestroyFruit()
    {
        FruitHitbox.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<ParticleSystem>().Play();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStats>().Damage(AttackDamage, GetAttackingPlayer());
        }
        else
        {
            DestroyFruit();
        }
    }
}
