using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BorderAnimation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(AnimateBorder);
        }

        private async void AnimateBorder()
        {
            Action<double> tealMovement = tInput => tealGrad.Offset = (float)tInput;
            Action<double> orangeMovement = oInput => orangeGrad.Offset = (float)oInput;

            while (true)
            {
                mainRect.Animate(name: "forward", callback: tealMovement, start: 0, end: 1, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);
                mainRect.Animate(name: "backward", callback: tealMovement, start: 1, end: 0, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);

                mainRect.Animate(name: "forward2", callback: orangeMovement, start: 1, end: 0, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);
                mainRect.Animate(name: "backward2", callback: orangeMovement, start: 0, end: 1, length: 1000, easing: Easing.SinIn);
                await Task.Delay(1000);
            }
        }
    }
}
