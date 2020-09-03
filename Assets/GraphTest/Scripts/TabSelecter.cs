using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelecter : MonoBehaviour
{
    [SerializeField] private Transform tab_fav;
    [SerializeField] private Transform tab_sales;
    [SerializeField] private Transform tab_users;
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
    }

    public void SelectSales()
    {
        tab_sales.SetAsLastSibling();
    }

    public void SelectUsers()
    {
        tab_users.SetAsLastSibling();
    }
}
