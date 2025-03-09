using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnPrefabAtClick();
        }
    }

    void SpawnPrefabAtClick()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(projectilePrefab, hit.point, Quaternion.identity);
            Debug.Log("Proyectile created.");
        }
    }
}
