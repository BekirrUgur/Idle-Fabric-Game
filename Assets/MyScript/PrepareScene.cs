using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PrepareScene : MonoBehaviour
{

    public GameObject Company;
    private TextMeshProUGUI _CompanyName;
    public GameObject GameMusic;
    private AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {
        Music = GameMusic.GetComponent<AudioSource>();
        Music.volume = PlayerPrefs.GetFloat("BackgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompanyName() 
    {
        _CompanyName = Company.GetComponent<TextMeshProUGUI>();
        Debug.Log(_CompanyName.text);
        PlayerPrefs.SetInt("Prepare", 1);
        PlayerPrefs.SetString("CompanyName", _CompanyName.text);
        PlayerPrefs.SetString("MyMoney","40000");
        PlayerPrefs.SetString("StockChange","0");

        #region Stock Market Data

        #region BTC
        PlayerPrefs.SetString("BtcBuyPanel", "40");
        PlayerPrefs.SetString("BtcSellPanel", "40");
        PlayerPrefs.SetString("BtcOwnedPanel", "0");
        PlayerPrefs.SetString("BtcBuyBool", "True");
        PlayerPrefs.SetString("BtcSellBool", "True");
        #endregion

        #region HBZ
        PlayerPrefs.SetString("HbzBuyPanel", "20");
        PlayerPrefs.SetString("HbzSellPanel", "20");
        PlayerPrefs.SetString("HbzOwnedPanel", "0");
        PlayerPrefs.SetString("HbzBuyBool", "True");
        PlayerPrefs.SetString("HbzSellBool", "True");
        #endregion

        #region GOLD
        PlayerPrefs.SetString("GoldBuyPanel", "800");
        PlayerPrefs.SetString("GoldSellPanel", "800");
        PlayerPrefs.SetString("GoldOwnedPanel", "0");
        PlayerPrefs.SetString("GoldBuyBool", "True");
        PlayerPrefs.SetString("GoldSellBool", "True");
        #endregion

        PlayerPrefs.SetString("RestartTime","31");
        #endregion

        #region Bank Data
        PlayerPrefs.SetString("PropertyValue", "10000");
        PlayerPrefs.SetFloat("BankTime", 3600.0f);
        #region Plan A

        PlayerPrefs.SetString("RemainingDebtA","0");
        PlayerPrefs.SetString("CreditLimitA","500");
        PlayerPrefs.SetString("CreditA", "500");

        #endregion

        #region Plan B

        PlayerPrefs.SetString("RemainingDebtB", "0");
        PlayerPrefs.SetString("CreditLimitB", "1000");
        PlayerPrefs.SetString("CreditB", "1000");


        #endregion
        #endregion

        #region Warehouse Data

        PlayerPrefs.SetString("SmallWarehouse","0");
        PlayerPrefs.SetString("MediumWarehouse", "0");
        PlayerPrefs.SetString("LargeWarehouse", "0");
        PlayerPrefs.SetString("MegaWarehouse", "0");

        #endregion

        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);


    }
}
