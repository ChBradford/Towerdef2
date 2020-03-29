using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Waypoint currentDestination;
  public WaypointManager waypointManager;
  private int currentIndexWaypoint = 1;
  public HealthBar hpscript;
  public float speed = 2;
  public float health = 3;

  public void Initialize(WaypointManager waypointManager)
  {
    this.waypointManager = waypointManager;
    GetNextWaypoint();
    transform.position = currentDestination.transform.position; // Move to WP0
    GetNextWaypoint();
  }

  void Update()
  {
    Vector3 direction = currentDestination.transform.position - transform.position;
    if (direction.magnitude < .2f)
    {
      GetNextWaypoint();
    }

    transform.Translate(direction.normalized * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            UnityEngine.Ray raycaster = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raycaster, out hit))
            {
                if (hit.collider.name == "Cube")
                {
                    hpscript.GetComponent<HealthBar>().hpdeplete();
                    health--;
                    if (health <= 0)
                    {
                        Destroy(hit.collider.gameObject);
                        CoinManager.coincount++;
                    }
                }
            }
        }
    }


  private void GetNextWaypoint()
  {
    currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
    currentIndexWaypoint++;
  }
}
