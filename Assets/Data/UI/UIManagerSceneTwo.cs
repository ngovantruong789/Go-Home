using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerSceneTwo : TruongMonoBehaviour
{
    [SerializeField] protected Button bttPlayGame;
    [SerializeField] protected Button bttQuitGame;

    [SerializeField] protected Sprite bttPlayGameidle;
    [SerializeField] protected Sprite bttPlayGameHover;
    [SerializeField] protected Sprite bttPlayGameClick;

    [SerializeField] protected Sprite bttQuitGameidle;
    [SerializeField] protected Sprite bttQuitGameHover;
    [SerializeField] protected Sprite bttQuitGameClick;

    public virtual void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public virtual void QuitGame()
    {
        Application.Quit();
    }

    public virtual void BttPlayGameIdle()
    {
        this.bttPlayGame.GetComponent<Image>().sprite = bttPlayGameidle;
    }

    public virtual void BttPlayGameHover()
    {
        this.bttPlayGame.GetComponent<Image>().sprite = bttPlayGameHover;
    }

    public virtual void BttPlayGameClick()
    {
        this.bttPlayGame.GetComponent<Image>().sprite = bttPlayGameClick;
    }

    public virtual void BttQuitGameIdle()
    {
        this.bttQuitGame.GetComponent<Image>().sprite = bttQuitGameidle;
    }

    public virtual void BttQuitGameHover()
    {
        this.bttQuitGame.GetComponent<Image>().sprite = bttQuitGameHover;
    }

    public virtual void BttQuitGameClick()
    {
        this.bttQuitGame.GetComponent<Image>().sprite = bttQuitGameClick;
    }
}
