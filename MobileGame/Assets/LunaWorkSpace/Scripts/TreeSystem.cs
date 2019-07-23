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
    [SerializeField]
    private float treeCooldown;

    public LayerMask layerToHit;
    public GameEvent onTreePlace;
    public GameEvent onCanPlaceTree;
    private bool canPlaceTree = true;

    Camera camera;

    public Placeable selectedPlaceable;

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
        if(!selectedPlaceable.available)return;
        selectedPlaceable.Purchase();
        // if(!canPlaceTree)return;
        GameObject i = Instantiate(youngTree, pos, Quaternion.identity);
        onTreePlace.Raise();
        canPlaceTree = false;
        // StartCoroutine(TreeTimer());
        StartCoroutine(GrowTree(i));
    }

    IEnumerator GrowTree(GameObject youngTree)
    {
        yield return new WaitForSeconds(timeToGrow);
        Vector3 pos = youngTree.transform.position;
        Destroy(youngTree);
        Instantiate(oldTree, pos, Quaternion.identity);
    }

    // IEnumerator TreeTimer() {
    //   yield return new WaitForSeconds(treeCooldown);
    //     canPlaceTree = true;
    //     onCanPlaceTree.Raise();
    // }
}
