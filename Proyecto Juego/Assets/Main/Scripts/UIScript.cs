using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public static UIScript instance { get; private set; }

    public Image Mask1;
    public Image Mask2;
    public Image Mask3;
    public Image Mask4;
    public Image Mask5;
    public Image Mask6;
    public Image Mask7;
    public Image Mask8;

    float originalSizeHealth;
    float originalSizeDiamond;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalSizeHealth = Mask1.rectTransform.rect.width;
        originalSizeDiamond = Mask6.rectTransform.rect.width;

        Mask6.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeDiamond);
        Mask7.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        Mask8.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
    }

    // Update is called once per frame
    public void ChangeHealthBar(float value)
    {

        if(value == 0)
        {
            Mask1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
        else if(value == 1)
        {
            Mask1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
        else if(value == 2)
        {
            Mask2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask3.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
        else if(value == 3)
        {
            Mask3.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
        else if(value == 4)
        {
            Mask4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask5.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
        else if(value == 5)
        {
            Mask1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask3.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
            Mask5.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth);
        }
    }

    public void ChangeDiamondCounter(float value)
    {
        if (value == 0)
        {
            Mask6.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeDiamond);
        }
        else if (value == 1)
        {
            Mask6.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            Mask7.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeDiamond);
        }
        else if (value == 2)
        {
            Mask7.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            Mask8.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeDiamond);
        }
    }
}
