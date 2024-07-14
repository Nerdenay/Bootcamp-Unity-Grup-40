using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour

{
    public Animator animator; // Animator bile�eni
    public string boolParameterName = "Attack"; // Boolean parametre ismi

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol fare t�klamas�
        {
            animator.SetBool(boolParameterName, true);
        }
        else if (Input.GetMouseButtonUp(0)) // Sol fare t�klamas� b�rak�ld���nda
        {
            animator.SetBool(boolParameterName, false);
        }
    }
}
