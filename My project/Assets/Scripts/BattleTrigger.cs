using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public bool isLast;
    public List<GameObject> enemyes = new List<GameObject>();

    MoveController moveController;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moveController = other.GetComponent<MoveController>();

            moveController.anim.SetBool("Run", false);

            if (isLast)
            {
                moveController.EndLevel();
            }
            else
            {
                moveController.battle = true;
            }

            CheckAllKill();

            Destroy(GetComponent<BoxCollider>());
        }
    }

    public void CheckAllKill()
    {
        if (enemyes.Count <= 0)
        {
            moveController.MoveNextPoint();
        }
    }
}
