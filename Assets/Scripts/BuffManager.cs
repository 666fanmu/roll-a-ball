using UnityEngine;

public abstract class Buff
{
    public enum BuffKind
    {
        HpBuff,
        SpeedBuff,
        HightBuff,
    }
    public float m_length;
    public BuffKind m_buffKind;
    public player m_player;
    public float timer;
    public Buff(player player, BuffKind buffKind, float length)
    {
        m_player = player;
        m_buffKind = buffKind;
        m_length = length;
        timer = 0;
    }
    public virtual void OnAdd() { }
    public virtual void OnUpdate() { }
    public virtual void OnRemove() { }
}
public class SpeedBuff : Buff
{
    public float DeltaSpeed = 1f;
    public SpeedBuff(player player, BuffKind buffKind, float length) : base(player, buffKind, length) { }
    public override void OnAdd()
    {
        base.OnAdd();
        m_player.moveSpeed += DeltaSpeed;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if(timer>=m_length)
        {
            
        }
        timer += Time.fixedDeltaTime;
    }
    public override void OnRemove()
    {
        base.OnRemove();
        m_player.moveSpeed -= DeltaSpeed;
    }
}
