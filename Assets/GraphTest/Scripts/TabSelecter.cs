using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelecter : MonoBehaviour
{
    [SerializeField] private Transform tab_fav;
    [SerializeField] private Transform tab_sales;
    [SerializeField] private Transform tab_users;

    [SerializeField] private GameObject moneyGraphTexts;
    [SerializeField] private GameObject satifiGraphTexts;
    [SerializeField] private GameObject userGraphTexts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectFav()
    {
        tab_fav.SetAsLastSibling();
        moneyGraphTexts.SetActive(false);
        satifiGraphTexts.SetActive(true);
        userGraphTexts.SetActive(false);
    }

    public void SelectSales()
    {
        tab_sales.SetAsLastSibling();
        moneyGraphTexts.SetActive(true);
        satifiGraphTexts.SetActive(false);
        userGraphTexts.SetActive(false);
    }

    public void SelectUsers()
    {
        tab_users.SetAsLastSibling();
        moneyGraphTexts.SetActive(false);
        satifiGraphTexts.SetActive(false);
        userGraphTexts.SetActive(true);
    }
}
