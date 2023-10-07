using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class UpgradeButtons : MonoBehaviour
    {
        public GameManager GlobalGameManager;
        private NetworkCommunication NetComm;

        public GameObject UIManager;
        public GameObject PlacePieces;

        public Button UpgradeButton;
        public Button CloseUpgrades;

        public Button Attack1Button;
        public Button Attack2Button;
        public Button Attack3Button;
        public Button Attack4Button;

        public Button Defense1Button;
        public Button Defense2Button;
        public Button Defense3Button;
        public Button Defense4Button;

        public Button Income1Button;
        public Button Income2Button;
        public Button Income3Button;
        public Button Income4Button;

        private int attackLevel;
        private int defenseLevel;
        private int incomeLevel;

        private int currMoney;

        private int currPlayer;

        private bool upgradeMenuOpen;

        private int upgradeCost;

        private TowerScript[] allTowers;

        private void Start()
        {
            GlobalGameManager = GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>();

            attackLevel = 0;
            defenseLevel = 0;
            incomeLevel = 0;

            currMoney = 0;

            currPlayer = 0;

            upgradeMenuOpen = false;

            upgradeCost = 100;
        }

        private void Update()
        {
            if (upgradeMenuOpen)
            {
                if (NetComm == null)
                {
                    NetComm = FindObjectOfType<NetworkCommunication>();

                    currPlayer = PhotonNetwork.LocalPlayer.ActorNumber;
                }

                if (currPlayer == 1 || currPlayer == 2)
                {
                    currMoney = GlobalGameManager.player_1_money;
                }
                else if (currPlayer == 3)
                {
                    currMoney = GlobalGameManager.player_2_money;
                }

                ActivateButtons();
            }
        }
        private void ActivateButtons()
        {
            switch(attackLevel)
            {
                case 0:
                    if (currMoney >= upgradeCost)
                    {
                        Attack1Button.interactable = true;
                    }
                    else
                    {
                        Attack1Button.interactable = false;
                    }

                    Attack2Button.interactable = false;
                    Attack3Button.interactable = false;
                    Attack4Button.interactable = false;

                    break;
                case 1:
                    if (currMoney >= upgradeCost)
                    {
                        Attack2Button.interactable = true;
                    }
                    else
                    {
                        Attack2Button.interactable = false;
                    }

                    ColorBlock c1 = Attack1Button.colors;
                    c1.disabledColor = new Color(18, 138, 100);
                    Attack1Button.colors = c1;

                    Attack1Button.interactable = false;
                    Attack3Button.interactable = false;
                    Attack4Button.interactable = false;

                    break;
                case 2:
                    if (currMoney >= upgradeCost)
                    {
                        Attack3Button.interactable = true;
                    }
                    else
                    {
                        Attack3Button.interactable = false;
                    }

                    ColorBlock c2 = Attack2Button.colors;
                    c2.disabledColor = new Color(18, 138, 100);
                    Attack2Button.colors = c2;

                    Attack1Button.interactable = false;
                    Attack2Button.interactable = false;
                    Attack4Button.interactable = false;

                    break;
                case 3:
                    if (currMoney >= upgradeCost)
                    {
                        Attack4Button.interactable = true;
                    }
                    else
                    {
                        Attack4Button.interactable = false;
                    }

                    ColorBlock c3 = Attack3Button.colors;
                    c3.disabledColor = new Color(18, 138, 100);
                    Attack3Button.colors = c3;

                    Attack1Button.interactable = false;
                    Attack2Button.interactable = false;
                    Attack3Button.interactable = false;

                    break;
                default:
                    ColorBlock c4 = Attack4Button.colors;
                    c4.disabledColor = new Color(18, 138, 100);
                    Attack4Button.colors = c4;

                    Attack1Button.interactable = false;
                    Attack2Button.interactable = false;
                    Attack3Button.interactable = false;
                    Attack4Button.interactable = false;

                    break;
            }

            switch (defenseLevel)
            {
                case 0:
                    if (currMoney >= upgradeCost)
                    {
                        Defense1Button.interactable = true;
                    }
                    else
                    {
                        Defense1Button.interactable = false;
                    }

                    Defense2Button.interactable = false;
                    Defense3Button.interactable = false;
                    Defense4Button.interactable = false;

                    break;
                case 1:
                    if (currMoney >= upgradeCost)
                    {
                        Defense2Button.interactable = true;
                    }
                    else
                    {
                        Defense2Button.interactable = false;
                    }

                    ColorBlock c1 = Defense1Button.colors;
                    c1.disabledColor = new Color(18, 138, 100);
                    Defense1Button.colors = c1;

                    Defense1Button.interactable = false;
                    Defense3Button.interactable = false;
                    Defense4Button.interactable = false;

                    break;
                case 2:
                    if (currMoney >= upgradeCost)
                    {
                        Defense3Button.interactable = true;
                    }
                    else
                    {
                        Defense3Button.interactable = false;
                    }

                    ColorBlock c2 = Defense2Button.colors;
                    c2.disabledColor = new Color(18, 138, 100);
                    Defense2Button.colors = c2;

                    Defense1Button.interactable = false;
                    Defense2Button.interactable = false;
                    Defense4Button.interactable = false;

                    break;
                case 3:
                    if (currMoney >= upgradeCost)
                    {
                        Defense4Button.interactable = true;
                    }
                    else
                    {
                        Defense4Button.interactable = false;
                    }

                    ColorBlock c3 = Defense3Button.colors;
                    c3.disabledColor = new Color(18, 138, 100);
                    Defense3Button.colors = c3;

                    Defense1Button.interactable = false;
                    Defense2Button.interactable = false;
                    Defense3Button.interactable = false;

                    break;
                default:
                    ColorBlock c4 = Defense4Button.colors;
                    c4.disabledColor = new Color(18, 138, 100);
                    Defense4Button.colors = c4;

                    Defense1Button.interactable = false;
                    Defense2Button.interactable = false;
                    Defense3Button.interactable = false;
                    Defense4Button.interactable = false;

                    break;
            }

            switch (incomeLevel)
            {
                case 0:
                    if (currMoney >= upgradeCost)
                    {
                        Income1Button.interactable = true;
                    }
                    else
                    {
                        Income1Button.interactable = false;
                    }

                    Income2Button.interactable = false;
                    Income3Button.interactable = false;
                    Income4Button.interactable = false;

                    break;
                case 1:
                    if (currMoney >= upgradeCost)
                    {
                        Income2Button.interactable = true;
                    }
                    else
                    {
                        Income2Button.interactable = false;
                    }

                    ColorBlock c1 = Income1Button.colors;
                    c1.disabledColor = new Color(18, 138, 100);
                    Income1Button.colors = c1;

                    Income1Button.interactable = false;
                    Income3Button.interactable = false;
                    Income4Button.interactable = false;

                    break;
                case 2:
                    if (currMoney >= upgradeCost)
                    {
                        Income3Button.interactable = true;
                    }
                    else
                    {
                        Income3Button.interactable = false;
                    }

                    ColorBlock c2 = Income2Button.colors;
                    c2.disabledColor = new Color(18, 138, 100);
                    Income2Button.colors = c2;

                    Income1Button.interactable = false;
                    Income2Button.interactable = false;
                    Income4Button.interactable = false;

                    break;
                case 3:
                    if (currMoney >= upgradeCost)
                    {
                        Income4Button.interactable = true;
                    }
                    else
                    {
                        Income4Button.interactable = false;
                    }

                    ColorBlock c3 = Income3Button.colors;
                    c3.disabledColor = new Color(18, 138, 100);
                    Income3Button.colors = c3;

                    Income1Button.interactable = false;
                    Income2Button.interactable = false;
                    Income3Button.interactable = false;

                    break;
                default:
                    ColorBlock c4 = Income4Button.colors;
                    c4.disabledColor = new Color(18, 138, 100);
                    Income4Button.colors = c4;

                    Income1Button.interactable = false;
                    Income2Button.interactable = false;
                    Income3Button.interactable = false;
                    Income4Button.interactable = false;

                    break;
            }
        }

        public void UpgradeTowersButton()
        {
            UIManager.SetActive(false);
            PlacePieces.SetActive(false);

            Attack1Button.gameObject.SetActive(true);
            Attack2Button.gameObject.SetActive(true);
            Attack3Button.gameObject.SetActive(true);
            Attack4Button.gameObject.SetActive(true);

            Defense1Button.gameObject.SetActive(true);
            Defense2Button.gameObject.SetActive(true);
            Defense3Button.gameObject.SetActive(true);
            Defense4Button.gameObject.SetActive(true);

            Income1Button.gameObject.SetActive(true);
            Income2Button.gameObject.SetActive(true);
            Income3Button.gameObject.SetActive(true);
            Income4Button.gameObject.SetActive(true);

            CloseUpgrades.gameObject.SetActive(true);
            UpgradeButton.gameObject.SetActive(false);

            upgradeMenuOpen = true;
        }

        public void CloseTowerUpgrades()
        {
            UIManager.SetActive(true);
            PlacePieces.SetActive(true);

            Attack1Button.gameObject.SetActive(false);
            Attack2Button.gameObject.SetActive(false);
            Attack3Button.gameObject.SetActive(false);
            Attack4Button.gameObject.SetActive(false);

            Defense1Button.gameObject.SetActive(false);
            Defense2Button.gameObject.SetActive(false);
            Defense3Button.gameObject.SetActive(false);
            Defense4Button.gameObject.SetActive(false);

            Income1Button.gameObject.SetActive(false);
            Income2Button.gameObject.SetActive(false);
            Income3Button.gameObject.SetActive(false);
            Income4Button.gameObject.SetActive(false);

            CloseUpgrades.gameObject.SetActive(false);
            UpgradeButton.gameObject.SetActive(true);

            upgradeMenuOpen = false;
        }

        public void AttackButton()
        {
            int increase_damage = 1;

            switch (attackLevel)
            {
                case 0:
                    increase_damage = 1;
                    break;
                case 1:
                    increase_damage = 5;
                    break;
                case 2:
                    increase_damage = 10;
                    break;
                case 3:
                    increase_damage = 20;
                    break;
                default:
                    break;
            }

            if (currPlayer == 1 || currPlayer == 2)
            {
                NetComm.SpendMoney(upgradeCost, 0);
                NetComm.IncreaseDamage(increase_damage, 0);
            }
            else if (currPlayer == 3)
            {
                NetComm.SpendMoney(0, upgradeCost);
                NetComm.IncreaseDamage(0, increase_damage);
            }

            allTowers = FindObjectsByType<TowerScript>(FindObjectsSortMode.None);
            foreach (TowerScript t in allTowers)
            {
                if (t.controller == 1)
                {
                    t.towerDamage = GlobalGameManager.player_1_damage;
                }
                else if (t.controller == 2)
                {
                    t.towerDamage = GlobalGameManager.player_2_damage;
                }
            }

            attackLevel++;
        }
        public void DefenseButton()
        {
            int increase_health = 5;

            switch (defenseLevel)
            {
                case 0:
                    increase_health = 5;
                    break;
                case 1:
                    increase_health = 10;
                    break;
                case 2:
                    increase_health = 10;
                    break;
                case 3:
                    increase_health = 20;
                    break;
                default:
                    increase_health = 5;
                    break;
            }

            if (currPlayer == 1 || currPlayer == 2)
            {
                NetComm.SpendMoney(upgradeCost, 0);
                NetComm.IncreaseTowerHealth(increase_health, 0);
            }
            else if (currPlayer == 3)
            {
                NetComm.SpendMoney(0, upgradeCost);
                NetComm.IncreaseTowerHealth(0, increase_health);
            }

            allTowers = FindObjectsByType<TowerScript>(FindObjectsSortMode.None);
            foreach (TowerScript t in allTowers)
            {
                if (t.controller == 1)
                {
                    t.towerHealth = GlobalGameManager.player_1_tower_health;
                }
                else if (t.controller == 2)
                {
                    t.towerHealth = GlobalGameManager.player_2_tower_health;
                }
            }

            defenseLevel++;
        }
        public void IncomeButton()
        {
            int increase_income = 5;

            switch (incomeLevel)
            {
                case 0:
                    increase_income = 5;
                    break;
                case 1:
                    increase_income = 5;
                    break;
                case 2:
                    increase_income = 5;
                    break;
                case 3:
                    increase_income = 5;
                    break;
                default:
                    increase_income = 5;
                    break;
            }

            if (currPlayer == 1 || currPlayer == 2)
            {
                NetComm.SpendMoney(upgradeCost, 0);
                NetComm.IncreaseTowerIncome(increase_income, 0);
            }
            else if (currPlayer == 3)
            {
                NetComm.SpendMoney(0, upgradeCost);
                NetComm.IncreaseTowerIncome(0, increase_income);
            }

            allTowers = FindObjectsByType<TowerScript>(FindObjectsSortMode.None);
            foreach (TowerScript t in allTowers)
            {
                if (t.gameObject.tag == "Income")
                {
                    if (t.controller == 1)
                    {
                        t.towerIncome = GlobalGameManager.player_1_tower_income;
                        NetComm.IncrementIncome(increase_income, 0);
                    }
                    else if (t.controller == 2)
                    {
                        t.towerIncome = GlobalGameManager.player_2_tower_income;
                        NetComm.IncrementIncome(0, increase_income);
                    }
                }
            }

            incomeLevel++;
        }

    }
}
