using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Serializables 
{
    
}

[Serializable]
public class Days
{
    public int lunes, martes, miercoles, jueves, viernes, sabado, domingo;

}

[Serializable]
public class pokemonInfo
{
    public string name;
    public int id;
    public SpriteObject sprites;

    public TypesList[] types;

}

[Serializable]
public class SpriteObject
{   
    public string front_default;
}
[Serializable]
public class TypesList
{       
    public TypesElement type;
}
[Serializable]
public class TypesElement
{   
    public string name;
}

[Serializable]
public class FormData
{   
    public string AccessToken;
    public string TitleId;
}
