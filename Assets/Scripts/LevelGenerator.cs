using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform mapBeginingPosition;
    
    public GameObject player;
    public GameObject terrain;
    public GameObject wall;

    [Space]
    public Color levelColor;
    public float terrainSeparation;

    public string[] level1 =
    {
        "WWWWW",
        "WWWWW"
    };

	void Start ()
    {
        GenerateLevel();
	}

    public void GenerateLevel()
    {
        string levelHolderName = "Generated Level";

        // Condition necessary to avoid creating endless maps with the LevelEditor.cs
        if (transform.Find(levelHolderName))
            DestroyImmediate(transform.Find(levelHolderName).gameObject);

        Transform levelHolder = new GameObject(levelHolderName).transform;
        levelHolder.parent = transform;

        Transform terrainHolder = new GameObject("Terrain").transform;
        terrainHolder.parent = levelHolder;

        Transform wallHolder = new GameObject("Walls").transform;
        wallHolder.parent = levelHolder;

        for (int i = 0; i < level1.Length; i++)
        {
            for (int j = 0; j < level1[i].Length; j++)
            {
                // P - Player | T - Terrain | W- Wall |O - Obstacles
                switch (level1[i][j])
                {
                    case 'P':
                        GameObject newPlayer = Instantiate(player, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newPlayer.name = "Player";
                        newPlayer.transform.parent = levelHolder;
                        break;
                    case 'T':
                        GameObject newTerrain = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrain.transform.parent = terrainHolder;
                        //newTerrain.GetComponent<SpriteRenderer>().color = levelColor;
                        //newTerrain.GetComponent<Material>().color = levelColor;
                        break;
                    case 'W':
                        GameObject newWall = Instantiate(wall, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newWall.transform.parent = wallHolder;
                        break;

                        
                }
            }
        }
    }
}
