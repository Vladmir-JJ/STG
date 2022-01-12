using UnityEngine;
namespace JJ.STG.Enemy
{
    public static class KillShotSpeedIcrementation
    {
        public static void IncreaseRateOfFire(float rate)
        {
            var shooters = GameObject.FindGameObjectsWithTag("Shooter");
            foreach(GameObject shooter in shooters)
            {
                EnemyShooter shooterScript = shooter.GetComponent<EnemyShooter>();
                shooterScript.CutReloadTime += rate;
            }
        }
    }
}