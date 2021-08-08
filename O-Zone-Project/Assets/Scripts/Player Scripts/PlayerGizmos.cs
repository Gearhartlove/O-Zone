using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGizmos : MonoBehaviour
{
    private PlayerStats PStats;
    // Start is called before the first frame update
    void Awake()
    {
        PStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // Defensive
        if (PStats.IsDefensive)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }
        
        if (PStats.IsStunned)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }

        if (PStats.isTaunting)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }
    }
}
