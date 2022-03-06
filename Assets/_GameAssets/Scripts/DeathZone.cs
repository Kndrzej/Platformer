using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
   
    public delegate void DeathAction();
    public static event DeathAction OnDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnDeath();
    }

    
}
