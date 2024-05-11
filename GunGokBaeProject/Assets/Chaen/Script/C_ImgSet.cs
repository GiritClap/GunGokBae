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
    float buttonWidth;
    float buttonHeight;
    float imageWidth;

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
        buttonWidth = buttonTransform.rect.width;
        buttonHeight = buttonTransform.rect.height;
        imageWidth = imageTransform.rect.width;

        imageTransform.anchoredPosition = new Vector2(buttonPosition.x - 365, buttonPosition.y + 105);
    }
}
