using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType
{
    Jump,
    Shoot,
}

public class Powerup : MonoBehaviour
{
    public PowerupType type;
    public float duration;
    public bool active = true;
}
