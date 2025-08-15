using UnityEngine;
public class Energy : Health
{
	public int healAmount;
	public void RecoverEnergy()
	{
		Heal(healAmount);
	}
}