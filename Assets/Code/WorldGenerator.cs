/*See https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/ for details! */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    // Перетащите сюда объект Voxel со сцены
    // Используется для создания новых экземпляров
    public GameObject Voxel;
    // Определяем размер мира
    public float SizeX;
    public float SizeY;
    public float SizeZ;

    // Use this for initialization
    void Start()
    {
        // Стартуем поток генерации мира
        // Создание перенесено в GameManager.cs
        //StartCoroutine(SimpleGenerator());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // For outer call
    public void StartGenerateWorld()
    {
        // Стартуем поток генерации мира
        StartCoroutine(SimpleGenerator());
    }

    // Our written
    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameObj)
    {
        GameObject clone = (GameObject)Instantiate(originalGameObj, newPosition, Quaternion.identity);
        clone.transform.position = newPosition;
        clone.name = "Voxel@" + clone.transform.position;
    }

    IEnumerator SimpleGenerator()
    {
        // В этом потоке мы будем создавать 50 кубов за один фрейм
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;
        for (int x = 1; x <= SizeX; ++x)
        {
            for (int z = 1; z <= SizeZ; ++z)
            {
                float height = Random.Range(0, SizeY);
                for (int y = 0; y <= height; ++y)
                {
                    // Расчитываем позицию для каждого блока
                    Vector3 newPosition = new Vector3(x, y, z);
                    // Вызываем метод, передавая ему новую позицию и экземпляр куба
                    CloneAndPlace(newPosition, Voxel);
                    ++numberOfInstances;
                    // Если было достигнуто предельное количество экземпляров за фрейм
                    if (numberOfInstances == instancesPerFrame)
                    {
                        numberOfInstances = 0;
                        // И ждем следующего фрейма
                        yield return new WaitForEndOfFrame();
                    }
                }
            }
        }
    }
}

