using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Texture2D map;

    [SerializeField] private ColorToPrefab[] colorMappings;

    [SerializeField] private float offset = 5f;

    [Header("Desctructible Walls")]
    [SerializeField] private GameObject destructibleWallPrefab;
    [SerializeField] private Color destructibleWallColorMapping;
    [Range(0f, 1f)]
    [SerializeField] private float destructibleWallChance = 0.7f;


    private void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
            return;

        foreach(ColorToPrefab mapping in colorMappings)
        {
            if (mapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(mapping.prefab, position, Quaternion.identity, transform);

                if (mapping.color == destructibleWallColorMapping)
                {
                    PutDestructibleWall(position);
                }

                break;
            }
        }
    }

    private void PutDestructibleWall(Vector3 position)
    {
        float diceRoll = Random.Range(0f, 1f);

        if (diceRoll > destructibleWallChance) return;

        Instantiate(destructibleWallPrefab, position, Quaternion.identity, transform);
    }

    public void GenerateLevel()
    {
        ClearLevel();

        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }

    void ClearLevel()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
