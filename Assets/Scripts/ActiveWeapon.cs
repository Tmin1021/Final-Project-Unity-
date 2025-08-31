using UnityEngine;
using StarterAssets;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    // Update is called once per frame
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    WeaponSO currentWeaponSO;
    Animator animator;
    Weapon currentWeapon;

    float timer = 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmoAmount = 0;
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingWeaponSO);
        AdjustAmmo(startingWeaponSO.magazineSize);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int ammount)
    {
        currentAmmoAmount += ammount;

        if (currentAmmoAmount > currentWeaponSO.magazineSize)
        {
            currentAmmoAmount = currentWeaponSO.magazineSize;
        }

        ammoText.text = currentAmmoAmount.ToString("D2");
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.currentWeaponSO = weaponSO;
        AdjustAmmo(currentWeaponSO.magazineSize);
    }

    private void HandleShoot()
    {
        timer += Time.deltaTime;
        if (currentAmmoAmount <= 0) return;
        if (!starterAssetsInputs.shoot) return;
        if (timer >= currentWeaponSO.fireRate)
        {
            currentWeapon.Shoot(currentWeaponSO);
            animator.Play("Shoot", 0, 0);
            AdjustAmmo(-1);
            timer = 0f;
        }

        if (!currentWeaponSO.isAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }

    }

    void HandleZoom()
    {
        if (!currentWeaponSO.canZoom) return;
        if (starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = currentWeaponSO.zoomFOV;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotation(currentWeaponSO.rotationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotation(defaultRotationSpeed);
        }
    }
}
