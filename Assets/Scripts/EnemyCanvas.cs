using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCanvas : MonoBehaviour
{
    public string Nome;
    public TMP_Text TexotNome;
    public TMP_Text TextoVidas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TexotNome.text = Nome;
        TextoVidas.text = GetComponent<EnemyManager>().Vidas.ToString();
    }
}
