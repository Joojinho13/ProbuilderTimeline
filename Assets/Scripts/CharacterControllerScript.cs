using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
   
    public float speed = 6f;


    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
     Vector3 velocity;
    public bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public int Vidas;
    public int Mana;
    public int Dano = 2;

    public float TempoDeRecargaLimite;
    public float TempoDeRecargaAtual;
    public bool PodeAtacar = true;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PodeAtacar)
        {
            if (Time.time > TempoDeRecargaAtual + TempoDeRecargaLimite)
            {
                PodeAtacar = true;
                Debug.Log("Arma liberada");
            }
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * 10 * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);



            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Achei um inimigo");
            if(Input.GetKeyDown("e") && PodeAtacar)
            {
                PodeAtacar = false;
                Debug.Log("Ataquei um inimigo");
                other.GetComponent<EnemyManager>().Vidas -= Dano;
                TempoDeRecargaAtual = Time.time;
            }
        }
    }
}