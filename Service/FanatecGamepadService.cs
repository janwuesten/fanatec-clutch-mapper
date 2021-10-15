using System;
using SharpDX.DirectInput;
using fanatec_clutch_mapper.Classes;

namespace fanatec_clutch_mapper.Service {
    class FanatecGamepadService {

        private Wheel wheel;
        private DirectInput directInput;
        private Joystick controller;
        private JoystickState state;
        private bool leftPressedPending = false;
        private int lastLeftVal = 0;
        private bool rightPressedPending = false;
        private int lastRightVal = 0;

        public bool IsError {
            get {
                return controller == null;
            }
        }

        public FanatecGamepadService(Wheel wheel) {
            this.wheel = wheel;
            directInput = new DirectInput();
            Load();
        }
        public void Load() {
            controller = GetController();
        }

        private Joystick GetController() {
            Joystick joystick = null;
            foreach (DeviceInstance di in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly)) {
                if (di.ProductName.ToLower().Contains(wheel.DeviceName.ToLower())) {
                    joystick = new Joystick(directInput, di.InstanceGuid);
                    joystick.Properties.BufferSize = 128;
                    joystick.SetCooperativeLevel(IntPtr.Zero, CooperativeLevel.Background | CooperativeLevel.NonExclusive);
                    joystick.Acquire();
                }
                break;
            }
            return joystick;
        }
        private void GetState() {

        }
        public int GetLeftPedal() {
            int val = wheel.MaxPedalValue - state.RotationX;
            if (!leftPressedPending && val > lastLeftVal) {
                lastLeftVal = val;
            } else if (!leftPressedPending && lastLeftVal != 0 && val == 0) {
                leftPressedPending = true;
            }
            return val;
        }
        public int GetRightPressed() {
            if (rightPressedPending) {
                rightPressedPending = false;
                int val = lastRightVal;
                lastRightVal = 0;
                return val;
            }
            return 0;
        }
        public int GetLeftPressed() {
            if (leftPressedPending) {
                leftPressedPending = false;
                int val = lastLeftVal;
                lastLeftVal = 0;
                return val;
            }
            return 0;
        }
        public int GetRightPedal() {
            int val = wheel.MaxPedalValue - state.RotationY;
            if (!rightPressedPending && val > lastRightVal) {
                lastRightVal = val;
            } else if (!rightPressedPending && lastRightVal != 0 && val == 0) {
                rightPressedPending = true;
            }
            return val;
        }
        public void ReadState() {
            if (controller != null) {
                state = controller.GetCurrentState();
            }
        }
    }
}
