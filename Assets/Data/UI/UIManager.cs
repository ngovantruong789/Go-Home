using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : TruongMonoBehaviour
{
    [SerializeField]private static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField] protected GameObject panelPause;
    [SerializeField] protected GameObject panelEndGame;
    [SerializeField] protected Button buttonPause;
    [SerializeField] protected TextMeshProUGUI point;
    [SerializeField] protected TextMeshProUGUI maxPoint;
    [SerializeField] protected TextMeshProUGUI lowHpBoss;
    [SerializeField] protected int countPoint = 0;

    protected override void Awake()
    {
        base.Awake();
        if (UIManager.instance != null) Debug.LogError("Only 1 UIManager allow to exits");
        UIManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.DisablePanel();
        this.DisablePanelEndGame();
        this.SetMaxPoint();
        this.SetCountPoint();
        this.DisableLowHpBoss();
    }

    public virtual void SetPoint()
    {
        this.countPoint++;
        this.point.text = "Points : " + this.countPoint.ToString();

        if (this.countPoint > PlayerPrefs.GetInt("HightScore", 0)) 
            PlayerPrefs.SetInt("HightScore", this.countPoint);
    }

    public virtual void SetMaxPoint()
    {
        this.maxPoint.text = "HightScore : " + PlayerPrefs.GetInt("HightScore", 0).ToString();
    }

    protected virtual void SetCountPoint()
    {
        this.countPoint = 0;
    }

    protected virtual void DisablePanelEndGame()
    {
        this.panelEndGame.SetActive(false);
    }

    public virtual void EnablePanelEndGame()
    {
        this.panelEndGame.SetActive(true);
    }

    protected virtual void EnablePanel()
    {
        this.panelPause.SetActive(true);
        this.buttonPause.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    protected virtual void DisablePanel()
    {
        this.panelPause.SetActive(false);
        this.buttonPause.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    public virtual void ClickPause()
    {
        this.EnablePanel();

        AudioManager.Instance.DisableVolume("Soundtrack");
    }

    public virtual void ClickCancel()
    {
        this.DisablePanel();
        AudioManager.Instance.EnableVolume("Soundtrack");
    }

    public virtual void EnableLowHpBoss()
    {
        this.lowHpBoss.gameObject.SetActive(true);
        this.Invoke(nameof(this.DisableLowHpBoss), 3f);
    }

    public virtual void DisableLowHpBoss()
    {
        this.lowHpBoss.gameObject.SetActive(false);
    }

    public virtual void Home()
    {
        SceneManager.LoadScene(0);
    }

    public virtual void ClickRestart()
    {
        SceneManager.LoadScene(1);
    }
}
