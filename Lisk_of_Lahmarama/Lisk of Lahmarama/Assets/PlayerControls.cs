// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""c26fe500-100b-4b4c-86e7-48b3713915fb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ef26efe2-3ffd-4fba-93d5-a47793e3094d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KYBDMove"",
                    ""type"": ""Value"",
                    ""id"": ""c8a73567-18b8-4d54-929f-d79b9a2f8272"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WButton"",
                    ""type"": ""Button"",
                    ""id"": ""42c7bbc9-55b5-4705-8c7b-078c1489154b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SButton"",
                    ""type"": ""Button"",
                    ""id"": ""56418945-7808-4a7f-9350-4d6f765646b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NButton"",
                    ""type"": ""Button"",
                    ""id"": ""7c358537-8cba-415f-9a9f-17ff33103e86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""6fc51b84-7705-4a40-af84-b301248010d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LB"",
                    ""type"": ""Button"",
                    ""id"": ""d4270095-f2e0-491c-b51e-456c42cf2c79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""1dabad31-26a0-41bd-87b9-720739fdb607"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LT"",
                    ""type"": ""Button"",
                    ""id"": ""af06b0f6-04aa-48a0-9cdc-4a209c6bf42c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WButtonP2"",
                    ""type"": ""Button"",
                    ""id"": ""3b39fa31-6364-4676-a6e8-2629faeb80cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""KYBDMoveP2"",
                    ""type"": ""Value"",
                    ""id"": ""af8be621-ad0b-4bf1-880e-973e919f8d75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SButtonP2"",
                    ""type"": ""Button"",
                    ""id"": ""fd70f554-97db-4a4f-ab85-db19ff1b9f3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NButtonP2"",
                    ""type"": ""Button"",
                    ""id"": ""e8d0abc4-75fd-4cf7-8dd3-4457393ae2e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LTP2"",
                    ""type"": ""Button"",
                    ""id"": ""feb30f20-d5ff-4717-bbb2-27b298522d06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""49239151-8734-47e7-ac67-0d3401db9d77"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d236548-0741-4bdb-a68c-4482a2bacf3f"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43b4dff7-f133-4b7d-867f-484050e5b0e4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a81b246d-17fe-4d73-901e-6a2e76bb9ab8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77f70129-fb4a-4584-b6aa-a475d750225e"",
                    ""path"": ""<XInputController>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b780fb58-247e-434b-8150-48c2bd4faafe"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""810fc11c-1cc6-4b5e-a0fb-ffd58aaed198"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aa42f48-e3fd-450a-af0e-62f156f35a88"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e9484cc-90d5-4971-a73e-c55def36b86d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5186ae81-8ec9-48b2-ad6c-2229ce6ebf5d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de4a1917-033e-4747-b30c-8d95273136a1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d3d4555-0c6e-44bf-8bbf-7e3287cbadd5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b119c82-1b41-495c-9a54-9b45e8311329"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""bacfba1f-d35f-43a1-be84-f89391f37e42"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c6b06d44-0875-49a3-a8b5-a90274e7719b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8a4de26c-23ae-4d4f-b95e-b80921b3420d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c6108ac7-cc17-4c6e-bc11-73e799831db4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7ed2cd50-e55b-4c41-b196-d2cc7adc6f20"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""12ef8d87-f794-4243-8240-d2bde8422610"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMoveP2"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9a16f2ea-980e-4b40-94db-3fcbddc051bb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMoveP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ac6a94ed-2770-4da2-bc48-592fe0a45c80"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMoveP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b5730acc-4f1b-42a6-bca5-1d6559a02101"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMoveP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""55bd2c26-7e17-48db-abbd-2ee74d234648"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KYBDMoveP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8d822bd3-cf51-4e33-8981-e98da97b3a76"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0be24588-1caf-477c-ba2e-b26bde7b9fbc"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60245b98-f569-48b1-b7fa-0b35e8b4d577"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6897acbc-25e8-47c7-af64-dd92c5c40c8a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae467d17-a23b-451c-b96e-7d11c22299b3"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3290f0a7-9347-48f5-9200-9e0412612c0e"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02cbefd1-9697-4cd1-b143-5992feba13f8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NButtonP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b6a9093-fc9a-411c-b858-534d7c11600a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LTP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63b35e6d-a287-4ee5-b9ee-e4667f19365d"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LTP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_KYBDMove = m_Gameplay.FindAction("KYBDMove", throwIfNotFound: true);
        m_Gameplay_WButton = m_Gameplay.FindAction("WButton", throwIfNotFound: true);
        m_Gameplay_SButton = m_Gameplay.FindAction("SButton", throwIfNotFound: true);
        m_Gameplay_NButton = m_Gameplay.FindAction("NButton", throwIfNotFound: true);
        m_Gameplay_RB = m_Gameplay.FindAction("RB", throwIfNotFound: true);
        m_Gameplay_LB = m_Gameplay.FindAction("LB", throwIfNotFound: true);
        m_Gameplay_RT = m_Gameplay.FindAction("RT", throwIfNotFound: true);
        m_Gameplay_LT = m_Gameplay.FindAction("LT", throwIfNotFound: true);
        m_Gameplay_WButtonP2 = m_Gameplay.FindAction("WButtonP2", throwIfNotFound: true);
        m_Gameplay_KYBDMoveP2 = m_Gameplay.FindAction("KYBDMoveP2", throwIfNotFound: true);
        m_Gameplay_SButtonP2 = m_Gameplay.FindAction("SButtonP2", throwIfNotFound: true);
        m_Gameplay_NButtonP2 = m_Gameplay.FindAction("NButtonP2", throwIfNotFound: true);
        m_Gameplay_LTP2 = m_Gameplay.FindAction("LTP2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_KYBDMove;
    private readonly InputAction m_Gameplay_WButton;
    private readonly InputAction m_Gameplay_SButton;
    private readonly InputAction m_Gameplay_NButton;
    private readonly InputAction m_Gameplay_RB;
    private readonly InputAction m_Gameplay_LB;
    private readonly InputAction m_Gameplay_RT;
    private readonly InputAction m_Gameplay_LT;
    private readonly InputAction m_Gameplay_WButtonP2;
    private readonly InputAction m_Gameplay_KYBDMoveP2;
    private readonly InputAction m_Gameplay_SButtonP2;
    private readonly InputAction m_Gameplay_NButtonP2;
    private readonly InputAction m_Gameplay_LTP2;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @KYBDMove => m_Wrapper.m_Gameplay_KYBDMove;
        public InputAction @WButton => m_Wrapper.m_Gameplay_WButton;
        public InputAction @SButton => m_Wrapper.m_Gameplay_SButton;
        public InputAction @NButton => m_Wrapper.m_Gameplay_NButton;
        public InputAction @RB => m_Wrapper.m_Gameplay_RB;
        public InputAction @LB => m_Wrapper.m_Gameplay_LB;
        public InputAction @RT => m_Wrapper.m_Gameplay_RT;
        public InputAction @LT => m_Wrapper.m_Gameplay_LT;
        public InputAction @WButtonP2 => m_Wrapper.m_Gameplay_WButtonP2;
        public InputAction @KYBDMoveP2 => m_Wrapper.m_Gameplay_KYBDMoveP2;
        public InputAction @SButtonP2 => m_Wrapper.m_Gameplay_SButtonP2;
        public InputAction @NButtonP2 => m_Wrapper.m_Gameplay_NButtonP2;
        public InputAction @LTP2 => m_Wrapper.m_Gameplay_LTP2;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @KYBDMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKYBDMove;
                @KYBDMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKYBDMove;
                @KYBDMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKYBDMove;
                @WButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWButton;
                @WButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWButton;
                @WButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWButton;
                @SButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSButton;
                @SButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSButton;
                @SButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSButton;
                @NButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButton;
                @NButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButton;
                @NButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButton;
                @RB.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRB;
                @LB.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLB;
                @LB.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLB;
                @LB.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLB;
                @RT.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRT;
                @LT.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLT;
                @LT.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLT;
                @LT.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLT;
                @WButtonP2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWButtonP2;
                @WButtonP2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWButtonP2;
                @WButtonP2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWButtonP2;
                @KYBDMoveP2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKYBDMoveP2;
                @KYBDMoveP2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKYBDMoveP2;
                @KYBDMoveP2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKYBDMoveP2;
                @SButtonP2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSButtonP2;
                @SButtonP2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSButtonP2;
                @SButtonP2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSButtonP2;
                @NButtonP2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButtonP2;
                @NButtonP2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButtonP2;
                @NButtonP2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNButtonP2;
                @LTP2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLTP2;
                @LTP2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLTP2;
                @LTP2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLTP2;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @KYBDMove.started += instance.OnKYBDMove;
                @KYBDMove.performed += instance.OnKYBDMove;
                @KYBDMove.canceled += instance.OnKYBDMove;
                @WButton.started += instance.OnWButton;
                @WButton.performed += instance.OnWButton;
                @WButton.canceled += instance.OnWButton;
                @SButton.started += instance.OnSButton;
                @SButton.performed += instance.OnSButton;
                @SButton.canceled += instance.OnSButton;
                @NButton.started += instance.OnNButton;
                @NButton.performed += instance.OnNButton;
                @NButton.canceled += instance.OnNButton;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @LB.started += instance.OnLB;
                @LB.performed += instance.OnLB;
                @LB.canceled += instance.OnLB;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @LT.started += instance.OnLT;
                @LT.performed += instance.OnLT;
                @LT.canceled += instance.OnLT;
                @WButtonP2.started += instance.OnWButtonP2;
                @WButtonP2.performed += instance.OnWButtonP2;
                @WButtonP2.canceled += instance.OnWButtonP2;
                @KYBDMoveP2.started += instance.OnKYBDMoveP2;
                @KYBDMoveP2.performed += instance.OnKYBDMoveP2;
                @KYBDMoveP2.canceled += instance.OnKYBDMoveP2;
                @SButtonP2.started += instance.OnSButtonP2;
                @SButtonP2.performed += instance.OnSButtonP2;
                @SButtonP2.canceled += instance.OnSButtonP2;
                @NButtonP2.started += instance.OnNButtonP2;
                @NButtonP2.performed += instance.OnNButtonP2;
                @NButtonP2.canceled += instance.OnNButtonP2;
                @LTP2.started += instance.OnLTP2;
                @LTP2.performed += instance.OnLTP2;
                @LTP2.canceled += instance.OnLTP2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnKYBDMove(InputAction.CallbackContext context);
        void OnWButton(InputAction.CallbackContext context);
        void OnSButton(InputAction.CallbackContext context);
        void OnNButton(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnLB(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnLT(InputAction.CallbackContext context);
        void OnWButtonP2(InputAction.CallbackContext context);
        void OnKYBDMoveP2(InputAction.CallbackContext context);
        void OnSButtonP2(InputAction.CallbackContext context);
        void OnNButtonP2(InputAction.CallbackContext context);
        void OnLTP2(InputAction.CallbackContext context);
    }
}
