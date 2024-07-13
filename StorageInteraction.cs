using UnityEngine;

public class StorageInteraction : MonoBehaviour
{
    public float interactionDistance = 2f; 
    public GameObject storageButton; 
    private GameObject currentStorageTable;

    private void Start()
    {
       
        if (storageButton != null)
        {
            storageButton.SetActive(false);
        }
        
        GameObject[] storageTables = GameObject.FindGameObjectsWithTag("storage_table");
        foreach (GameObject table in storageTables)
        {
            Outline outline = table.GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = false;
            }
        }
    }

    private void Update()
    {
        DetectStorageTable();
    }

    private void DetectStorageTable()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("storage_table"))
            {
                // deteksi object
                if (currentStorageTable != hit.collider.gameObject)
                {
                    if (currentStorageTable != null)
                    {
                        
                        Outline outline = currentStorageTable.GetComponent<Outline>();
                        if (outline != null)
                        {
                            outline.enabled = false;
                        }
                    }
                    
                    currentStorageTable = hit.collider.gameObject;
                    // Aktifkan Outline
                    Outline newOutline = currentStorageTable.GetComponent<Outline>();
                    if (newOutline != null)
                    {
                        newOutline.enabled = true;
                    }
                    // aktifkan UI
                    if (storageButton != null)
                    {
                        storageButton.SetActive(true);
                    }
                }
            }
        }
        else
        {
            // matikan outline
            if (currentStorageTable != null)
            {
                Outline outline = currentStorageTable.GetComponent<Outline>();
                if (outline != null)
                {
                    outline.enabled = false;
                }
                currentStorageTable = null;
                // metikan UI
                if (storageButton != null)
                {
                    storageButton.SetActive(false);
                }
            }
        }
    }

    public void openStorage()
    {
        if (currentStorageTable != null)
        {
            // Menampilkan UI storage
            // Implementasi untuk menampilkan UI storage sesuai dengan kebutuhan
            Debug.Log("Storage opened");
        }
    }
}
