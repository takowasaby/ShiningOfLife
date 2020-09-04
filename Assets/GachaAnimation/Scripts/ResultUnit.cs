using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUnit : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Text characterName;

    private float rotateSpeed=0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        characterImage.transform.rotation = Quaternion.Euler(0, 0, 0);
        rotateSpeed = Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        characterImage.transform.rotation *= Quaternion.Euler(0, 0, rotateSpeed);
    }

    public void SetCharaProfile(Sprite charaSprite, string name, Color nameColor)
    {
        characterImage.sprite = charaSprite;
        characterName.text = name;
        characterName.color = nameColor;
    }
}
