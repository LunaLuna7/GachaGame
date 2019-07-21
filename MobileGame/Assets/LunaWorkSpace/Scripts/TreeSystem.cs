using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject youngTree;
    [SerializeField]
    private GameObject oldTree;

    [SerializeField]
    private float timeToGrow;

    public LayerMask layerToHit;

    Camera camera;

    private void Start() 
    {
        camera = Camera.main;    
    }

    private void OnMouseDown() 
    {
        RaycastHit hit; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if ( Physics.Raycast (ray,out hit,100.0f, layerToHit)) 
        {
           
            PlantTree(hit.point);
        }   
    }

    private void PlantTree(Vector3 pos)
    {
        GameObject i = Instantiate(youngTree, pos, Quaternion.identity);
        StartCoroutine(GrowTree(i));
    }

    IEnumerator GrowTree(GameObject youngTree)
    {
        yield return new WaitForSeconds(timeToGrow);
        Vector3 pos = youngTree.transform.position;
        Destroy(youngTree);
        Instantiate(oldTree, pos, Quaternion.identity);
    }
}
