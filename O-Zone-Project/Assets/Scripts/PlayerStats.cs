using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Movement + Physics values
    [SerializeField] float RotationSpeed = 8f;
    [SerializeField] float MovementSpeed = 8f;
    [SerializeField] float MaximumSpeed = 10f; //de-serialize later TODO
    [SerializeField] float LinearDrag = 2f;
    //SceneLogic
    int round_win_count;
    [SerializeField] bool InWater = false;
    

    public void RoundWin() { round_win_count++; }

    //rotation
    public float GetRotationSpeed => RotationSpeed;
    public float GetMaxSpeed => MaximumSpeed;
    public float GetAngle(Vector2 me, Vector2 target)
    {
        //math for rotating spoon
        return Mathf.Atan2(target.y - me.y, target.x - me.x)
            * (180 / Mathf.PI);
    }

    //movement
    public float GetMovementSpeed => MovementSpeed;
    public float GetLinearDrag => LinearDrag;
    public void SetLinearDrag(float val) { LinearDrag = val; }

    //terrain
    public bool GetInWater => InWater;

    public void SetInWater(bool change)
    {
        InWater = change;
    }
}
