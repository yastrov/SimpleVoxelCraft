using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnFaceScript : MonoBehaviour {
    // Хранит смещение, требуемое для расчета позиции нового объекта
    public Vector3 delta;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // Эта функция вызывается, когда курсор находится над GameObject, на котором этот скрипт расположен
    void OnMouseOver()
    {
        // Если нажата левая клавиша мыши
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left click!");
            Destroy(this.transform.parent.gameObject);
        }
        // Если правая клавиша нажата
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click!");
            // Вызываем метод из класса WorldGenerator
            WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                                         this.transform.parent.gameObject); // Родительский GameObject
        }
    }
}
