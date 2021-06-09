using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] float offset;
    [SerializeField] GameObject bullet;
    [SerializeField] Slider slider;
    [SerializeField] Transform ShotPoint;
    [SerializeField] float timeBtwShots;
    [SerializeField] int bulletCount = 10;
    [SerializeField] float reloadTime = 2;
    bool isShoot = false;
    int bulets;
    bool isReload = false;
    void Start()
    {
        bulets = bulletCount;
        slider.maxValue = bulletCount;
        slider.value = bulets;
        StartCoroutine(Shoots());
    }

    
    void Update()
    {
        Vector3 difference = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            isReload = true;
        }
    }
    IEnumerator Shoots()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && isReload == false)
            {
                if (bulets > 0 && !isReload)
                {
                    Instantiate(bullet, ShotPoint.position, transform.rotation);
                    slider.value = bulets;
                    bulets--;
                }
                else if (!isReload)
                {
                    isReload = true;
                    StartCoroutine(Reload());
                }
                yield return new WaitForSeconds(timeBtwShots);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Reload()
    {
        slider.fillRect.GetComponent<Image>().color = Color.red;
        while (bulets < bulletCount)
        {
            bulets++;
            slider.value = bulets;
            yield return new WaitForSeconds(reloadTime);
        }
        slider.fillRect.GetComponent<Image>().color = Color.white;
        isReload = false;
    }
}
