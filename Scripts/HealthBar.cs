using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hpdeplete()
    {
            this.transform.localScale = new Vector3(transform.localScale.x - .33f, transform.localScale.y, transform.localScale.z);
            if (transform.localScale.x <= .1f)
            {
                Destroy(gameObject);
                Destroy(holder);
            }
        }
    
}
