using UnityEngine;

namespace Straitjacket
{
    internal class Toggle
    {
        public enum Mode
        {
            Press, Hold
        }

        public KeyCode KeyCode { get; private set; }
        public Mode KeyMode { get; private set; }
        public bool EnabledByDefault { get; private set; }

        private bool enabled;
        public bool Enabled
        {
            get
            {
                switch (KeyMode)
                {
                    case Mode.Press:
                        if (Input.GetKeyDown(KeyCode))
                        {
                            enabled = !enabled;
                        }
                        break;
                    case Mode.Hold:
                        if (Input.GetKeyDown(KeyCode))
                        {
                            enabled = !EnabledByDefault;
                        }
                        else if (Input.GetKeyUp(KeyCode))
                        {
                            enabled = EnabledByDefault;
                        }
                        break;
                }
                return enabled;
            }
        }

        public Toggle(KeyCode keyCode, Mode keyMode, bool enabledByDefault)
        {
            KeyCode = keyCode;
            KeyMode = keyMode;
            EnabledByDefault = enabledByDefault;
            enabled = EnabledByDefault;
        }

        public void Reset()
        {
            enabled = EnabledByDefault;
        }
    }
}
