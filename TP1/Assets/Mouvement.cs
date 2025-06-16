using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float marche = 0.01f;
    public float sprint = 0.015f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vitesse = Input.GetKey(KeyCode.LeftShift) ? sprint : marche;// vu que update est appele à chaque frame 
        // on peut vérifier si l'utilisateur maintient la touche sprint à chaque seconde et on attribue la valeur de vitesse dans vitesse.
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 0.1f);
        }

 
        if (Input.GetKey(KeyCode.DownArrow))
{
transform.Translate(Vector3.forward * vitesse);
}
if (Input.GetKey(KeyCode.UpArrow))
{
transform.Translate(Vector3.back * vitesse);
}
    
if (Input.GetKey(KeyCode.LeftArrow))
{
transform.Rotate(Vector3.up, -2);
}
if (Input.GetKey(KeyCode.RightArrow))
{
transform.Rotate(Vector3.up, 2);
}
    }
}
