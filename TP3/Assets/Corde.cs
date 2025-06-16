using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corde : MonoBehaviour
{

    public Transform baseFlèche; // Le point d'ancrage de la corde sur la flèche
    public Transform crochet; // Le crochet où se termine la corde
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
       lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;  
    }

    // Update is called once per frame
    void Update()
    {
        
      lineRenderer.SetPosition(0, baseFlèche.position); // Position du début de la corde
        lineRenderer.SetPosition(1, crochet.position);  //Position du crochet  
    }
}
