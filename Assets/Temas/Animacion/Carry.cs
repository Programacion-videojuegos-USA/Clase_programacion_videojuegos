using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carry : MonoBehaviour
{
     public Animator animator;

     public bool carry;

     public GameObject btnCarry, btnUnCarry;

      public Transform carryPoint;

     GameObject carryObject;
    // Start is called before the first frame update

    void Start()
    {
        btnCarry.SetActive(false);
        btnUnCarry.SetActive(false);
        carryObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(carry)
        {
            animator.SetLayerWeight(1,1);
        }
        else
        {
            animator.SetLayerWeight(1,0);
        }
    }

    public void CarryObject()
    {
        carryObject.transform.parent = carryPoint;
        carryObject.GetComponent<Rigidbody>().isKinematic = true;
        carryObject.transform.localPosition = Vector3.zero;
        carry = true;
        btnUnCarry.SetActive(true);
    }

     public void UnCarryObject()
    {
        carryObject.transform.parent = null;
        carryObject.GetComponent<Rigidbody>().isKinematic = false;
        btnUnCarry.SetActive(false);
        carry = false;
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("carry") && !carry)
        {
             btnCarry.SetActive(true);
             carryObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
         if(other.CompareTag("carry") && !carry)
        {
             btnCarry.SetActive(false);
             carryObject = null;
        }
    }
}
