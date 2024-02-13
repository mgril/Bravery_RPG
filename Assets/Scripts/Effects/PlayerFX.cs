using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerFX : EntityFX
{
    private CinemachineImpulseSource screenShake;

    [Header("Screen Shake fx")]
    [SerializeField] private float shakeMultiplier;
    public Vector3 swordImpactShake;
    public Vector3 highDamageShake;
    [Header("After Image fx")]
    [SerializeField] private float afterImageCooldown;
    [SerializeField] private GameObject afterImagePrefab;
    [SerializeField] private float colorLooseRate;
    private float afterImageCooldownTimer;

    [Space]
    [SerializeField] private ParticleSystem dustFx;

    protected override void Start()
    {
        base.Start();

        screenShake = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        afterImageCooldownTimer = -Time.deltaTime;
    }

    public void ScreenShake(Vector3 _shakePower)
    {
        screenShake.m_DefaultVelocity = new Vector3(_shakePower.x * player.facingDir, _shakePower.y) * shakeMultiplier;
        screenShake.GenerateImpulse();
    }

    public void CreateAfterImage()
    {
        if (afterImageCooldownTimer < 0)
        {
            afterImageCooldownTimer = afterImageCooldown;
            GameObject newAfterImage = Instantiate(afterImagePrefab, transform.position, transform.rotation);

            newAfterImage.GetComponent<AfterImageFX>().SetupAfterImage(colorLooseRate, sr.sprite);
        }

    }

    public void PlayDustFX()
    {
        if (dustFx != null)
            dustFx.Play();
    }

}
