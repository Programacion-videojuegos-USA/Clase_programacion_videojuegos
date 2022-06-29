
//Clase Programación de videojuegos
//Tema: Consumo de API Web Request - Descargar una imagen y usarla como textura
//Profesor: Diego Salamanca

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadImageFromInternet : MonoBehaviour
{
    public RawImage rawImage;
    public InputField inputField;

    public Image image;

    public Slider slider;
    string deafultUrl = "https://unsplash.com/photos/WeSZSnnYojY/download?force=true";

//Metodo para inicializar la corutina y descargar la imagen
    public void StartDonwload()
    {
        StartCoroutine( DownloadImage());  
    }


//Corutina para realizar la petición GET y obtener la textura de una URL
    public IEnumerator DownloadImage()
    {
        // se invoca Unity Web request y se usa get texture para recibir no recibir los datos serializados 
        var request = UnityWebRequestTexture.GetTexture(inputField.text);
        // Se envia la petición 
        var peticion = request.SendWebRequest();   

        //Mientras la petición no este completa se repite el código dentro del While
        while(!peticion.isDone)   
        {
            print(request.downloadProgress);
            slider.value = request.downloadProgress;
            yield return null;
        }  

            if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                print("Error = "+ request.result);
            }
            else
            {
                Texture myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                
                rawImage.texture = myTexture;

                image.sprite = SpriteFromTexture2D((Texture2D)myTexture);
                
            } 


    }

    //Metodo para transformar una textura en sprite
    Sprite SpriteFromTexture2D(Texture2D texture) 
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }  
    
}
