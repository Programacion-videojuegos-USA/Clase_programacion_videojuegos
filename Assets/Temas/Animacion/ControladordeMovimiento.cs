using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladordeMovimiento : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controlador;

    public Animator animator;

    public int speed;

    public float gravity;

    public float jump;

    private bool InJump;

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var j = Input.GetAxis("Jump");
        float yvelocity = 0;

        Vector3 direction = new Vector3( h, 0 , v);
        Vector3 rotacion = new Vector3(h, 0, v);    


        animator.SetFloat("movement", Mathf.Abs(h) +Mathf.Abs(v));    

        if (h!=0  || v!=0)
        {
            transform.rotation = Quaternion.LookRotation(rotacion);
        }

        //if()
        yvelocity = gravity;
        print(j);
        
        if (j> 0.1 && transform.position.y < 1)        
        {
           
            direction.y = jump;
            
        }
        else
        {            
            direction.y = gravity ;
        }
        
        controlador.Move(direction * Time.deltaTime * speed);

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "enemy")
        {
            //Destroy(hit.gameObject);
            hit.gameObject.SetActive(false);
            transform.localScale *= 1.5f;
            
        }
    }


}
