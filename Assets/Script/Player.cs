using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private AudioSource src;
    public AudioClip clip;

    public Transform enemyPosition;
    public GameObject bloodEffect;

    public int damage = 1;
    bool isAttacking = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
  
        

    public void hit(int jenis)
    {
        isAttacking = !isAttacking;
        anim.SetBool("attack", isAttacking);
        src.PlayOneShot(clip);
        Instantiate(bloodEffect, enemyPosition.position, Quaternion.identity);
        if (jenis == 1)
        {
            GameManager.gm.scoreMahasiswa += damage;
            GameManager.gm.healthPolice -= damage;
            if(GameManager.gm.healthPolice <= 0)
            {
                GameManager.gm.SetWinScreen(1);
            }
            
        }
        else
        {
            GameManager.gm.scorePolice += damage;
            GameManager.gm.healthMahasiswa -= damage;
            if (GameManager.gm.healthMahasiswa <= 0)
            {
                GameManager.gm.SetWinScreen(2);
            }
        }
    }
}
