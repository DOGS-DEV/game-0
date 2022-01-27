using UnityEngine;

namespace Game0
{
    public enum InputSysytemType { Old, New }

    [RequireComponent(typeof(OldUserInputController), typeof(NewUserInputController))]

    public class HeroScript : MonoBehaviour
    {
        #region Variables and properties
        public InputSysytemType inputSysytemType;
        private InputSysytemType currentInputSysytemType;
        #endregion

        #region MonoBehaviour methods
        private void Start()
        {
            // Setting up input system
            inputSysytemType = InputSysytemType.Old;
            CheckInputSysytemType();
        }

        private void Update()
        {
            // Check InputSysytemType
            if (inputSysytemType != currentInputSysytemType) CheckInputSysytemType();
        }
        #endregion

        #region Methods
        private void CheckInputSysytemType()
        {
            GetComponent<OldUserInputController>().enabled = inputSysytemType == InputSysytemType.Old ? true : false;
            GetComponent<NewUserInputController>().enabled = inputSysytemType == InputSysytemType.New ? true : false;
            currentInputSysytemType = inputSysytemType;
        }
        #endregion
    }
}


