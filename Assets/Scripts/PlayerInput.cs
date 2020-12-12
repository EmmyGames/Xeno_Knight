using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public class PlayerInput : MonoBehaviour
{
    public PlayerScript playerScript;
    
    public bool isSprinting = false;

    public float moveX;

    public float moveZ;

    public bool isJumping;

    public bool isAttacking;

    public bool isADS;

    public bool toggleMouse;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        if (playerScript.playerMovement.isGrounded)
            isSprinting = false || Input.GetButton("Sprint");
        
        isJumping = false || Input.GetButton("Jump");
        if (Input.GetButtonDown("Attack") && playerScript.weaponStatus.weaponTypeInt != 2)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        //When holding left click and holding a ranged weapon, the player is aiming down sights
        if (Input.GetButtonDown("Attack") && playerScript.weaponStatus.weaponTypeInt == 2)
        {
            isADS = true;
            //playerScript.bow.GetComponentInChildren<ArrowScript>().CreateArrow();
            playerScript.bow.GetComponentInChildren<ArrowScript>().ShowArrow();
        }
        else if(Input.GetButtonUp("Attack") && playerScript.weaponStatus.weaponTypeInt == 2)
        {
            isADS = false;
            playerScript.bow.GetComponentInChildren<ArrowScript>().FireArrow();
            playerScript.bow.GetComponentInChildren<ArrowScript>().DontShowArrow();
        }

        toggleMouse = false || Input.GetButtonDown("CharacterMenu");
    }
}
