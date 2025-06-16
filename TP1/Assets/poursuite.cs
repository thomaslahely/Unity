using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poursuite : MonoBehaviour
{
    private Transform Joueur; 
    private float vitesseAgro = 0.5f;  // Vitesse de poursuite


    void Start()
    {
        // Trouver le joueur
    Mouvement joueurScript = FindObjectOfType<Mouvement>();
        if (joueurScript != null)
        {
            Joueur = joueurScript.transform;
        }
       
    }        
    
    // Update est appelée à chaque frame
    void Update()
    {



        if (Joueur != null)
        {
            // Calculer la direction vers le joueur
            Vector3 direction = Joueur.position - transform.position;
            direction.Normalize();  // Normaliser le vecteur pour garder la même direction, indépendamment de la distance

            // Déplacer l'agro vers le joueur
            transform.position = Vector3.MoveTowards(transform.position, Joueur.position, vitesseAgro * Time.deltaTime);

            // Optionnel : Faire tourner l'agro pour qu'il regarde toujours vers le joueur
            transform.LookAt(Joueur);
            transform.Rotate(0, 180, 0);  // Faire tourner l'agro de 180 degrés pour qu'il regarde vers le joueur}
    }
}
}