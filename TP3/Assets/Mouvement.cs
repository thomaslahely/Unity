using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public float marche = 0.01f;
    public float sprint = 0.015f;
    public bool Visible =false;
    public float delai = 0.5f;// délai pour éviter que lorque l'utilisateur appuie 1 fois sur tab le menu s'affiche plusieurs fois
    private float temps = 0.0f;
    private List<Camera> cameras;
    private int cameraActuel;

    // Start is called before the first frame update
    void Start()
    {

        // on récupère toutes les caméras de la scène
        cameras = new List<Camera>(FindObjectsOfType<Camera>());
        // on désactive toutes les caméras sauf la première
        cameraActuel = 0;
        for(int i=1;i<cameras.Count;i++){
            if(i == cameraActuel){
            cameras[i].enabled = true;
        }
                    cameras[i].enabled = false;

        
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        float vitesse = Input.GetKey(KeyCode.LeftShift) ? sprint : marche;// vu que update est appele à chaque frame 
        // on peut vérifier si l'utilisateur maintient la touche sprint à chaque seconde et on attribue la valeur de vitesse dans vitesse.
      
        // on vérifie si l'utilisateur appuie sur la touche tab et si le temps écoulé depuis la dernière fois que l'utilisateur a appuyé sur tab est supérieur au délai
        if(Input.GetKey(KeyCode.Tab)&& Time.time > temps + delai)
        {
            // on met à jour le temps
            temps = Time.time;
            // on change la visibilité du menu
            Visible = !Visible;
        }

         if (Input.GetKeyDown(KeyCode.F))
        {
            // on désactive la caméra actuelle
            cameras[cameraActuel].enabled = false;
            // on incrémente l'indice de la caméra actuelle
            cameraActuel++;
            // on vérifie si on a atteint la fin de la liste des caméras si oui on revient au début
            if(cameraActuel >= cameras.Count){
                cameraActuel = 0;
            }
            // on active la nouvelle caméra actuelle
            cameras[cameraActuel].enabled = true;
        }
       

 
        if (Input.GetKey(KeyCode.DownArrow))
{
transform.Translate(Vector3.down * vitesse);
}
if (Input.GetKey(KeyCode.UpArrow))
{
transform.Translate(Vector3.up * vitesse);
}
    
if (Input.GetKey(KeyCode.LeftArrow))
{
transform.Rotate(Vector3.forward, -2);
}
if (Input.GetKey(KeyCode.RightArrow))
{
transform.Rotate(Vector3.forward, 2);
}
    }

    void OnGUI()
{

    // si le menu est visible on affiche les commandes
    if(Visible){
        GUI.Box(new Rect(10, 10, 300, 250), "Menu commander");
        GUI.Label(new Rect(20, 40, 280, 20), "Se déplacer : les flèches directionnelles");
        GUI.Label(new Rect(20, 60, 280, 20), "Sprint : Shift");
        GUI.Label(new Rect(20, 80, 280, 20), "S/Z : déplacer la flèche");
        GUI.Label(new Rect(20, 100, 280, 20), "T/Y : déployer les pieds");
        GUI.Label(new Rect(20, 120, 280, 20), "U/I : poser les pieds");
        GUI.Label(new Rect(20, 140, 280, 20), "W/X : monter/descendre la flèche");
        GUI.Label(new Rect(20, 160, 280, 20), "C/V : tourner la flèche");
        GUI.Label(new Rect(20, 180, 280, 20), "G/H : Grappin");
        GUI.Label(new Rect(20, 200, 280, 20), "Tab : cacher le menu");
        GUI.Label(new Rect(20, 220, 280, 20), "F : Changer de caméra");
    }
    else{
        GUI.Box(new Rect(10, 10, 300, 50), "Appuyer sur tab pour afficher les commandes");
    }
}
}

