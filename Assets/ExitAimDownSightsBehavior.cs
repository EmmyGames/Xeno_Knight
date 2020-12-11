using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAimDownSightsBehavior : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("shouldMove", true);
    }
}
