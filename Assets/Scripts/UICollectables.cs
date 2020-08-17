using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollectables : MonoBehaviour
{
    public Image CollectableIcon;
    public Text CollectableAmount;

    public void UpdateCollectableAmount(int _amount)
    {
        CollectableAmount.text = _amount.ToString();
    }
}
