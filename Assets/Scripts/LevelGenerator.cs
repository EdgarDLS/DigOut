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
    public float terrainSeparation;

    public string[] level1 =
    {
        "WWWWW",
        "WWWWW"
    };

	void Awake ()
    {
		for (int i = 0; i < level1.Length; i++)
        {
            for (int j = 0; j < level1[i].Length; j++)
            {
                // P - Player | T - Terrain | W- Wall |O - Obstacles
                switch (level1[i][j])
                {
                    case 'P':
                        Instantiate(player, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation);
                        break;
                    case 'T':
                        Instantiate(terrain, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation);
                        break;
                    case 'W':
                        Instantiate(wall, mapBeginingPosition.position + (new Vector3(j * terrainSeparation, -i * terrainSeparation, 0)), mapBeginingPosition.rotation);
                        break;
                }
            }
        }
	}

}
