using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ApiRestServices : MonoBehaviour
{
    static string pokemonApiUrl = "https://pokeapi.co/api/v2/pokemon/";

    public static IEnumerator GetImage(string url, Action<Texture> callBack)
    {
        // se invoca Unity Web request y se usa get texture para recibir no recibir los datos serializados 
        var request = UnityWebRequestTexture.GetTexture(url);
        // Se envia la petición 
        var peticion = request.SendWebRequest();   

        //Mientras la petición no este completa se repite el código dentro del While
        while(!peticion.isDone)   
        {
            print(request.downloadProgress);            
            yield return null;
        }  

            if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                print("Error = "+ request.result);
            }
            else
            {
                Texture myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;   
                callBack(myTexture);
            } 
    }

    public static IEnumerator GetJsonData(string nameOrnumber, Action<string> callBack)
    {
        var finalUrl = pokemonApiUrl+nameOrnumber;
        finalUrl = finalUrl.ToLower();

        var request = UnityWebRequest.Get(finalUrl);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                print("Error = "+ request.result);
            }
            else
            {                  
                callBack(request.downloadHandler.text);
            } 
        
    }

    
}
