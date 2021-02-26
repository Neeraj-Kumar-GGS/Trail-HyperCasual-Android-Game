using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlocksScene : MonoBehaviour
{
    public GameObject[] everything;
    public float upwardSpeed;

    
    int direction = 1;

    public GameObject trailTickButton;
    public GameObject blockTickButton;

    public GameObject blockArrowL;
    public GameObject blockArrowR;

    public GameObject trailArrowL;
    public GameObject trailArrowR;

    int trailIndex;
    int blockIndex;

    public GameObject[] blocks;
    public GameObject[] trails;

    public AudioSource buttonTick;
    public AudioSource buttonPop;
    public AudioSource buyingItem;
    

    public Text coinScore;
    public Text priceOfBlockText;
    public Text priceOfTrailText;

    public int[] priceOfBlocks_List;
    public int[] priceOfTrail_List;
    public GameObject blockBuyButton;
    public GameObject trailBuyButton;


    public bool[] blocksIsPurchased;
    public bool[] trailIsPurchased;

    public GameObject coinShopPanel;
    private void Start()
    {

        //blocksIsPurchased[0] = IntToBool(PlayerPrefs.GetInt("Block_0_IsPurchased"));
        blocksIsPurchased[1] = IntToBool(PlayerPrefs.GetInt("Block_1_IsPurchased"));
        blocksIsPurchased[2] = IntToBool(PlayerPrefs.GetInt("Block_2_IsPurchased"));
        blocksIsPurchased[3] = IntToBool(PlayerPrefs.GetInt("Block_3_IsPurchased"));
        blocksIsPurchased[4] = IntToBool(PlayerPrefs.GetInt("Block_1_IsPurchased"));
        blocksIsPurchased[5] = IntToBool(PlayerPrefs.GetInt("Block_2_IsPurchased"));
        blocksIsPurchased[6] = IntToBool(PlayerPrefs.GetInt("Block_3_IsPurchased"));
        blocksIsPurchased[7] = IntToBool(PlayerPrefs.GetInt("Block_1_IsPurchased"));
        blocksIsPurchased[8] = IntToBool(PlayerPrefs.GetInt("Block_2_IsPurchased"));
        blocksIsPurchased[9] = IntToBool(PlayerPrefs.GetInt("Block_3_IsPurchased"));
        blocksIsPurchased[10] = IntToBool(PlayerPrefs.GetInt("Block_1_IsPurchased"));
        blocksIsPurchased[11] = IntToBool(PlayerPrefs.GetInt("Block_2_IsPurchased"));
        blocksIsPurchased[12] = IntToBool(PlayerPrefs.GetInt("Block_3_IsPurchased"));
        blocksIsPurchased[13] = IntToBool(PlayerPrefs.GetInt("Block_1_IsPurchased"));
        blocksIsPurchased[14] = IntToBool(PlayerPrefs.GetInt("Block_2_IsPurchased"));
        blocksIsPurchased[15] = IntToBool(PlayerPrefs.GetInt("Block_3_IsPurchased"));
        blocksIsPurchased[16] = IntToBool(PlayerPrefs.GetInt("Block_1_IsPurchased"));
        blocksIsPurchased[17] = IntToBool(PlayerPrefs.GetInt("Block_2_IsPurchased"));
        blocksIsPurchased[18] = IntToBool(PlayerPrefs.GetInt("Block_3_IsPurchased"));

        //trailIsPurchased[0] = IntToBool(PlayerPrefs.GetInt("Trail_0_IsPurchased"));
        trailIsPurchased[1] = IntToBool(PlayerPrefs.GetInt("Trail_1_IsPurchased"));
        trailIsPurchased[2] = IntToBool(PlayerPrefs.GetInt("Trail_2_IsPurchased"));
        trailIsPurchased[3] = IntToBool(PlayerPrefs.GetInt("Trail_3_IsPurchased"));
        trailIsPurchased[4] = IntToBool(PlayerPrefs.GetInt("Trail_4_IsPurchased"));
        trailIsPurchased[5] = IntToBool(PlayerPrefs.GetInt("Trail_5_IsPurchased"));
        trailIsPurchased[6] = IntToBool(PlayerPrefs.GetInt("Trail_6_IsPurchased"));
        trailIsPurchased[7] = IntToBool(PlayerPrefs.GetInt("Trail_7_IsPurchased"));
        trailIsPurchased[8] = IntToBool(PlayerPrefs.GetInt("Trail_8_IsPurchased"));
        trailIsPurchased[9] = IntToBool(PlayerPrefs.GetInt("Trail_9_IsPurchased"));
        trailIsPurchased[10] = IntToBool(PlayerPrefs.GetInt("Trail_10_IsPurchased"));
        trailIsPurchased[11] = IntToBool(PlayerPrefs.GetInt("Trail_11_IsPurchased"));





        //on load of level previous chosed will be shown
        blockIndex = PlayerPrefs.GetInt("BlockIndex", 0);
        trailIndex = PlayerPrefs.GetInt("TrailIndex", 0);
    }
    void Update()
    {
        coinScore.text = PlayerPrefs.GetInt("CoinScore", 0).ToString();
        ///////////////////////////////////////////////////////////////////             trail movement
        for (int i = 0; i < trails.Length; i++)
        {

            if (trails[i].transform.position.x > 8f)
            {
                direction = -1;
            }
            if (trails[i].transform.position.x < -8f)
            {
                direction = 1;
            }
            trails[i].transform.Translate(1.6f * direction, 0, 0);
        }
        for (int i = 0; i < everything.Length; i++)
        {
            everything[i].transform.Translate(0, upwardSpeed * Time.deltaTime, 0);
        }
        //////////////////////////////////////////////////////////////////////////////////////////      trail Index setActive

        for (int i = 0; i < trails.Length; i++)
        {
            if (i == trailIndex)
            {
                trails[i].SetActive(true);
                priceOfTrailText.text = priceOfTrail_List[i].ToString();
            }
            else
            { 
                trails[i].SetActive(false);
            
            }

            if (trailIndex == PlayerPrefs.GetInt("TrailIndex", 0))
            {
                trailTickButton.GetComponent<Image>().enabled = true;

            }

        }


        if (trailIndex >= trails.Length - 1)
        {
            trailArrowR.SetActive(false);
        }
        else trailArrowR.SetActive(true);

        if (trailIndex <= 0)
        {
            trailArrowL.SetActive(false);
        }
        else trailArrowL.SetActive(true);
        /////////////////////////////////////////////////////////////         blocks Index setActive
        for (int i = 0; i < blocks.Length; i++)
        {
            if (i == blockIndex)
            {
                blocks[i].SetActive(true);
                priceOfBlockText.text = priceOfBlocks_List[i].ToString();

            }
            else blocks[i].SetActive(false);

            if (blockIndex == PlayerPrefs.GetInt("BlockIndex", 0))
            {
                blockTickButton.GetComponent<Image>().enabled = true;

            }

        }
        if (blockIndex >= blocks.Length - 1)
        {
            blockArrowR.SetActive(false);
        }
        else blockArrowR.SetActive(true);

        if (blockIndex <= 0)
        {
            blockArrowL.SetActive(false);
        }
        else blockArrowL.SetActive(true);
        ////////////////////////////////////////////////////////////////////////      
        ///////////////////////////////////////////////////////////////////////                 Purchasing 


        //setting playerprefes which block is purchased (permanently)
        {
            PlayerPrefs.SetInt("Block_0_IsPurchased", BoolToInt(blocksIsPurchased[0]));
            PlayerPrefs.SetInt("Block_1_IsPurchased", BoolToInt(blocksIsPurchased[1]));
            PlayerPrefs.SetInt("Block_2_IsPurchased", BoolToInt(blocksIsPurchased[2]));
            PlayerPrefs.SetInt("Block_3_IsPurchased", BoolToInt(blocksIsPurchased[3]));
            PlayerPrefs.SetInt("Block_4_IsPurchased", BoolToInt(blocksIsPurchased[4]));
            PlayerPrefs.SetInt("Block_5_IsPurchased", BoolToInt(blocksIsPurchased[5]));
            PlayerPrefs.SetInt("Block_6_IsPurchased", BoolToInt(blocksIsPurchased[6]));
            PlayerPrefs.SetInt("Block_7_IsPurchased", BoolToInt(blocksIsPurchased[7]));
            PlayerPrefs.SetInt("Block_8_IsPurchased", BoolToInt(blocksIsPurchased[8]));
            PlayerPrefs.SetInt("Block_9_IsPurchased", BoolToInt(blocksIsPurchased[9]));
            PlayerPrefs.SetInt("Block_10_IsPurchased", BoolToInt(blocksIsPurchased[10]));
            PlayerPrefs.SetInt("Block_11_IsPurchased", BoolToInt(blocksIsPurchased[11]));
            PlayerPrefs.SetInt("Block_12_IsPurchased", BoolToInt(blocksIsPurchased[12]));
            PlayerPrefs.SetInt("Block_13_IsPurchased", BoolToInt(blocksIsPurchased[13]));
            PlayerPrefs.SetInt("Block_14_IsPurchased", BoolToInt(blocksIsPurchased[14]));
            PlayerPrefs.SetInt("Block_15_IsPurchased", BoolToInt(blocksIsPurchased[15]));
            PlayerPrefs.SetInt("Block_16_IsPurchased", BoolToInt(blocksIsPurchased[16]));
            PlayerPrefs.SetInt("Block_17_IsPurchased", BoolToInt(blocksIsPurchased[17]));
            PlayerPrefs.SetInt("Block_18_IsPurchased", BoolToInt(blocksIsPurchased[18]));
        }
        // setting playerprefs which trail is purchased (premanently)
        { 
            PlayerPrefs.SetInt("Trail_0_IsPurchased", BoolToInt(trailIsPurchased[0]));
            PlayerPrefs.SetInt("Trail_1_IsPurchased", BoolToInt(trailIsPurchased[1]));
            PlayerPrefs.SetInt("Trail_2_IsPurchased", BoolToInt(trailIsPurchased[2]));
            PlayerPrefs.SetInt("Trail_3_IsPurchased", BoolToInt(trailIsPurchased[3]));
            PlayerPrefs.SetInt("Trail_4_IsPurchased", BoolToInt(trailIsPurchased[4]));
            PlayerPrefs.SetInt("Trail_5_IsPurchased", BoolToInt(trailIsPurchased[5]));
            PlayerPrefs.SetInt("Trail_6_IsPurchased", BoolToInt(trailIsPurchased[6]));
            PlayerPrefs.SetInt("Trail_7_IsPurchased", BoolToInt(trailIsPurchased[7]));
            PlayerPrefs.SetInt("Trail_8_IsPurchased", BoolToInt(trailIsPurchased[8]));
            PlayerPrefs.SetInt("Trail_9_IsPurchased", BoolToInt(trailIsPurchased[9]));
            PlayerPrefs.SetInt("Trail_10_IsPurchased", BoolToInt(trailIsPurchased[10]));
            PlayerPrefs.SetInt("Trail_11_IsPurchased", BoolToInt(trailIsPurchased[11]));
        }






        for (int i = 0; i < blocks.Length; i++)
        {
            if (i == blockIndex)
            {
                if (blocksIsPurchased[blockIndex])
                {
                    blockBuyButton.SetActive(false);          //dissapearing buy button foreever if item is purchased       for BLOCK 
                }
                else
                {
                    blockBuyButton.SetActive(true);
                }
                    
            }
        }



        for (int i = 0; i < trails.Length; i++)
        {
            if (i == trailIndex)
            { 
                if (trailIsPurchased[trailIndex])
                {
                    trailBuyButton.SetActive(false);          //dissapearing buy button foreever if item is purchased       for TRAIL
                }
                else
                {
                    trailBuyButton.SetActive(true);
                }


            }

        }






       // Commenting it because now it will open coin shop if coin is less
        
        
        
        /*
        //disabling  buttton if coin is less        for BLOCK
        if (PlayerPrefs.GetInt("CoinScore", 0) < priceOfBlocks_List[blockIndex])
        {
            blockBuyButton.GetComponent<Button>().interactable = false;
        }
        else blockBuyButton.GetComponent<Button>().interactable = true;


        //disabling  buttton if coin is less        for TRAIL
        if (PlayerPrefs.GetInt("CoinScore", 0) < priceOfTrail_List[trailIndex])
        {
            trailBuyButton.GetComponent<Button>().interactable = false;
        }
        else trailBuyButton.GetComponent<Button>().interactable = true;
        */

      
    }

    int BoolToInt(bool i)
    {
        if (i)
            return 1;
        else
            return 0;
    
    }
    bool IntToBool(int i)
    {
        if (i == 0)
            return false;
        else
            return true;
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
        buttonTick.Play();

    }
    public void BlockLeftButton()
    {
        blockIndex--;
        blockTickButton.GetComponent<Image>().enabled = false;
        buttonTick.Play();


    }
    public void BlockRightButton()
    {
        blockIndex++;
        blockTickButton.GetComponent<Image>().enabled = false;
        buttonTick.Play();

    }
    public void TrailLeftButton()
    {
        trailIndex--;
        trailTickButton.GetComponent<Image>().enabled = false;
        buttonTick.Play();

    }
    public void TrailRightButton()
    {
        trailIndex++;
        trailTickButton.GetComponent<Image>().enabled = false;
        buttonTick.Play();


    }
    public void BlockTickButton()
    {
        if (blockTickButton.GetComponent<Image>().enabled == true)
        {
            blockTickButton.GetComponent<Image>().enabled = false;
        }
        else
            blockTickButton.GetComponent<Image>().enabled = true;

        PlayerPrefs.SetInt("BlockIndex", blockIndex);
        buttonPop.Play();
    }
    public void TrailTickButton()
    {


        if (trailTickButton.GetComponent<Image>().enabled == true)
        {
            trailTickButton.GetComponent<Image>().enabled = false;
        }
        else
            trailTickButton.GetComponent<Image>().enabled = true;

        PlayerPrefs.SetInt("TrailIndex", trailIndex);
        buttonPop.Play();
    }
    public void BlockBuy()
    {
        if (PlayerPrefs.GetInt("CoinScore", 0) < priceOfBlocks_List[blockIndex])
        {
            coinShopPanel.SetActive(true);
            buttonTick.Play();

        }
        else 
        { 
        
                PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore", 0) -  priceOfBlocks_List[blockIndex]);
            blocksIsPurchased[blockIndex] = true;
            blockBuyButton.SetActive(false);
            buyingItem.Play();
        }
        
        
        
    }
    public void TrailBuy()
    {

        if (PlayerPrefs.GetInt("CoinScore", 0) < priceOfTrail_List[trailIndex])
        {
            coinShopPanel.SetActive(true);
            buttonTick.Play();

        }
        else
        { 
        
            PlayerPrefs.SetInt("CoinScore", PlayerPrefs.GetInt("CoinScore", 0) - priceOfTrail_List[trailIndex]);
            trailIsPurchased[trailIndex] = true;
            trailBuyButton.SetActive(false);
            buyingItem.Play();
        
        }
    }
    
}
