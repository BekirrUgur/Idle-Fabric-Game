using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BankScene : MonoBehaviour
{
    

    #region Plan A Variables

    public GameObject LoanSizeA;
    private TextMeshProUGUI LoanSizeAText;
    public GameObject BankMoneyA;
    private TMP_InputField BankMoneyTextA;
    public GameObject RemainingDebutA;
    private TextMeshProUGUI RemainingDebutTextA;
    public GameObject CreditLimitA;
    private TextMeshProUGUI CreditLimitTextA;
    private double LimitA;

    #endregion

    #region Plan B Variables

    public GameObject LoanSizeB;
    private TextMeshProUGUI LoanSizeBText;
    public GameObject BankMoneyB;
    private TMP_InputField BankMoneyTextB;
    public GameObject RemainingDebutB;
    private TextMeshProUGUI RemainingDebutTextB;
    public GameObject CreditLimitB;
    private TextMeshProUGUI CreditLimitTextB;
    private double LimitB;

    #endregion

    void Start()
    {

       

        #region Plan A

        LoanSizeAText = LoanSizeA.GetComponent<TextMeshProUGUI>();
        LimitA = ((double.Parse(PlayerPrefs.GetString("PropertyValue")) / 100) * 5);
        LoanSizeAText.text = MoneyValue(LimitA.ToString("0.##"));

        BankMoneyTextA = BankMoneyA.GetComponent<TMP_InputField>();
        
        RemainingDebutTextA = RemainingDebutA.GetComponent<TextMeshProUGUI>();
        RemainingDebutTextA.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtA"));

        CreditLimitTextA = CreditLimitA.GetComponent<TextMeshProUGUI>();
        CreditLimitTextA.text = MoneyValue(PlayerPrefs.GetString("CreditLimitA"));


        #endregion

        #region Plan B

        LoanSizeBText = LoanSizeB.GetComponent<TextMeshProUGUI>();
        LimitB = ((double.Parse(PlayerPrefs.GetString("PropertyValue")) / 100) * 10);
        LoanSizeBText.text = MoneyValue(LimitB.ToString("0.##"));
        
        BankMoneyTextB = BankMoneyB.GetComponent<TMP_InputField>();

        RemainingDebutTextB = RemainingDebutB.GetComponent<TextMeshProUGUI>();
        RemainingDebutTextB.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtB"));

        CreditLimitTextB = CreditLimitB.GetComponent<TextMeshProUGUI>();
        CreditLimitTextB.text = MoneyValue(PlayerPrefs.GetString("CreditLimitB"));

        #endregion


    }


    void FixedUpdate()
    {
        #region Oto Times

        #region Bank Time
        if (PlayerPrefs.GetFloat("BankTime") <= 0)
        {

            if (double.Parse(PlayerPrefs.GetString("RemainingDebtA")) > 0) 
            {
                double debtA = double.Parse(PlayerPrefs.GetString("RemainingDebtA")) + (double.Parse(PlayerPrefs.GetString("RemainingDebtA"))/100) * 10;
                PlayerPrefs.SetString("RemainingDebtA",debtA.ToString("0.##"));
                RemainingDebutTextA.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtA"));
            }
            if (double.Parse(PlayerPrefs.GetString("RemainingDebtB")) > 0)
            {
                double debtB = double.Parse(PlayerPrefs.GetString("RemainingDebtB")) + (double.Parse(PlayerPrefs.GetString("RemainingDebtB")) / 100) * 20;
                PlayerPrefs.SetString("RemainingDebtB", debtB.ToString("0.##"));
                RemainingDebutTextB.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtB"));
            }




            PlayerPrefs.SetFloat("BankTime",3600.0f);
        }
        else if (PlayerPrefs.GetFloat("BankTime") > 0)
        {
           

            PlayerPrefs.SetFloat("BankTime", PlayerPrefs.GetFloat("BankTime") - Time.deltaTime);
            Debug.Log("BANK TÝME");
            Debug.Log(PlayerPrefs.GetFloat("BankTime"));

        }
        #endregion

        #region Stock Market Time
        if (float.Parse(PlayerPrefs.GetString("RestartTime")) <= 0)
        {


            PlayerPrefs.SetString("BtcBuyPanel", MoneyProcess(PlayerPrefs.GetString("BtcBuyPanel"), bool.Parse(PlayerPrefs.GetString("BtcBuyBool"))));
            PlayerPrefs.SetString("BtcSellPanel", MoneyProcess(PlayerPrefs.GetString("BtcSellPanel"), bool.Parse(PlayerPrefs.GetString("BtcSellBool"))));

            PlayerPrefs.SetString("HbzBuyPanel", MoneyProcess(PlayerPrefs.GetString("HbzBuyPanel"), bool.Parse(PlayerPrefs.GetString("HbzBuyBool"))));
            PlayerPrefs.SetString("HbzSellPanel", MoneyProcess(PlayerPrefs.GetString("HbzSellPanel"), bool.Parse(PlayerPrefs.GetString("HbzSellBool"))));

            PlayerPrefs.SetString("GoldBuyPanel", MoneyProcess(PlayerPrefs.GetString("GoldBuyPanel"), bool.Parse(PlayerPrefs.GetString("GoldBuyBool"))));
            PlayerPrefs.SetString("GoldSellPanel", MoneyProcess(PlayerPrefs.GetString("GoldSellPanel"), bool.Parse(PlayerPrefs.GetString("GoldSellBool"))));



            float RestartTime = 31;
            PlayerPrefs.SetString("RestartTime", RestartTime.ToString());
        }
        else if (float.Parse(PlayerPrefs.GetString("RestartTime")) > 0)
        {
            Debug.Log("GÝRDÝ 2");

            float RestartTime = float.Parse(PlayerPrefs.GetString("RestartTime")) - Time.deltaTime;
            PlayerPrefs.SetString("RestartTime", RestartTime.ToString());
            Debug.Log(PlayerPrefs.GetString("RestartTime"));

        }
        #endregion

     #endregion
    }

    #region Stock Market Money Oto Change
    private string MoneyProcess(string x, bool y)
    {
        float StockMoney = float.Parse(x);
        float Border = 1.0f;
        float Money = Random.RandomRange(1.0f, 3.0f);


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

    #region Credit-Pay Button

    #region PLan A Buttons

    public void CreditButtonA() 
    {
        if (double.Parse(BankMoneyTextA.text) <= double.Parse(PlayerPrefs.GetString("CreditLimitA")) &&
            double.Parse(PlayerPrefs.GetString("CreditLimitA")) > 0 && 
            double.Parse(BankMoneyTextA.text) > 0) 
        {
            double Money = double.Parse(PlayerPrefs.GetString("MyMoney"))+double.Parse(BankMoneyTextA.text);
            PlayerPrefs.SetString("MyMoney",Money.ToString());

            double CreditLimit = double.Parse(PlayerPrefs.GetString("CreditLimitA")) - double.Parse(BankMoneyTextA.text);
            PlayerPrefs.SetString("CreditLimitA", CreditLimit.ToString());

            CreditLimitTextA.text = MoneyValue(PlayerPrefs.GetString("CreditLimitA"));
            

            
            double remainingDebt = (double.Parse(PlayerPrefs.GetString("RemainingDebtA"))) + (double.Parse(BankMoneyTextA.text) + ((double.Parse(BankMoneyTextA.text) / 100) * 10));
            PlayerPrefs.SetString("RemainingDebtA", remainingDebt.ToString());
            RemainingDebutTextA.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtA"));
            BankMoneyTextA.text = "0";

        }
    }

    public void PayButtonA() 
    {

        if (double.Parse(BankMoneyTextA.text) <= double.Parse(PlayerPrefs.GetString("RemainingDebtA")) &&
            double.Parse(BankMoneyTextA.text) > 0 &&
            double.Parse(PlayerPrefs.GetString("MyMoney")) >= double.Parse(BankMoneyTextA.text))
        {
            double Money = double.Parse(PlayerPrefs.GetString("MyMoney")) - double.Parse(BankMoneyTextA.text);
            PlayerPrefs.SetString("MyMoney", Money.ToString());

            double CreditLimit = double.Parse(PlayerPrefs.GetString("CreditLimitA")) + double.Parse(BankMoneyTextA.text);
            PlayerPrefs.SetString("CreditLimitA", CreditLimit.ToString());

            if (double.Parse(PlayerPrefs.GetString("CreditLimitA")) >= double.Parse(PlayerPrefs.GetString("CreditA")))
            {
                PlayerPrefs.SetString("CreditLimitA", PlayerPrefs.GetString("CreditA"));
                CreditLimitTextA.text = MoneyValue(PlayerPrefs.GetString("CreditLimitA"));
            }
            else 
            {
                
                CreditLimitTextA.text = MoneyValue(PlayerPrefs.GetString("CreditLimitA"));


            }
           



            double remainingDebt = (double.Parse(PlayerPrefs.GetString("RemainingDebtA"))) - double.Parse(BankMoneyTextA.text);
            PlayerPrefs.SetString("RemainingDebtA", remainingDebt.ToString());
            RemainingDebutTextA.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtA"));
            BankMoneyTextA.text = "0";

        }

    }
    #endregion

    #region Plan B Buttons

    public void CreditButtonB()
    {

        if (double.Parse(BankMoneyTextB.text) <= double.Parse(PlayerPrefs.GetString("CreditLimitB")) &&
            double.Parse(PlayerPrefs.GetString("CreditLimitB")) > 0 &&
            double.Parse(BankMoneyTextB.text) > 0)
        {
            double Money = double.Parse(PlayerPrefs.GetString("MyMoney")) + double.Parse(BankMoneyTextB.text);
            PlayerPrefs.SetString("MyMoney", Money.ToString());

            double CreditLimit = double.Parse(PlayerPrefs.GetString("CreditLimitB")) - double.Parse(BankMoneyTextB.text);
            PlayerPrefs.SetString("CreditLimitB", CreditLimit.ToString());

            CreditLimitTextB.text = CreditLimitTextB.text = MoneyValue(PlayerPrefs.GetString("CreditLimitB"));



            double remainingDebt = (double.Parse(PlayerPrefs.GetString("RemainingDebtB"))) + (double.Parse(BankMoneyTextB.text) + ((double.Parse(BankMoneyTextB.text) / 100) * 10));
            PlayerPrefs.SetString("RemainingDebtB", remainingDebt.ToString());
            RemainingDebutTextB.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtB"));
            BankMoneyTextB.text = "0";

        }

    }

    public void PayButtonB()
    {

        if (double.Parse(BankMoneyTextB.text) <= double.Parse(PlayerPrefs.GetString("RemainingDebtB")) &&
            double.Parse(BankMoneyTextB.text) > 0 &&
            double.Parse(PlayerPrefs.GetString("MyMoney")) >= double.Parse(BankMoneyTextB.text))
        {
            double Money = double.Parse(PlayerPrefs.GetString("MyMoney")) - double.Parse(BankMoneyTextB.text);
            PlayerPrefs.SetString("MyMoney", Money.ToString());

            double CreditLimit = double.Parse(PlayerPrefs.GetString("CreditLimitB")) + double.Parse(BankMoneyTextB.text);
            PlayerPrefs.SetString("CreditLimitB", CreditLimit.ToString());

            if (double.Parse(PlayerPrefs.GetString("CreditLimitB")) >= double.Parse(PlayerPrefs.GetString("CreditB")))
            {
                PlayerPrefs.SetString("CreditLimitB", PlayerPrefs.GetString("CreditB"));
                CreditLimitTextB.text = CreditLimitTextB.text = MoneyValue(PlayerPrefs.GetString("CreditLimitB"));
            }
            else
            {

                CreditLimitTextB.text = MoneyValue(PlayerPrefs.GetString("CreditLimitB"));


            }




            double remainingDebt = (double.Parse(PlayerPrefs.GetString("RemainingDebtB"))) - double.Parse(BankMoneyTextB.text);
            PlayerPrefs.SetString("RemainingDebtB", remainingDebt.ToString());
            RemainingDebutTextB.text = MoneyValue(PlayerPrefs.GetString("RemainingDebtB"));
            BankMoneyTextB.text = "0";

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

    public void GoBack()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
