using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rangement : MonoBehaviour
{

        private int stock=0;
        private float temps= 300.0f;
        private float tempsEcoule=0.0f;
        private int tempsRestant =0;
        private int minutes = 0;
        private int secondes = 0;
        private float tempsAttente = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        tempsEcoule=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // À chaque frame, on incrémente le temps écoulé
         tempsEcoule += Time.deltaTime;
         int tempsRestant = (int)(temps - tempsEcoule);
         if (tempsRestant < 0) tempsRestant = 0; // Empêcher le temps restant d'être négatif

        minutes = tempsRestant/60;
        secondes = tempsRestant%60;
        // Si le temps écoulé est supérieur ou égal au temps, on recharge la scène
        if (tempsEcoule >= temps)
        {
            Reset();
        }
        if(stock >= 4)
            {
                         tempsAttente -= Time.deltaTime;

                if(tempsAttente <= 0)
                {
                Reset();
            }

    }
    }

    void OnGUI()
    {
                
        GUI.Box(new Rect(Screen.width - 310, 10, 300, 80), "Stock");
        GUI.Label(new Rect(Screen.width - 300, 40, 280, 20), "Est stocké: "+ stock );
        // Affiche le temps restant
        GUI.Label(new Rect(Screen.width - 300, 60, 280, 20), "Temps restant: " + minutes + "m " + secondes + "s");
        // Quand le stock atteint 4 le joueur a gagné
        if (stock >= 4)
        {

            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Vous avez gagné !");
        }

    }
    private void OnTriggerEnter(Collider other)
{
    if (IgnoreObjet(other))
        {
            return; // Ignore cet objet et sort de la méthode
        }
Debug.Log("Element ajouté");
stock++;
Debug.Log("Stocks : " + stock);
}
    
    private void OnTriggerExit(Collider other)
    {
        if (IgnoreObjet(other))
        {
            return; // Ignore cet objet et sort de la méthode
        }
        Debug.Log("Element retiré");
        stock--;
        Debug.Log("Stocks : " + stock);

    }
    


    private bool IgnoreObjet(Collider collider)
    {
        // Vérifie le tag de l'objet et de son parent
        if (collider.CompareTag("Ignore"))
        {
            return true; // Ignore cet objet
        }

        // Vérifie si le parent de l'objet a le tag "IgnoreTag"
        Transform parent = collider.transform.parent;
        while (parent != null)
        {
            if (parent.CompareTag("Ignore"))
            {
                return true; // Ignore le parent
            }
            parent = parent.parent; // Remonte dans la hiérarchie
        }

        return false; // L'objet et ses parents ne sont pas ignorés
    }
    private void Reset()
    {
                    SceneManager.LoadScene("GrueMAEDA");

    }

}

 

