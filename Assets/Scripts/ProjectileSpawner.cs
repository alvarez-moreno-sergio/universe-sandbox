using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            SpawnPrefabAtClick();
        }
    }

    void SpawnPrefabAtClick()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition); // Create a ray from the camera through the mouse position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // Check if the ray hits something
        {
            Instantiate(projectilePrefab, hit.point, Quaternion.identity); // Spawn the prefab at the hit position
        }
    }
}
