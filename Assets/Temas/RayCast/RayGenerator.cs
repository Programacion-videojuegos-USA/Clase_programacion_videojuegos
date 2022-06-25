using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGenerator : MonoBehaviour
{

    public Transform Playertransform;

    void Update()
    {
        var distance = Playertransform.position - transform.position; // Distancia entre los dos puntos
        var direction = distance / distance.magnitude; // dirección normalizada a 1.

        if(Input.GetKeyDown(KeyCode.Space))
        {
             Shoot();//funcion para disparar el rayo
             Debug.DrawRay(transform.position, transform.forward, Color.red,5f);// rayo para pruebas, solo se ve en el editor
        }

       
    }

    public void Shoot()
    {
        RaycastHit impacto; // variable para guardar la información del primer objeto contra el que impacte el rayo
        
        Ray rayo = new Ray(transform.position, transform.forward);// variable para almacenar punto inicial y dirección del rayo

        //Physics.Raycast Genera el rayo y devuelve verdadero si hay un impacto
        if(Physics.Raycast(rayo, out impacto, 5f))// como 4 parametro pueden pasar el indice de la capa con la que no va a interactuar
        {
            if(impacto.collider.gameObject.tag == "Player")
            {
                // Preguntamos en caso que necesitemos solo interactuar con objetos con la eqyiqueta player
            }
            
            print(impacto.collider.gameObject.tag);
            impacto.collider.gameObject.SetActive(false); // apagamos el objeto contra el que impactemos.
        }
    }
}
