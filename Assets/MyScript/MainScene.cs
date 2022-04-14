using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainScene : MonoBehaviour
{
   

    public GameObject CompanyName;
    private TextMeshProUGUI CompanyText;

    public GameObject MyMoney;
    private TextMeshProUGUI MyMoneyText;

    void Start()
    {

        CompanyText = CompanyName.GetComponent<TextMeshProUGUI>();
        CompanyText.text = PlayerPrefs.GetString("CompanyName");

        MyMoneyText = MyMoney.GetComponent<TextMeshProUGUI>();
        MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyMoneyText.text = MoneyValue(PlayerPrefs.GetString("MyMoney"));

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

        #region Stock Market Time
        if (float.Parse(PlayerPrefs.GetString("RestartTime")) <= 0)
        {


            PlayerPrefs.SetString("BtcBuyPanel", MoneyProcess(PlayerPrefs.GetString("BtcBuyPanel"),bool.Parse(PlayerPrefs.GetString("BtcBuyBool"))));
            PlayerPrefs.SetString("BtcSellPanel", MoneyProcess(PlayerPrefs.GetString("BtcSellPanel"),bool.Parse(PlayerPrefs.GetString("BtcSellBool"))));
           
            PlayerPrefs.SetString("HbzBuyPanel", MoneyProcess(PlayerPrefs.GetString("HbzBuyPanel"),bool.Parse(PlayerPrefs.GetString("HbzBuyBool"))));
            PlayerPrefs.SetString("HbzSellPanel", MoneyProcess(PlayerPrefs.GetString("HbzSellPanel"),bool.Parse(PlayerPrefs.GetString("HbzSellBool"))));
    
            PlayerPrefs.SetString("GoldBuyPanel", MoneyProcess(PlayerPrefs.GetString("GoldBuyPanel"),bool.Parse(PlayerPrefs.GetString("GoldBuyBool"))));
            PlayerPrefs.SetString("GoldSellPanel", MoneyProcess(PlayerPrefs.GetString("GoldSellPanel"),bool.Parse(PlayerPrefs.GetString("GoldSellBool"))));



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

    #region Money Setup
    private string MoneyValue(string Smoney) 
    {
        string value = null;
        double money;
        money = double.Parse(Smoney);
        if (money<1000) 
        {
            value = money.ToString("0.##");
        }
        else if (money > 999 && money < 10000)
        {
            money = money / 1000;
            value = money.ToString("0.##") + "K";
        } else if (money > 9999 && money < 100000)
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
        return value ;
    }
    #endregion

    #region SCENES

    public void StockMarketPage() 
    {
        SceneManager.LoadScene("StockMarketScene",LoadSceneMode.Single);
    }
    public void BankPage()
    {
        SceneManager.LoadScene("BankScene", LoadSceneMode.Single);
    }
    public void FabricPage()
    {
        SceneManager.LoadScene("FabricScene", LoadSceneMode.Single);
    }
    public void SalesDepartmantPage()
    {
        SceneManager.LoadScene("SalesDepartmantScene", LoadSceneMode.Single);
    }
    public void WarehousePage()
    {
        SceneManager.LoadScene("WarehouseScene", LoadSceneMode.Single);
    }
    public void TaxesPage()
    {
        SceneManager.LoadScene("TaxesScene", LoadSceneMode.Single);
    }
    public void EmployeesPage()
    {
        SceneManager.LoadScene("EmployeesScene", LoadSceneMode.Single);
    }
    public void RankingPage()
    {
        SceneManager.LoadScene("RankingScene", LoadSceneMode.Single);
    }
    public void PropertyPage()
    {
        SceneManager.LoadScene("PropertyScene", LoadSceneMode.Single);
    }
    public void MenuPage()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    #endregion
}
