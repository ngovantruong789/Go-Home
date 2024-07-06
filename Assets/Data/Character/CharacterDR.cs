using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDR : DamgeReceiver
{
    public float Hp => hp;
    public float HpMax => hpMax;

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        AudioManager.Instance.PlayAudio("Painful");
    }

    protected override void OnDead()
    {
        this.Invoke(nameof(this.GameOver), 1);
    }

    protected virtual void GameOver()
    {
        Time.timeScale = 0;
        AudioManager.Instance.StopAudio("Soundtrack");
        AudioManager.Instance.PlayAudio("GameOver");
        UIManager.Instance.SetMaxPoint();
        UIManager.Instance.EnablePanelEndGame();
    }
}
