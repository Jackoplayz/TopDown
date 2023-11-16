using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float deselectedScale, selectedScale;
    public Image pistolImage, rifleImage, shotgunImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedWeapon(int index)
    {
        pistolImage.transform.localScale = new Vector3(deselectedScale, deselectedScale, 1);
        rifleImage.transform.localScale = new Vector3(deselectedScale, deselectedScale, 1);
        shotgunImage.transform.localScale = new Vector3(deselectedScale, deselectedScale, 1);
        switch (index)
        {
            case 0:
                pistolImage.transform.localScale = new Vector3(selectedScale, selectedScale, 1);
            break;

            case 1:
                rifleImage.transform.localScale = new Vector3(selectedScale, selectedScale, 1);
            break;

            case 2:
                shotgunImage.transform.localScale = new Vector3(selectedScale, selectedScale, 1);
            break;
        }
    }


}



