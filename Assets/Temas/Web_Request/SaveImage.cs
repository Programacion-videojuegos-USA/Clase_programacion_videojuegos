using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveImage : MonoBehaviour
{

    Texture texturaGuardada;
    string pikachuiImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartSave()
    {
        StartCoroutine(ApiRestServices.GetImage(pikachuiImageUrl, Save));
       
    }

    void Save(Texture texture)
    {
        texturaGuardada = texture;
    }


}
