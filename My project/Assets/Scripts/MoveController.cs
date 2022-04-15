using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MoveController : MonoBehaviour
{

    public GameObject StartMenu;
    bool isGameStart;
    public Animator anim;
    public NavMeshAgent agent;
    public List<Transform> wayPoints = new List<Transform>();
    public GameObject bulletPrefab;
    public Transform shootPos;

    [HideInInspector]
    public bool battle;


    public static class States
    {
        public const string Run = "Run";
    }

    void Start()
    {
        PoolManager.instance.CreatePool(bulletPrefab, 5);
    }

    public void StartMove()
    {
        StartMenu.SetActive(false);
        isGameStart = true;
        anim.SetBool(States.Run, true);
    }

    void Update()
    {
        if (isGameStart)
        {
            if (Input.GetMouseButtonDown(0) && battle)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    var delta = shootPos.position - hit.point;
                    PoolManager.instance.ReuseObject(bulletPrefab, shootPos.position, Quaternion.LookRotation(-delta));
                }
            }

            if (!battle && wayPoints.Count > 0)
            {
                agent.SetDestination(wayPoints[0].position);
            }
        }
    }

    public void MoveNextPoint()
    {
        anim.SetBool(States.Run, true);
        battle = false;
        wayPoints.RemoveAt(0);
    }

    public void EndLevel()
    {
        isGameStart = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
