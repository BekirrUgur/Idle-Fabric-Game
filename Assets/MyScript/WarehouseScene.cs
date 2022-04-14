using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WarehouseScene : MonoBehaviour
{

    public GameObject Warning;

    public GameObject Small;
    private TextMeshProUGUI SmallText;

    public GameObject Medium;
    private TextMeshProUGUI MediumText;

    public GameObject Large;
    private TextMeshProUGUI LargeText;

    public GameObject Mega;
    private TextMeshProUGUI MegaText;

    void Start()
    {

        SmallText = Small.GetComponent<TextMeshProUGUI>();
        SmallText.text = PlayerPrefs.GetString("SmallWarehouse");

        MediumText = Medium.GetComponent<TextMeshProUGUI>();
        MediumText.text = PlayerPrefs.GetString("MediumWarehouse");


        LargeText = Large.GetComponent<TextMeshProUGUI>();
        LargeText.text = PlayerPrefs.GetString("LargeWarehouse");


        MegaText = Mega.GetComponent<TextMeshProUGUI>();
        MegaText.text = PlayerPrefs.GetString("MegaWarehouse");

    }

    private void FixedUpdate()
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

            float RestartTime = float.Parse(PlayerPrefs.GetString("RestartTime")) -  Time.deltaTime;
            PlayerPrefs.SetString("RestartTime", RestartTime.ToString());
            Debug.Log(PlayerPrefs.GetString("RestartTime"));

        }
        #endregion

        #endregion
    }

    public void goBack() 
    {

        SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
    
    }
    public void WarningExit() 
    {

        Warning.SetActive(false);

    }

    #region Buy-Sell Buttons

    #region Small
    public void SmallBuy() 
    {
        if (double.Parse(PlayerPrefs.GetString("MyMoney")) >= 10000)
        {
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - 10000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int small = int.Parse(PlayerPrefs.GetString("SmallWarehouse")) + 1;
            PlayerPrefs.SetString("SmallWarehouse", small.ToString());

            SmallText.text = PlayerPrefs.GetString("SmallWarehouse");

        }
        else 
        {

            Warning.SetActive(true);

        }
    }
    public void SmallSell()
    {
        if (int.Parse(PlayerPrefs.GetString("SmallWarehouse")) > 0 ) 
        {

            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) + 10000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int small = int.Parse(PlayerPrefs.GetString("SmallWarehouse")) - 1;
            PlayerPrefs.SetString("SmallWarehouse", small.ToString());

            SmallText.text = PlayerPrefs.GetString("SmallWarehouse");

        }
        


    }
    #endregion

    #region Medium

    public void MediumBuy()
    {

        if (double.Parse(PlayerPrefs.GetString("MyMoney")) >= 100000)
        {
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - 100000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int medium = int.Parse(PlayerPrefs.GetString("MediumWarehouse")) + 1;
            PlayerPrefs.SetString("MediumWarehouse", medium.ToString());

            MediumText.text = PlayerPrefs.GetString("MediumWarehouse");

        }
        else
        {

            Warning.SetActive(true);

        }

    }
    public void MediumSell()
    {
        if (int.Parse(PlayerPrefs.GetString("MediumWarehouse")) > 0) 
        {

            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) + 100000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int medium = int.Parse(PlayerPrefs.GetString("MediumWarehouse")) - 1;
            PlayerPrefs.SetString("MediumWarehouse", medium.ToString());

            MediumText.text = PlayerPrefs.GetString("MediumWarehouse");

        }
        

    }

    #endregion

    #region Large

    public void LargeBuy()
    {

        if (double.Parse(PlayerPrefs.GetString("MyMoney")) >= 1000000)
        {
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - 1000000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int large = int.Parse(PlayerPrefs.GetString("LargeWarehouse")) + 1;
            PlayerPrefs.SetString("LargeWarehouse", large.ToString());

            LargeText.text = PlayerPrefs.GetString("LargeWarehouse");

        }
        else
        {

            Warning.SetActive(true);

        }

    }
    public void LargeSell()
    {
        if (int.Parse(PlayerPrefs.GetString("LargeWarehouse")) > 0) 
        {

            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) + 1000000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int large = int.Parse(PlayerPrefs.GetString("LargeWarehouse")) - 1;
            PlayerPrefs.SetString("LargeWarehouse", large.ToString());

            LargeText.text = PlayerPrefs.GetString("LargeWarehouse");

        }
        

    }

    #endregion

    #region Mega

    public void MegaBuy()
    {

        if (double.Parse(PlayerPrefs.GetString("MyMoney")) >= 2500000)
        {
            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) - 2500000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int mega = int.Parse(PlayerPrefs.GetString("MegaWarehouse")) + 1;
            PlayerPrefs.SetString("MegaWarehouse", mega.ToString());

            MegaText.text = PlayerPrefs.GetString("MegaWarehouse");

        }
        else
        {

            Warning.SetActive(true);

        }

    }
    public void MegaSell()
    {
        if (int.Parse(PlayerPrefs.GetString("MegaWarehouse")) > 0) 
        {

            double money = double.Parse(PlayerPrefs.GetString("MyMoney")) + 2500000;
            PlayerPrefs.SetString("MyMoney", money.ToString());

            int mega = int.Parse(PlayerPrefs.GetString("MegaWarehouse")) - 1;
            PlayerPrefs.SetString("MegaWarehouse", mega.ToString());

            MegaText.text = PlayerPrefs.GetString("MegaWarehouse");

        }
        

    }

    #endregion

    #endregion

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

}
