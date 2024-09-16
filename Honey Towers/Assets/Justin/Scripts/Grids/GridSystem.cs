using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridSystem : MonoBehaviour
{
    public GameObject grid;
    public GameObject highLight;

    public LayerMask path;
    private GameObject tileClone;

    public Bounds bounds;
    private void Start()
    {
        
        bounds = GetComponent<Collider>().bounds;
        print(bounds.max.y);
        for (int x = 0; x < transform.localScale.x; x++)
        {
            for (int z = 0; z < transform.localScale.z; z++)
            {
                tileClone = Instantiate(grid, new Vector3(bounds.min.x + x, bounds.max.y, bounds.min.z + z), Quaternion.identity);

                Collider[] hitColliders = Physics.OverlapBox(tileClone.transform.position, tileClone.transform.lossyScale, Quaternion.identity, path);

                if (hitColliders.Length > 0)
                {
                    print("There is no such place as a gridtile for this place man. Place: " + tileClone.transform.position);
                    Destroy(tileClone);
                }
            }
        }
    }
}
