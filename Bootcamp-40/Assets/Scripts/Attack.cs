using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator; // Animator bileþeni
    public string boolParameterName = "Attack"; // Boolean parametre ismi

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Sol fare týklamasý
        {
            animator.SetBool(boolParameterName, true);
            RaycastHit Rayshit;
            if (Physics.Raycast(transform.position, transform.forward, out Rayshit, 5f))
            {
                if (Rayshit.transform.tag == "Enemies")
                {
                    Rayshit.transform.gameObject.SetActive(false);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.R)) // Sol fare týklamasý býrakýldýðýnda
        {
            animator.SetBool(boolParameterName, false);
        }
    }
}
