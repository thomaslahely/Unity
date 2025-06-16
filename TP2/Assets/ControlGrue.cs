using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGrue : MonoBehaviour
{


public float torque = 250f;
public float forceChariot = 500f;
public float forceMoufle = 500f;
public ArticulationBody pivot;
public ArticulationBody chariot;
public ArticulationBody moufle;

    private List<Camera> cameras;
    private int cameraActuel;

    // Start is called before the first frame update
    void Start()
    {

        // On récupère toutes les caméras de la scène
        cameras = new List<Camera>(FindObjectsOfType<Camera>());
        // On désactive toutes les caméras sauf la première
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
        // On change de caméra avec la touche C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // On désactive la caméra actuelle
            cameras[cameraActuel].enabled = false;
            // On passe à la caméra suivante
            cameraActuel++;
            // On remet à 0 si on a dépassé le nombre de caméras
            if(cameraActuel >= cameras.Count){
                cameraActuel = 0;
            }
            // On active la nouvelle caméra
            cameras[cameraActuel].enabled = true;
        }
        //commandes pour la fleche
if (Input.GetKey(KeyCode.LeftArrow))
{
pivot.AddTorque(transform.up * -torque);
}
if (Input.GetKey(KeyCode.RightArrow))
{
pivot.AddTorque(transform.up * torque);
}
//commandes pour le chariot
if (Input.GetKey(KeyCode.UpArrow))
{
chariot.AddRelativeForce(transform.right * forceChariot);}
if (Input.GetKey(KeyCode.DownArrow))
{
chariot.AddRelativeForce(transform.right * -forceChariot);}
//commande pour la moufle
if (Input.GetKey(KeyCode.LeftShift))
{
moufle.AddRelativeForce(transform.up * forceMoufle);}
if (Input.GetKey(KeyCode.LeftControl))
{
moufle.AddRelativeForce(transform.up * -forceMoufle);}
    }
}
