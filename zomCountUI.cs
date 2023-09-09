using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zomCountUI : MonoBehaviour
{
    public Text count;
    public ZombieCount zombie;
    public GameObject complete;
    public GameObject fail;
    // Start is called before the first frame update
    void Start()
    {
        complete.SetActive(false);
        fail.SetActive(false);
        zombie.zomCount = 0;
        zombie.fail = false;
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "100 / " + (100-zombie.zomCount);
        if (100 - zombie.zomCount == 0)
        { 
            complete.SetActive(true);
            Time.timeScale = 0;
        }
        if(zombie.fail)
        {
            fail.SetActive(true);
        }
    }
}
