using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class playerController : MonoBehaviour
{
    //Variables//__________________________________________________________________________________________________________________________________________________________________________
    [Header("Player Speed")]
    [SerializeField] public float playerSpeed; //the speed of players run
    [SerializeField] public float dashSpeed; //the speed of players dash
    float speed;
    float moveX, moveZ;


    [Header("Engine")]
    Animator playerAnim; //players animatorscript
    CharacterController charController; //player CharacterController
    public GameObject playerModel; //children object with player character for rotation
    public BoxCollider weaponCollider; //Box collider on weapon for collizion damage to enemies
    public GameObject rightHand;

    [Header("States")]
    public bool enableInput; //enables player inputs bool enableInput; //enables player inputs
    public bool defenceState = false; //State of players attack ot defence
    public bool isDasing = false;


    
    private void Start()//__________________________________________________________________________________________________________________________________________________________________________
    {
        //initialize input
        enableInput = true;
        speed = playerSpeed;

        //initialize components
        charController = GetComponent<CharacterController>();
        if (weaponCollider != null)
        {
            weaponCollider.enabled = false;// reset weapon collider
        }


        //initialize player model
        playerAnim = playerModel.GetComponent<Animator>();
    }


    void Update()//__________________________________________________________________________________________________________________________________________________________________________
    {
        if (enableInput == true)
        {
            inputWASD(); //WASD Movement
            animationPlayer(); // [ANIMATIONS] movement, rotation, attack, defence
        }
    }



    //Functions//__________________________________________________________________________________________________________________________________________________________________________
    
    public void characterDeath (bool switchBool)
    {
        enableInput = switchBool;
        playerModel.SetActive(false);
    }

    void inputWASD ()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveZ;

        if (transform.position.y > 1)
        {
            movement.y = -9;
        }
        else
        {
            movement.y = 0;
        }

        movement = movement.normalized * Time.deltaTime;

        charController.Move(movement * speed);
    }

    void animationPlayer ()
    {
        if (GetComponent<PlayerEquipment>().weapon != null)
        {
            attackAnimation();
            defenceAnimation();
        }
        movementAnimations();
    }

    void playerRotator()
    {
        float angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
        playerModel.transform.rotation = Quaternion.Euler(new Vector3(0, angle + 45, 0));
    }

    void PlayerDash()
    {
        if (Input.GetKey(KeyCode.Space) && GetComponent<HealthStats_player>().energy > 0)
        {
            isDasing = true;
            speed = dashSpeed;
            GetComponent<HealthStats_player>().dropStat(2, 0); //player stats dash cost
        }
        else
        {
            isDasing = false;
            speed = playerSpeed;
        }
    }

    void movementAnimations()
    {
        if (moveX != 0 || moveZ != 0)
        {
            playerRotator();
            PlayerDash();
            playerAnim.SetInteger("move", 1);
        }

        else
        {
            playerAnim.SetInteger("move", 0);
        }
    }
    
    void attackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weaponCollider.enabled = true;
            defenceState = false;

            playerAnim.SetInteger("attack", 1);
        }

        else if (Input.GetAxis("Attack") == 0)
        {
            playerAnim.SetInteger("attack", 0);
            weaponCollider.enabled = false;
        }

        else
        {
            playerAnim.SetInteger("attack", 0);
        }
    }

    void defenceAnimation()
    {
        if (Input.GetAxis("Block") == 1)
        {
            weaponCollider.enabled = true;
            defenceState = true;

            playerAnim.SetInteger("defence", 1);
        }
        else
        {
            playerAnim.SetInteger("defence", 0);
            defenceState = false;
        }
    }
}
