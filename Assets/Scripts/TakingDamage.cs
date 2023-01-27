using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviour
{
    [SerializeField]
    Image healtBar;
    private float health;
    public float startHealth=100;
    // Start is called before the first frame update
    void Start()
    {
        health= startHealth;
        healtBar.fillAmount=health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    public void TakeDamage(float _damage)
    {
        health-=_damage;
        Debug.Log(health);
    }
}
