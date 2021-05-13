using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerStats PS =
                collision.gameObject.GetComponent<PlayerStats>();
            Rigidbody2D RB =
                collision.gameObject.GetComponent<Rigidbody2D>();
            if (PS.GetInAir && RB.velocity.magnitude > Mathf.Epsilon)
            {
                PS.Damage(1000);
            }
        }
    }

    private ArrayList bumpedPlayers;
    private GameObject playerToRemove;

    // Start is called before the first frame update
    void Awake()
    {
        bumpedPlayers = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !bumpedPlayers.Contains(collision.gameObject))
        {
            AudioManager.PlaySound("BumpLand");
            bumpedPlayers.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerToRemove = collision.gameObject;
        Invoke("RemoveFromList", 1f);
    }

    private void RemoveFromList()
    {
        bumpedPlayers.Remove(playerToRemove);
    }
}
