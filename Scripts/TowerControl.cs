using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    public GameObject WeaponA;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            UnityEngine.Ray raycaster = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raycaster, out hit))
            {
                if(hit.collider.name == "D1" || hit.collider.name == "D2" || hit.collider.name == "D3")
                if (CoinManager.coincount-1 >= 0)
                {
                    Instantiate(WeaponA, hit.point, Quaternion.identity);
                    Debug.Log("Spawnsomething");
                    CoinManager.coincount--;
                }
            }
        }
    }
}
