using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PokemonGetData : MonoBehaviour
{
    string jsonExample = "{\"lunes\":1, \"martes\":2,\"miercoles\":3,\"jueves\":4587,\"viernes\":5,\"sabado\":6,\"domingo\":7}";

    public Text pokemonNameText, pokemonNumberText, pokemonTypeText;
    public InputField pokemonInput;

    public RawImage pokemonImage;
    public Button button;

    public void LoadImageBtn()
    {
        StartCoroutine(ApiRestServices.GetImage(pokemonInput.text, LoadImageCallBack));
    }

    public void LoadPokemonData()
    {
        StartCoroutine(ApiRestServices.GetJsonData(pokemonInput.text, LoadJsonCallBack));
        //print (jsonExample);
        //var diasSerializados = JsonUtility.FromJson<Days>(jsonExample);
        //print("el dato guardado en lunes es: " + diasSerializados.jueves);
    }

    public void LoadImageCallBack(Texture textura)
    {
       pokemonImage.texture = textura;
    }

    public void LoadJsonCallBack(string jsonData)
    {
       var pokemonInfoSerializado = JsonUtility.FromJson<pokemonInfo>(jsonData);
        pokemonNameText.text = pokemonInfoSerializado.name;

    }
    
}


