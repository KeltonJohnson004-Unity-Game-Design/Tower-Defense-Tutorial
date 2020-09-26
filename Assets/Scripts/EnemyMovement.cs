using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavePointIndex = 0;

    private Enemy enemy;

    private void Start()
    {
        target = Waypoints.waypoints[0];
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.baseSpeed;
    }



    private void GetNextWayPoint()
    {
        if (wavePointIndex >= Waypoints.waypoints.Length - 1)
        {
            PathEnded();
            return;
        }
        
        wavePointIndex++;
        target = Waypoints.waypoints[wavePointIndex];
        

    }

    void PathEnded()
    {

        PlayerStats.Lives--;
        Destroy(gameObject);
    }


}
