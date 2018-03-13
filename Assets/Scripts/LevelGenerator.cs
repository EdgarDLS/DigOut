using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator levelGenerator;

    public Transform mapBeginingPosition;
    
    public GameObject player;
    public GameObject terrain;
    public GameObject wall;
    public GameObject rock;
    public GameObject box;
    public GameObject door;

    [Space]
    public Color levelColor;
    public float terrainSeparation;

    [HideInInspector]
    public bool playerDead = false;

    [Space]
    public string[] level =
    {
        "WWWWW",
        "WWWWW"
    };



    private void Awake()
    {
        if (levelGenerator != null)
            GameObject.Destroy(levelGenerator);
        else
            levelGenerator = this;
    }

    void Start ()
    {
        GenerateLevel();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && playerDead)
        {
            ResetPlayer();
        }
    }

    private void ResetPlayer()
    {
        for (int i = 0; i < level.Length; i++)
        {
            for (int j = 0; j < level[i].Length; j++)
            {
                if (level[i][j] == 'P')
                {
                    GameObject newPlayer = Instantiate(player, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                    newPlayer.name = "Player";
                    newPlayer.transform.parent = transform;
                }
            }
        }

        KillerBall.killerBall.ResetBall();

        playerDead = false;
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

        Transform obstacleHolder = new GameObject("Obstacles").transform;
        obstacleHolder.parent = levelHolder;

        for (int i = 0; i < level.Length; i++)
        {
            for (int j = 0; j < level[i].Length; j++)
            {
                // P - Player | T - Terrain | W- Wall |O - Obstacles
                switch (level[i][j])
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
                    case 'R':
                        GameObject newTerrainRock = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrainRock.transform.parent = terrainHolder;
                        GameObject newRock = Instantiate(rock, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, -0.6f)), mapBeginingPosition.rotation) as GameObject;
                        newRock.transform.parent = wallHolder;
                        break;
                    case 'B':
                        GameObject newTerrainBox = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrainBox.transform.parent = terrainHolder;
                        GameObject newBox = Instantiate(box, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, -0.6f)), mapBeginingPosition.rotation) as GameObject;
                        newBox.transform.parent = wallHolder;
                        break;
                    case 'D':
                        GameObject newTerrainDoor = Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation) as GameObject;
                        newTerrainDoor.transform.parent = terrainHolder;
                        GameObject newDoor = Instantiate(door, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, -0.6f)), mapBeginingPosition.rotation) as GameObject;
                        newDoor.transform.parent = wallHolder;
                        break;
                }
            }
        }
    }
}
