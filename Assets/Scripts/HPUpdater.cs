using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUpdater : MonoBehaviour
{
    [SerializeField]private Image _hpbar;
    private Mortal _mortal;

    // Start is called before the first frame update
    void OnEnable()
    {
        _mortal = GetComponent<Mortal>();
        _mortal.onHit += HealthUpdate;
        _mortal.onHealed += HealthUpdate;
    }
    private void OnDisable()
    {
        _mortal.onHit -= HealthUpdate;
        _mortal.onHealed -= HealthUpdate;
    }
    private void HealthUpdate(int amount, int health, int maxhealth)
    {
        _hpbar.fillAmount = ((float)health - (float)amount) / (float)maxhealth;
    }
}
