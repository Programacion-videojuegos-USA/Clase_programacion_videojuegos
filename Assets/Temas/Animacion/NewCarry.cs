using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCarry : MonoBehaviour
{
    public Animator animator;
    public bool carry = false;

    public GameObject btnCarry, btnUnCarry;

    public Transform carryPoint;

    GameObject objetoAcargar;

    // Start is called before the first frame update
    void Start()
    {
        objetoAcargar = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cargar()
    {
       carry = true;
       animator.SetLayerWeight(1,1f);
       btnCarry.SetActive(false);
       btnUnCarry.SetActive(true);
       objetoAcargar.transform.SetParent(carryPoint.transform);
       objetoAcargar.GetComponent<Rigidbody>().isKinematic = true;
       objetoAcargar.transform.localPosition = Vector3.zero;
    }

    public void Soltar()
    {
        carry = false;
        animator.SetLayerWeight(1,0f);
        btnUnCarry.SetActive(false);
        objetoAcargar.transform.SetParent(null);
        objetoAcargar.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("carry") && !carry)
        {
            objetoAcargar = other.gameObject;
            btnCarry.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if(other.CompareTag("carry") && !carry)
        {
            objetoAcargar = null;
            btnCarry.SetActive(false);
        }
    }
}
