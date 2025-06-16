using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LectureData : MonoBehaviour
{
public TextAsset jsonFile;
public VisuData Visualize;
void Start()
{
Cities citiesInJson = JsonUtility.FromJson<Cities>(jsonFile.text);foreach (City cities in citiesInJson.cities){
Visualize.VisualCube(
cities.lat,
cities.lng,
cities.population,
Visualize.multiplier
);
}
}
// Update is called once per frame
void Update()
{
}
}