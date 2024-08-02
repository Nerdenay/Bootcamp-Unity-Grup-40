using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatormanager : MonoBehaviour
{

    Animator animator;

    int horizontal;
    int vertical;



    private void Awake()
    {
        animator = GetComponent<Animator>();

        horizontal = Animator.StringToHash("horizontal");
        vertical = Animator.StringToHash("vertical");

    }


    public void UpdateAnimatorValues( float horizontalM, float verticalM)
    {

        // To avoid from animation bug 

        float SnappedHorizontal;
        float SnappedVertical;

        #region SnappedHorizontal

        if (horizontalM > 0 && horizontalM < 0.55f)
        {

            SnappedHorizontal = 0.5f;

        }
        else if (horizontalM > 0.55f)
        {

            SnappedHorizontal = 1f;

        }
        else if (horizontalM < 0 && horizontalM > -0.55f)
        {

            SnappedHorizontal = -0.5f;

        }
        else if (horizontalM < -0.55f)
        {

            SnappedHorizontal = -1f;

        }
        else
        {

            SnappedHorizontal = 0;

        }
        #endregion
        #region SnappedVertical

        if (verticalM > 0 && verticalM < 0.55f)
        {

            SnappedVertical = 0.5f;

        }
        else if (verticalM > 0.55f)
        {

            SnappedVertical = 1f;

        }
        else if (verticalM < 0 && verticalM > -0.55f)
        {

            SnappedVertical = -0.5f;

        }
        else if (verticalM < -0.55f)
        {

            SnappedVertical = -1f;

        }
        else
        {

            SnappedVertical = 0;

        }
        #endregion

        animator.SetFloat(horizontal, SnappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, SnappedVertical, 0.1f , Time.deltaTime);


    }
}
