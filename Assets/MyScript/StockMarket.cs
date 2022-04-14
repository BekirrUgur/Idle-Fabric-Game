using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StockMarket : MonoBehaviour
{

    #region Show Panel Variables

    #region BTC Variables
    public GameObject BtcBuyPanel;
    public GameObject BtcSellPanel;
    private TextMeshProUGUI BtcBuyPanelText;
    private TextMeshProUGUI BtcSellPanelText;

    
    #endregion

    #region HBZ Variables
    public GameObject HbzBuyPanel;
    public GameObject HbzSellPanel;
    private TextMeshProUGUI HbzBuyPanelText;
    private TextMeshProUGUI HbzSellPanelText;

    
    #endregion

    #region GOLD Variables
    public GameObject GoldBuyPanel;
    public GameObject GoldSellPanel;
    private TextMeshProUGUI GoldBuyPanelText;
    private TextMeshProUGUI GoldSellPanelText;

    
    #endregion

    #endregion

    #region Process Panel Variables

    public GameObject BtcOwnedPanel;
    private TextMeshProUGUI BtcOwnedPanelText;
    public GameObject BtcPerPanel;
    private TMP_InputField BtcPerPanelText;

    public GameObject HbzOwnedPanel;
    private TextMeshProUGUI HbzOwnedPanelText;
    public GameObject HbzPerPanel;
    private TMP_InputField HbzPerPanelText;

    public GameObject GoldOwnedPanel;
    private TextMeshProUGUI GoldOwnedPanelText;
    public GameObject GoldPerPanel;
    private TMP_InputField GoldPerPanelText;

    #endregion

    public GameObject ResetTime;
    private TextMeshProUGUI ResetTimeText;

    public GameObject MyMoney;
    private TextMeshProUGUI MyMoneyText;

    public GameObject WarningMenu;
  

    // Start is called before the first frame update
    void Start() 
    {
        #region Show Panel Assigment

        BtcBuyPanelText = BtcBuyPanel.GetComponent<TextMeshProUGUI>();
        BtcSellPanelText = BtcSellPanel.GetComponent<TextMeshProUGUI>();

        HbzBuyPanelText = HbzBuyPanel.GetComponent<TextMeshProUGUI>();
        HbzSellPanelText = HbzSellPanel.GetComponent<TextMeshProUGUI>();

        GoldBuyPanelText = GoldBuyPanel.GetComponent<TextMeshProUGUI>();
        GoldSellPanelText = GoldSellPanel.GetComponent<TextMeshProUGUI>();

        #endregion

        #region Process Panel Assigmet

        BtcOwnedPanelText = BtcOwnedPanel.GetComponent<TextMeshProUGUI>();
        HbzOwnedPanelText = HbzOwnedPanel.GetComponent<TextMeshProUGUI>();
        GoldOwnedPanelText = GoldOwnedPanel.GetComponent<TextMeshProUGUI>();
        
        BtcOwnedPanelText.text = PlayerPrefs.GetString("BtcOwnedPanel");
        HbzOwnedPanelText.text = PlayerPrefs.GetString("HbzOwnedPanel");
        GoldOwnedPanelText.text = PlayerPrefs.GetString("GoldOwnedPanel");


        #endregion

        #region Panel Change Time Assigment
        ResetTimeText = ResetTime.GetComponent<TextMeshProUGUI>();
        ResetTimeText.text = PlayerPrefs.GetString("RestartTime");
       
        #endregion

        #region Panel Change Assigmnet

        BtcBuyPanelText.text = PlayerPrefs.GetString("BtcBuyPanel");
        BtcSellPanelText.text = PlayerPrefs.GetString("BtcSellPanel");

        HbzBuyPanelText.text = PlayerPrefs.GetString("HbzBuyPanel");
        HbzSellPanelText.text = PlayerPrefs.GetString("HbzSellPanel");

        GoldBuyPanelText.text = PlayerPrefs.GetString("GoldBuyPanel");
        GoldSellPanelText.text = PlayerPrefs.GetString("GoldSellPanel");
        #endregion

        MyMoneyText = MyMoney.GetComponent<TextMeshProUGUI>();
        MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        #region Oto Times

        #region Bank Time
        if (PlayerPrefs.GetFloat("BankTime") <= 0)
        {

            if (double.Parse(PlayerPrefs.GetString("RemainingDebtA")) > 0)
            {
                double debtA = double.Parse(PlayerPrefs.GetString("RemainingDebtA")) + (double.Parse(PlayerPrefs.GetString("RemainingDebtA")) / 100) * 10;
                PlayerPrefs.SetString("RemainingDebtA", debtA.ToString("0.##"));
               
            }
            if (double.Parse(PlayerPrefs.GetString("RemainingDebtB")) > 0)
            {
                double debtB = double.Parse(PlayerPrefs.GetString("RemainingDebtB")) + (double.Parse(PlayerPrefs.GetString("RemainingDebtB")) / 100) * 20;
                PlayerPrefs.SetString("RemainingDebtB", debtB.ToString("0.##"));
               
            }




            PlayerPrefs.SetFloat("BankTime", 3600.0f);
        }
        else if (PlayerPrefs.GetFloat("BankTime") > 0)
        {


            PlayerPrefs.SetFloat("BankTime", PlayerPrefs.GetFloat("BankTime") - Time.deltaTime);
            Debug.Log("BANK TÝME");
            Debug.Log(PlayerPrefs.GetFloat("BankTime"));

        }
        #endregion

        #region Stock Panel Change


        if (float.Parse(PlayerPrefs.GetString("RestartTime")) <= 0)
        {
            
            PlayerPrefs.SetString("BtcBuyPanel", MoneyProcess(PlayerPrefs.GetString("BtcBuyPanel"),bool.Parse(PlayerPrefs.GetString("BtcBuyBool"))));
            BtcBuyPanelText.text = PlayerPrefs.GetString("BtcBuyPanel");

            PlayerPrefs.SetString("BtcSellPanel", MoneyProcess(PlayerPrefs.GetString("BtcSellPanel"),bool.Parse(PlayerPrefs.GetString("BtcSellBool"))));
            BtcSellPanelText.text = PlayerPrefs.GetString("BtcSellPanel");


            PlayerPrefs.SetString("HbzBuyPanel", MoneyProcess(PlayerPrefs.GetString("HbzBuyPanel"),bool.Parse(PlayerPrefs.GetString("HbzBuyBool"))));
            HbzBuyPanelText.text = PlayerPrefs.GetString("HbzBuyPanel");

            PlayerPrefs.SetString("HbzSellPanel", MoneyProcess(PlayerPrefs.GetString("HbzSellPanel"),bool.Parse(PlayerPrefs.GetString("HbzSellBool"))));
            HbzSellPanelText.text = PlayerPrefs.GetString("HbzSellPanel");


            PlayerPrefs.SetString("GoldBuyPanel", MoneyProcess(PlayerPrefs.GetString("GoldBuyPanel"),bool.Parse(PlayerPrefs.GetString("GoldBuyBool"))));
            GoldBuyPanelText.text = PlayerPrefs.GetString("GoldBuyPanel");

            PlayerPrefs.SetString("GoldSellPanel", MoneyProcess(PlayerPrefs.GetString("GoldSellPanel"),bool.Parse(PlayerPrefs.GetString("GoldSellBool"))));
            GoldSellPanelText.text = PlayerPrefs.GetString("GoldSellPanel");


            PlayerPrefs.SetString("BtcBuyBool", (!bool.Parse(PlayerPrefs.GetString("BtcBuyBool"))).ToString());
            PlayerPrefs.SetString("BtcSellBool", (!bool.Parse(PlayerPrefs.GetString("BtcSellBool"))).ToString());

            PlayerPrefs.SetString("HbzBuyBool", (!bool.Parse(PlayerPrefs.GetString("HbzBuyBool"))).ToString());
            PlayerPrefs.SetString("HbzSellBool", (!bool.Parse(PlayerPrefs.GetString("HbzSellBool"))).ToString());

            PlayerPrefs.SetString("GoldBuyBool", (!bool.Parse(PlayerPrefs.GetString("GoldBuyBool"))).ToString());
            PlayerPrefs.SetString("GoldSellBool", (!bool.Parse(PlayerPrefs.GetString("GoldSellBool"))).ToString());

            float RestartTime = 31;
            PlayerPrefs.SetString("RestartTime", RestartTime.ToString());
        }
        else if (float.Parse(PlayerPrefs.GetString("RestartTime")) > 0)
        {
            Debug.Log("GÝRDÝ 2");

            float RestartTime = float.Parse(PlayerPrefs.GetString("RestartTime")) - Time.deltaTime;
            PlayerPrefs.SetString("RestartTime", RestartTime.ToString());
            ResetTimeText.text = ((int)RestartTime).ToString();
            Debug.Log(PlayerPrefs.GetString("RestartTime"));
            
        }

        #endregion

        #endregion
    }

    #region Money Oto Change
    private string MoneyProcess(string x,bool y) 
    {
        float StockMoney = float.Parse(x);
        float Border = 1.0f;
        float Money = Random.RandomRange(1.0f,3.0f);
        

        if (y == true)
        {

                
                return (StockMoney + Money).ToString();
        }
        else
        {
            if (StockMoney - Money <= 0)
            {
                return Border.ToString();
            }
            else 
            {
                return (StockMoney - Money).ToString();
            }
            
        }

        
        
    }
    #endregion

    #region Scene Transition

    public void GoMain() 
    {
        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    }

    #endregion

    #region Button Buy-Sell

    #region BTC
    public void BuyBtc() 
    {
        Debug.Log("Buy BTC");
        BtcPerPanelText = BtcPerPanel.GetComponent<TMP_InputField>();

        PlayerPrefs.SetString("StockChange", BtcPerPanelText.text);
        
        
        double per = double.Parse(PlayerPrefs.GetString("StockChange"));
        double buy = double.Parse(PlayerPrefs.GetString("BtcBuyPanel"));
        double MMoney = double.Parse(PlayerPrefs.GetString("MyMoney"));
        if (per * buy <= MMoney)
        {
            Debug.Log("buy BTC ONAYLANDI");
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - (double.Parse(BtcPerPanelText.text) * double.Parse(PlayerPrefs.GetString("BtcBuyPanel")));
            PlayerPrefs.SetString("MyMoney", money.ToString());

            double owned = double.Parse(PlayerPrefs.GetString("BtcOwnedPanel")) + double.Parse(BtcPerPanelText.text);
            PlayerPrefs.SetString("BtcOwnedPanel", owned.ToString());

            BtcOwnedPanelText.text = PlayerPrefs.GetString("BtcOwnedPanel");
            BtcPerPanelText.text = "0";
            MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));
        }
        else 
        {
            WarningMenu.SetActive(true);
        }
        
       
    }
    public void SellBtc()
    {
        BtcPerPanelText = BtcPerPanel.GetComponent<TMP_InputField>();

        if (double.Parse(PlayerPrefs.GetString("BtcOwnedPanel"))>=double.Parse(BtcPerPanelText.text)) 
        {
            double money = double.Parse(PlayerPrefs.GetString("BtcSellPanel")) * (double.Parse(BtcPerPanelText.text));

            double allMoney = double.Parse(PlayerPrefs.GetString("MyMoney")) + money;
            PlayerPrefs.SetString("MyMoney", allMoney.ToString());

            double owned = double.Parse(PlayerPrefs.GetString("BtcOwnedPanel")) - double.Parse(BtcPerPanelText.text);
            PlayerPrefs.SetString("BtcOwnedPanel", owned.ToString());

            BtcOwnedPanelText.text = PlayerPrefs.GetString("BtcOwnedPanel");
            BtcPerPanelText.text = "0";
            MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));
        }

    }
    #endregion

    #region HBZ
    public void BuyHbz()
    {
        Debug.Log("Buy HBZ");
        HbzPerPanelText = HbzPerPanel.GetComponent<TMP_InputField>();
        PlayerPrefs.SetString("StockChange", HbzPerPanelText.text);


        double per = double.Parse(PlayerPrefs.GetString("StockChange"));
        double buy = double.Parse(PlayerPrefs.GetString("HbzBuyPanel"));
        double MMoney = double.Parse(PlayerPrefs.GetString("MyMoney"));
        if (per * buy <= MMoney)
        {
            Debug.Log("buy HBZ ONAYLANDI");
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - (double.Parse(HbzPerPanelText.text) * double.Parse(PlayerPrefs.GetString("HbzBuyPanel")));
            PlayerPrefs.SetString("MyMoney", money.ToString());

            double owned = double.Parse(PlayerPrefs.GetString("HbzOwnedPanel")) + double.Parse(HbzPerPanelText.text);
            PlayerPrefs.SetString("HbzOwnedPanel", owned.ToString());

            HbzOwnedPanelText.text = PlayerPrefs.GetString("HbzOwnedPanel");
            HbzPerPanelText.text = "0";
            MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));
        }
        else
        {
            WarningMenu.SetActive(true);
        }
    }
    public void SellHbz()
    {
        HbzPerPanelText = HbzPerPanel.GetComponent<TMP_InputField>();
        if (double.Parse(PlayerPrefs.GetString("BtcOwnedPanel")) >= double.Parse(BtcPerPanelText.text))
        {
            double money = double.Parse(PlayerPrefs.GetString("HbzSellPanel")) * (double.Parse(HbzPerPanelText.text));

            double allMoney = double.Parse(PlayerPrefs.GetString("MyMoney")) + money;
            PlayerPrefs.SetString("MyMoney", allMoney.ToString());

            double owned = double.Parse(PlayerPrefs.GetString("HbzOwnedPanel")) - double.Parse(HbzPerPanelText.text);
            PlayerPrefs.SetString("HbzOwnedPanel", owned.ToString());

            HbzOwnedPanelText.text = PlayerPrefs.GetString("HbzOwnedPanel");
            HbzPerPanelText.text = "0";
            MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));
        }
    }
    #endregion

    #region GOLD
    public void BuyGold()
    {
        Debug.Log("Buy Gold");
        GoldPerPanelText = GoldPerPanel.GetComponent<TMP_InputField>();
        PlayerPrefs.SetString("StockChange", GoldPerPanelText.text);


        double per = double.Parse(PlayerPrefs.GetString("StockChange"));
        double buy = double.Parse(PlayerPrefs.GetString("GoldBuyPanel"));
        double MMoney = double.Parse(PlayerPrefs.GetString("MyMoney"));
        if (per * buy <= MMoney)
        {
            Debug.Log("buy GOLD ONAYLANDI");
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - (double.Parse(GoldPerPanelText.text) * double.Parse(PlayerPrefs.GetString("GoldBuyPanel")));
            PlayerPrefs.SetString("MyMoney", money.ToString());

            double owned = double.Parse(PlayerPrefs.GetString("GoldOwnedPanel")) + double.Parse(GoldPerPanelText.text);
            PlayerPrefs.SetString("GoldOwnedPanel", owned.ToString());

            GoldOwnedPanelText.text = PlayerPrefs.GetString("GoldOwnedPanel");
            GoldPerPanelText.text = "0";
            MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));
        }
        else
        {
            WarningMenu.SetActive(true);
        }
    }
    public void SellGold()
    {
        GoldPerPanelText = GoldPerPanel.GetComponent<TMP_InputField>();

        if (double.Parse(PlayerPrefs.GetString("GoldOwnedPanel")) >= double.Parse(GoldPerPanelText.text))
        {
            double money = double.Parse(PlayerPrefs.GetString("GoldSellPanel")) * (double.Parse(GoldPerPanelText.text));

            double allMoney = double.Parse(PlayerPrefs.GetString("MyMoney")) + money;
            PlayerPrefs.SetString("MyMoney", allMoney.ToString());

            double owned = double.Parse(PlayerPrefs.GetString("GoldOwnedPanel")) - double.Parse(GoldPerPanelText.text);
            PlayerPrefs.SetString("GoldOwnedPanel", owned.ToString());

            GoldOwnedPanelText.text = PlayerPrefs.GetString("GoldOwnedPanel");
            GoldPerPanelText.text = "0";
            MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));
        }
        
    }
    #endregion

    #endregion

    #region Money Setup
    private string MoneyValue(string Smoney)
    {
        string value = null;
        double money;
        money = double.Parse(Smoney);
        if (money < 1000)
        {
            value = money.ToString("0.##");
        }
        else if (money > 999 && money < 10000)
        {
            money = money / 1000;
            value = money.ToString("0.##") + "K";
        }
        else if (money > 9999 && money < 100000)
        {
            money = money / 1000;
            value = money.ToString("0.##") + "K";
        }
        else if (money > 99999 && money < 1000000)
        {
            money = money / 1000;
            value = money.ToString("0.##") + "K";
        }
        else if (money > 999999 && money < 10000000)
        {
            money = money / 1000000;
            value = money.ToString("0.##") + "M";
        }
        else if (money > 9999999 && money < 100000000)
        {
            money = money / 1000000;
            value = money.ToString("0.##") + "M";
        }
        else if (money > 99999999 && money < 1000000000)
        {
            money = money / 1000000;
            value = money.ToString("0.##") + "M";
        }
        else if (money > 999999999 && money < 1000000000)
        {
            money = money / 1000000;
            value = money.ToString("0.##") + "M";
        }
        else if (money > 999999999 && money < 10000000000)
        {

            money = money / 1000000000;
            value = money.ToString("0.##") + "B";
        }
        return value;
    }
    #endregion

    #region Warning
    public void exitWarning() 
    {
        WarningMenu.SetActive(false);
    }
    #endregion
}
