using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rb;
    public Renderer renderer;
    public Slider slider;
    public BattleTrigger battleTrigger;
    public int health;

    Vector3 bulletStartPos;

    public void TakeDamage(int damage, Vector3 startPos)
    {
        health -= damage;
        bulletStartPos = startPos;
        slider.value = health;

        if (health <= 0)
            Dead();
    }

    void Dead()
    {
        foreach (Rigidbody rigid in rb)
        {
            rigid.isKinematic = false;
        }
        anim.enabled = false;
        renderer.material.color = new Color32(100, 100, 100, 255);

        rb[0].AddForce(bulletStartPos * 150);
        rb[5].AddForce(bulletStartPos * 150);

        battleTrigger.enemyes.Remove(gameObject);
        battleTrigger.CheckAllKill();
    }

}
