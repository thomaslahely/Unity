using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Declencheur : MonoBehaviour
{
    // On crée une variable stock qui va stocker le nombre d'éléments dan la zone de déclenchement
        private int stock=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
{

Debug.Log("Element ajouté");
stock++;
Debug.Log("Stocks : " + stock);
}
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Element retiré");
        stock--;
        Debug.Log("Stocks : " + stock);

    }
}
