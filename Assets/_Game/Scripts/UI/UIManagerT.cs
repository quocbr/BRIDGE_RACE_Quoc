using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerT : Singleton<UIManagerT>
{
    [SerializeField] private GameObject panelListLevel;
    [SerializeField] private GameObject panelBack;
    [SerializeField] private GameObject panelMainmenu;
    [SerializeField] private GameObject panelWin;

    public void HideListLevel()
    {
        panelListLevel.SetActive(false);
    }

    public void ShowListLevel()
    {
        panelListLevel.SetActive(true);
    }

    public void HidePanelBack()
    {
        panelBack.SetActive(false);
        LevelManager.Ins.DeleteCurentMap();
        GameManager.Ins.IsStart = false;
        ShowMainMenul();
    }

    public void ShowWin()
    {
        panelBack.SetActive(false);
        panelWin.SetActive(true);
    }

    public void HidePanelWin()
    {
        panelWin.SetActive(false);
        LevelManager.Ins.DeleteCurentMap();
        GameManager.Ins.IsStart = false;
        ShowMainMenul();
    }

    public void ShowPanelBack()
    {
        HideListLevel();
        HideMainMenu();
        panelBack.SetActive(true);
    }

    public void HideMainMenu()
    {
        panelMainmenu.SetActive(false);
    }

    public void ShowMainMenul()
    {
        panelMainmenu.SetActive(true);
    }
}
