using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Util;
using System.Collections.Generic;
using System;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private TextView calculatorTextview;
        private HorizontalScrollView horizontalScrollView;

        enum KeyPressed
        {
            Number,
            Operator,
            Clear,
            Equals
        };

        List<string> calculateList = new List<string>();
        string currentNumber = "";
        bool operatorAdded = false;
        KeyPressed lastKeyPressed = KeyPressed.Clear;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            this.Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            calculatorTextview = FindViewById<TextView>(Resource.Id.calculatorDisplayTextview);
            horizontalScrollView = FindViewById<HorizontalScrollView>(Resource.Id.horizontalScrollView);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("onNumberClick")]
        public void onNumberClick(View v)
        {
            Button button = (Button)v;

            // Append the text to account for however many numbers the user presses.
            currentNumber += button.Text;
            calculatorTextview.Append(button.Text);

            // Auto scroll the view so the text being typed stays on screen.
            horizontalScrollView.FullScroll(FocusSearchDirection.Right);

            lastKeyPressed = KeyPressed.Number;
        }

        [Java.Interop.Export("onOperatorClick")]
        public void onOperatorClick(View v)
        {
            Log.Info("Main", "Operator click.");
            Button button = (Button)v;
            operatorAdded = true;

            if(lastKeyPressed != KeyPressed.Operator)
            {
                calculatorTextview.Append(button.Text);
                horizontalScrollView.FullScroll(FocusSearchDirection.Right);

                // Since we got an operator input, add both the number and operator to the list to calculate.
                calculateList.Add(currentNumber);
                calculateList.Add(button.Text);

                currentNumber = "";
            }
            else
            {
                // Since the user already pressed an operator we're just replacing the old one with the new one.
                calculatorTextview.Text = calculatorTextview.Text.Substring(0, calculatorTextview.Text.Length - 1);
                calculatorTextview.Append(button.Text);

                calculateList.RemoveAt(calculateList.Count - 1);
                calculateList.Add(button.Text);
            }

            lastKeyPressed = KeyPressed.Operator;
        }

        [Java.Interop.Export("onClearClick")]
        public void onClearClick(View v)
        {
            Log.Info("Main", "Clear click.");

            calculatorTextview.Text = "";
            calculateList.Clear();
            currentNumber = "";

            lastKeyPressed = KeyPressed.Clear;
        }

        [Java.Interop.Export("onEqualsClick")]
        public void onEqualsClick(View v)
        {
            Log.Info("Main", "Equals click.");

            // We can't calculate anything without an operator.
            if (operatorAdded)
            {
                calculateList.Add(currentNumber);
                double currentSum = 0;
                string currentOperator = "";

                foreach (string item in calculateList)
                {
                    if ("+-÷x".Contains(item))
                    {
                        currentOperator = item;
                    }
                    else
                    {
                        currentSum = calculate(currentSum, Double.Parse(item), currentOperator);
                    }
                }

                calculatorTextview.Text = "";
                calculatorTextview.Text = currentSum.ToString();
                calculateList.Clear();
                currentNumber = "";
                operatorAdded = false;
                calculateList.Add(currentSum.ToString());
            }

            lastKeyPressed = KeyPressed.Equals;
        }

        private double calculate(double firstNumber, double secondNumber, string currentOperator)
        {
            switch (currentOperator)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "÷":
                    return firstNumber / secondNumber;
                case "x":
                    return firstNumber * secondNumber;
            }

            // The first call to this function won't have an operator, so the second number is returned since it represents the current sum.
            return secondNumber;
        }
    }
}