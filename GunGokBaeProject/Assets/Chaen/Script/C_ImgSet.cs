using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ImgSet : MonoBehaviour
{
    public Image image; // 이 코드를 사용할 이미지
    public Button button; // 오른쪽에 위치시킬 버튼

    RectTransform imageTransform;
    RectTransform buttonTransform;

    Vector2 buttonPosition;

    // Start is called before the first frame update
    void Start()
    {
        // 이미지와 버튼의 RectTransform을 가져옵니다.
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
