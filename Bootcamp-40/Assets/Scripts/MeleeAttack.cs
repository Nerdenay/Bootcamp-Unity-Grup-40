using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour

{
    public Animator animator; // Animator bileþeni
    public string boolParameterName = "Attack"; // Boolean parametre ismi

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol fare týklamasý
        {
            animator.SetBool(boolParameterName, true);
        }
        else if (Input.GetMouseButtonUp(0)) // Sol fare týklamasý býrakýldýðýnda
        {
            animator.SetBool(boolParameterName, false);
        }
    }
}
