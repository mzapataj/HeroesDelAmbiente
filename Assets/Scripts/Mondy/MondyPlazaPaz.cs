using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MondyPlazaPaz : Mondy
{

    public Dictionary<string, int> Desechos_depositados;
    
    public MondyPlazaPaz(int vida, Text vida_text) : base(vida, vida_text)
    {
        Desechos_depositados = new Dictionary<string, int>();
    }

}
