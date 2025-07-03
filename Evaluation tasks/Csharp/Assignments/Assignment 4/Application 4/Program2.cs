using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_04
{
    class MobilePhone
    {

        public delegate void RingEventHandler();


        public event RingEventHandler OnRing;


        public void ReceiveCall()
        {
            Console.WriteLine("Call Incoming");
            OnRing?.Invoke();
        }


        class RingtonePlayer
        {
            public void PhoneRinging()
            {
                Console.WriteLine("Playing ringtone...");
            }
        }

        class ScreenDisplay
        {
            public void PhoneRinging()
            {
                Console.WriteLine("Displaying caller information...");
            }
        }

        class VibrationMotor
        {
            public void PhoneRinging()
            {
                Console.WriteLine("Phone is vibrating...");
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                MobilePhone phone = new MobilePhone();

                RingtonePlayer ringtone = new RingtonePlayer();
                ScreenDisplay screen = new ScreenDisplay();
                VibrationMotor motor = new VibrationMotor();


                phone.OnRing += ringtone.PhoneRinging;
                phone.OnRing += screen.PhoneRinging;
                phone.OnRing += motor.PhoneRinging;


                phone.ReceiveCall();

                Console.ReadLine();
            }
        }
    }
}
