using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerMovement playerMovement;
    public PlayerStats playerStats;
    public PlayerCollision playerCollision;
    public PlayerAnimation playerAnimation;

    public WeaponStatus weaponStatus;
    public Transform weaponTransform;

    public GameObject sword;
    public GameObject bow;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
