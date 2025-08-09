using UnityEngine;

public class Health
{
    private int _value;
    private int _maxValue;
    public int value => _value;
    public int maxValue => _maxValue;
    public void SetUp(int max, int current = -1)
    {
        _maxValue = max;
        if (current == -1)
            _value = _maxValue;
    }

    public virtual void Hit(int damage)
    {
        _value -= damage;
    }
    public virtual void Heal(int healAmount)
    {
        _value += healAmount;
    }
    public virtual void Increase(int increaseAmount)
    {
        _maxValue += increaseAmount;
    }
}
