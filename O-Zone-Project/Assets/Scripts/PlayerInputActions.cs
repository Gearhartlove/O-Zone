// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControlsMap"",
            ""id"": ""0ccc3475-d15e-4981-9a14-0f0746a12ea7"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""888724ed-064e-4cfa-914f-5e614161ffa7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick"",
                    ""type"": ""Value"",
                    ""id"": ""ec2e9831-5f79-4a12-bddb-a84b3ae48df9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""46409161-900b-41bb-9c6b-77a8e3c806c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""b64cc2ee-53af-4899-a989-fd17317357c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""dafbbae1-6d5f-4ef7-b11d-76667a66370b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""9d25da1c-c751-40f9-ae91-18c9f0c87a98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""62c68488-3304-44ea-9e03-acd2596663c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""1481d736-0440-4a03-8d22-90883dc8884d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""20f304bf-db2f-471b-a1ed-0e61e339e483"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TempAction"",
                    ""type"": ""Button"",
                    ""id"": ""bc252e7f-5e6e-4fd9-9efd-1acd2fa2bc0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3e430c1a-75ec-422f-bcba-9bda2797ab0d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95f6367e-2584-4bfc-987a-97f3c035a917"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb8053d3-79d3-4251-8957-71dd22c526c4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""905f1fbc-4269-43f4-a9c7-90b11fd5fdc1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14181ab7-bc8f-4936-b010-4aa6391cded2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70e230b5-f10a-4216-985b-a708ae471552"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31a980d7-a050-4cb2-b47e-102ba469d154"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f76dda1c-ca4d-42e8-86fc-301df530a5b2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""981c8df8-2dbf-4955-bcf0-dd1cad299787"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d610220-2c69-4d26-9d88-1b3425a9372e"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TempAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControlsMap
        m_PlayerControlsMap = asset.FindActionMap("PlayerControlsMap", throwIfNotFound: true);
        m_PlayerControlsMap_LeftStick = m_PlayerControlsMap.FindAction("LeftStick", throwIfNotFound: true);
        m_PlayerControlsMap_RightStick = m_PlayerControlsMap.FindAction("RightStick", throwIfNotFound: true);
        m_PlayerControlsMap_Start = m_PlayerControlsMap.FindAction("Start", throwIfNotFound: true);
        m_PlayerControlsMap_WestButton = m_PlayerControlsMap.FindAction("WestButton", throwIfNotFound: true);
        m_PlayerControlsMap_EastButton = m_PlayerControlsMap.FindAction("EastButton", throwIfNotFound: true);
        m_PlayerControlsMap_NorthButton = m_PlayerControlsMap.FindAction("NorthButton", throwIfNotFound: true);
        m_PlayerControlsMap_SouthButton = m_PlayerControlsMap.FindAction("SouthButton", throwIfNotFound: true);
        m_PlayerControlsMap_LeftTrigger = m_PlayerControlsMap.FindAction("LeftTrigger", throwIfNotFound: true);
        m_PlayerControlsMap_RightTrigger = m_PlayerControlsMap.FindAction("RightTrigger", throwIfNotFound: true);
        m_PlayerControlsMap_TempAction = m_PlayerControlsMap.FindAction("TempAction", throwIfNotFound: true);
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

    // PlayerControlsMap
    private readonly InputActionMap m_PlayerControlsMap;
    private IPlayerControlsMapActions m_PlayerControlsMapActionsCallbackInterface;
    private readonly InputAction m_PlayerControlsMap_LeftStick;
    private readonly InputAction m_PlayerControlsMap_RightStick;
    private readonly InputAction m_PlayerControlsMap_Start;
    private readonly InputAction m_PlayerControlsMap_WestButton;
    private readonly InputAction m_PlayerControlsMap_EastButton;
    private readonly InputAction m_PlayerControlsMap_NorthButton;
    private readonly InputAction m_PlayerControlsMap_SouthButton;
    private readonly InputAction m_PlayerControlsMap_LeftTrigger;
    private readonly InputAction m_PlayerControlsMap_RightTrigger;
    private readonly InputAction m_PlayerControlsMap_TempAction;
    public struct PlayerControlsMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_PlayerControlsMap_LeftStick;
        public InputAction @RightStick => m_Wrapper.m_PlayerControlsMap_RightStick;
        public InputAction @Start => m_Wrapper.m_PlayerControlsMap_Start;
        public InputAction @WestButton => m_Wrapper.m_PlayerControlsMap_WestButton;
        public InputAction @EastButton => m_Wrapper.m_PlayerControlsMap_EastButton;
        public InputAction @NorthButton => m_Wrapper.m_PlayerControlsMap_NorthButton;
        public InputAction @SouthButton => m_Wrapper.m_PlayerControlsMap_SouthButton;
        public InputAction @LeftTrigger => m_Wrapper.m_PlayerControlsMap_LeftTrigger;
        public InputAction @RightTrigger => m_Wrapper.m_PlayerControlsMap_RightTrigger;
        public InputAction @TempAction => m_Wrapper.m_PlayerControlsMap_TempAction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControlsMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsMapActions instance)
        {
            if (m_Wrapper.m_PlayerControlsMapActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnLeftStick;
                @RightStick.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnRightStick;
                @RightStick.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnRightStick;
                @RightStick.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnRightStick;
                @Start.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnStart;
                @WestButton.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnWestButton;
                @WestButton.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnWestButton;
                @WestButton.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnWestButton;
                @EastButton.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnEastButton;
                @EastButton.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnEastButton;
                @EastButton.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnEastButton;
                @NorthButton.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnNorthButton;
                @NorthButton.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnNorthButton;
                @NorthButton.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnNorthButton;
                @SouthButton.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnSouthButton;
                @SouthButton.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnSouthButton;
                @SouthButton.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnSouthButton;
                @LeftTrigger.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnLeftTrigger;
                @RightTrigger.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnRightTrigger;
                @TempAction.started -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnTempAction;
                @TempAction.performed -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnTempAction;
                @TempAction.canceled -= m_Wrapper.m_PlayerControlsMapActionsCallbackInterface.OnTempAction;
            }
            m_Wrapper.m_PlayerControlsMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @RightStick.started += instance.OnRightStick;
                @RightStick.performed += instance.OnRightStick;
                @RightStick.canceled += instance.OnRightStick;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
                @EastButton.started += instance.OnEastButton;
                @EastButton.performed += instance.OnEastButton;
                @EastButton.canceled += instance.OnEastButton;
                @NorthButton.started += instance.OnNorthButton;
                @NorthButton.performed += instance.OnNorthButton;
                @NorthButton.canceled += instance.OnNorthButton;
                @SouthButton.started += instance.OnSouthButton;
                @SouthButton.performed += instance.OnSouthButton;
                @SouthButton.canceled += instance.OnSouthButton;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @TempAction.started += instance.OnTempAction;
                @TempAction.performed += instance.OnTempAction;
                @TempAction.canceled += instance.OnTempAction;
            }
        }
    }
    public PlayerControlsMapActions @PlayerControlsMap => new PlayerControlsMapActions(this);
    public interface IPlayerControlsMapActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnRightStick(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
        void OnEastButton(InputAction.CallbackContext context);
        void OnNorthButton(InputAction.CallbackContext context);
        void OnSouthButton(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnTempAction(InputAction.CallbackContext context);
    }
}
