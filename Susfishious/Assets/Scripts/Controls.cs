//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""ebd924ea-1bb7-49cf-bd7e-fcbce23461a6"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d76c7339-130d-4328-abad-c08cf4e3cd73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""da256af2-897c-45c6-b132-e139f28807cd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ActionA"",
                    ""type"": ""Button"",
                    ""id"": ""a09783a1-e1e8-4d7d-a2cd-23646a234a78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ActionB"",
                    ""type"": ""Button"",
                    ""id"": ""cf6f3af7-ffef-4230-9942-0f5a33097fa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""089e858a-048d-4548-9e31-2a2dabf6a920"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""97c300a0-d07a-4cc3-a61c-3afe90fef777"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""aebd7529-df02-4e14-85b7-08420b4518c3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f2daef00-d45d-4794-a68f-eef4e2abe031"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""34bb1cb0-a071-4bb2-bbbc-8f83ababa869"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5059a464-313b-4a1f-8e79-bd2c8edac34b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d15bd2a3-71c3-4248-86ba-43b0e436e404"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49841cdb-7375-406c-beb8-72ad9fb30fb3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d4b47763-96ce-4b31-af64-ca2ad59b73c0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""af6be0a2-6102-44e3-8496-005bafb2f5c6"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf1412f0-042a-4cb2-8036-5954d10839e5"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3749ff86-9fcb-4eb6-9a9e-487fd9e60141"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb5b9eb3-3490-4a58-b96b-ab548089e62a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c00021c-ecd0-41a5-93fe-e5af12897e56"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""43f3fab9-37a4-4b87-8999-e5e035b94423"",
            ""actions"": [
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""8d0adb64-46a8-4737-809f-c3be83c511a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e01d52a0-0ffc-4170-a797-c17983175218"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Interact = m_Character.FindAction("Interact", throwIfNotFound: true);
        m_Character_Move = m_Character.FindAction("Move", throwIfNotFound: true);
        m_Character_ActionA = m_Character.FindAction("ActionA", throwIfNotFound: true);
        m_Character_ActionB = m_Character.FindAction("ActionB", throwIfNotFound: true);
        m_Character_Start = m_Character.FindAction("Start", throwIfNotFound: true);
        m_Character_Jump = m_Character.FindAction("Jump", throwIfNotFound: true);
        m_Character_Look = m_Character.FindAction("Look", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_Next = m_Dialogue.FindAction("Next", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Interact;
    private readonly InputAction m_Character_Move;
    private readonly InputAction m_Character_ActionA;
    private readonly InputAction m_Character_ActionB;
    private readonly InputAction m_Character_Start;
    private readonly InputAction m_Character_Jump;
    private readonly InputAction m_Character_Look;
    public struct CharacterActions
    {
        private @Controls m_Wrapper;
        public CharacterActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Character_Interact;
        public InputAction @Move => m_Wrapper.m_Character_Move;
        public InputAction @ActionA => m_Wrapper.m_Character_ActionA;
        public InputAction @ActionB => m_Wrapper.m_Character_ActionB;
        public InputAction @Start => m_Wrapper.m_Character_Start;
        public InputAction @Jump => m_Wrapper.m_Character_Jump;
        public InputAction @Look => m_Wrapper.m_Character_Look;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnInteract;
                @Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                @ActionA.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActionA;
                @ActionA.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActionA;
                @ActionA.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActionA;
                @ActionB.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActionB;
                @ActionB.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActionB;
                @ActionB.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnActionB;
                @Start.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnStart;
                @Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ActionA.started += instance.OnActionA;
                @ActionA.performed += instance.OnActionA;
                @ActionA.canceled += instance.OnActionA;
                @ActionB.started += instance.OnActionB;
                @ActionB.performed += instance.OnActionB;
                @ActionB.canceled += instance.OnActionB;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private IDialogueActions m_DialogueActionsCallbackInterface;
    private readonly InputAction m_Dialogue_Next;
    public struct DialogueActions
    {
        private @Controls m_Wrapper;
        public DialogueActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Next => m_Wrapper.m_Dialogue_Next;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
            {
                @Next.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNext;
            }
            m_Wrapper.m_DialogueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
            }
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
    public interface ICharacterActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnActionA(InputAction.CallbackContext context);
        void OnActionB(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnNext(InputAction.CallbackContext context);
    }
}
