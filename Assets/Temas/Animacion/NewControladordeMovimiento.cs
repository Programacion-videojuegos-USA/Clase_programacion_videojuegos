using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewControladordeMovimiento : MonoBehaviour
{
    public CharacterController controlador;
    public int speed;
    public float gravity;
    // Start is called before the first frame update

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3( h, 0 , v);
        Vector3 rotacion = new Vector3(h, 0, v);   

        if (h!=0  || v!=0)
        {
            transform.rotation = Quaternion.LookRotation(rotacion);           
        }

        animator.SetFloat("inputs", Mathf.Abs(h) + Mathf.Abs(v) );        

                  
        direction.y = gravity ;
        
        
        controlador.Move(direction * Time.deltaTime * speed);
    }
    
}
