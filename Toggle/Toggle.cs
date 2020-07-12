using SMLHelper.V2.Utility;
using UnityEngine;

namespace Straitjacket
{
    internal class Toggle
    {
        public enum Mode
        {
            Press, Hold
        }

        private KeyCode keyCode;
        public KeyCode KeyCode
        {
            get => keyCode;
            set
            {
                keyCode = value;
                Reset();
            }
        }
        private Mode keyMode;
        public Mode KeyMode
        {
            get => keyMode;
            set
            {
                keyMode = value;
                Reset();
            }
        }
        private bool enabledByDefault;
        public bool EnabledByDefault
        {
            get => enabledByDefault;
            set
            {
                enabledByDefault = value;
                Reset();
            }
        }


        private int lastFrame = -1;
        private bool enabled;
        public bool Enabled
        {
            get
            {

                switch (KeyMode)
                {
                    case Mode.Press:
                        int currentFrame = Time.frameCount;
                        if (KeyCodeUtils.GetKeyDown(KeyCode) && currentFrame > lastFrame)
                        {
                            enabled = !enabled;
                            lastFrame = currentFrame;
                        }
                        break;
                    case Mode.Hold:
                        if (KeyCodeUtils.GetKeyDown(KeyCode))
                        {
                            enabled = !EnabledByDefault;
                        }
                        else if (KeyCodeUtils.GetKeyUp(KeyCode))
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
