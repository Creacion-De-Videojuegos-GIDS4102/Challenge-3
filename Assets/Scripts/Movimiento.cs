using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movimiento")]

    [SerializeField] private string movimientoHorizontal;

    [SerializeField] private string movimientoVertical;

    [SerializeField] private float VelocidadMovimiento;

    private Animator animator;

    private Rigidbody2D rb;

    private float valorMovimientoVertical;

    private float valorMovimientoHorizontal;

    private SpriteRenderer spriteRender;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        valorMovimientoHorizontal = Input.GetAxis(movimientoHorizontal);
        valorMovimientoVertical = Input.GetAxis(movimientoVertical);

        animator.SetFloat("movimiento", valorMovimientoHorizontal);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(valorMovimientoHorizontal * VelocidadMovimiento * Time.deltaTime, valorMovimientoVertical * VelocidadMovimiento * Time.deltaTime);

        Girar();
    }

    private void Girar()
    {
        if (valorMovimientoHorizontal >= 0.1f)
        {
            spriteRender.flipX = false;
        }
        else if (valorMovimientoHorizontal <= -0.1f){
           
            spriteRender.flipX = true;
        }

    }
}
