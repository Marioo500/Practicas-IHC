using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackImageRecognition : MonoBehaviour
{
    private  ARTrackedImageManager _arTRackedImage;
    public GameObject[] prefabs;
    public Dictionary<string, GameObject> prefabsDiccionario = new Dictionary<string,GameObject>();

    void Awake()
    {
        _arTRackedImage = GetComponent<ARTrackedImageManager>();
        foreach(GameObject prefab in prefabs)
        {
            GameObject instantprefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            instantprefab.name = prefab.name;
            prefabsDiccionario.Add(prefab.name, instantprefab);
        }
    }

    private void OnEnable()
    {
        _arTRackedImage.trackedImagesChanged += OnImageChange;

    }

    private void OnDisable()
    {
        _arTRackedImage.trackedImagesChanged -= OnImageChange;

    } 

    void OnImageChange(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage item in eventArgs.added) 
        {
            //Actualizamos imagen
            SetPrefab(item);
        
        }
        foreach (ARTrackedImage item in eventArgs.updated)
        {
            //Actualizamos imagen
            SetPrefab(item);
        
        }
        foreach (ARTrackedImage item in eventArgs.removed)
        {
            //Actualizamos imagen
            prefabsDiccionario[item.name].SetActive(false);
        
        }   
    }

   private void SetPrefab(ARTrackedImage trackedImage)
   {
        string name = trackedImage.referenceImage.name;
        Vector3 pos = trackedImage.transform.position;
        GameObject prefabb = prefabsDiccionario[name];
        prefabb.transform.position = pos;
        prefabb.SetActive(true);
        
    }
}
