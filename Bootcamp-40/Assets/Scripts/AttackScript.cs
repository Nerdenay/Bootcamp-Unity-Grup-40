using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Rayshit;
            if(Physics.Raycast(transform.position,transform.forward,out Rayshit, 5f))
            {
                if (Rayshit.transform.tag == "Enemies")
                {
                    Rayshit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}
