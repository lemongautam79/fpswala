using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class weaponsswitching : MonoBehaviour
{

    InputAction switching;
    public int selectedweapon = 0;
    public TextMeshProUGUI ammoInfotext;
    void Start()
    {
        // ! for mouse
        switching = new InputAction("Scroll", binding: "<Mouse>/scroll");

        // ! for gamepad
        switching.AddBinding("<Gamepad>/Dpad");
        switching.Enable();
Selectweapon();
    }

    void Update()
    {
         gun currentgun = FindObjectOfType<gun>();// accessing other script called gun 

         //! displaying ui for ammo left and magazine size
       ammoInfotext.text = currentgun.currentAmmo + " / " + currentgun.magazineSize;
       
       
       float scrollvalue = switching.ReadValue<Vector2>().y;
          int previousselected = selectedweapon;
       if(scrollvalue > 0)
       {
           selectedweapon++;
           if(selectedweapon == 3)
           selectedweapon = 0;
       }
       else if(scrollvalue < 0)
       {
           selectedweapon--;
           if(selectedweapon == -1)
           selectedweapon = 2;
       }
       if(previousselected != selectedweapon)
       {
           Selectweapon();
       }
    }
    private void Selectweapon()
    {
            foreach(Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedweapon).gameObject.SetActive(true);
    }
}
