using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ImgSet : MonoBehaviour
{
    public Image image; // �� �ڵ带 ����� �̹���
    public Button button; // �����ʿ� ��ġ��ų ��ư

    RectTransform imageTransform;
    RectTransform buttonTransform;

    Vector2 buttonPosition;

    // Start is called before the first frame update
    void Start()
    {
        // �̹����� ��ư�� RectTransform�� �����ɴϴ�.
        imageTransform = image.GetComponent<RectTransform>();
        buttonTransform = button.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        buttonPosition = buttonTransform.anchoredPosition;

        imageTransform.anchoredPosition = new Vector2(buttonPosition.x - 355, buttonPosition.y + 100);
    }
}
