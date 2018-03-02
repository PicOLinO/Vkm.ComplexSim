﻿using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;

namespace VKMSmalta.View.Elements.ViewModel
{
    public sealed class VkmRotateWheelViewModel : ClickableElementViewModelBase, IValuableNamedElement
    {
        private readonly int rotationStepDegrees;
        private readonly int maxRotationSteps;
        private readonly int startupRotation;
        private int value;

        public override int Value
        {
            get => value;
            set
            {
                this.value = value;
                RotationDegrees = ((value-1) * rotationStepDegrees) + startupRotation; //TODO: value-1 временный косяк пока я не поверну исходное изображение Wheel на первый уровень.
            }
        }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        public VkmRotateWheelViewModel(int value, string name, int startupRotation, int rotationStepDegrees, int maxRotationSteps, string image = "/VKMSmalta;component/View/Images/Wheel.png") : base(value, name)
        {
            this.startupRotation = RotationDegrees = startupRotation;
            this.rotationStepDegrees = rotationStepDegrees;
            this.maxRotationSteps = maxRotationSteps;
            ImageSource = image;
            Value = value;
        }

        protected override void OnClick()
        {
            base.OnClick();

            if (Value < maxRotationSteps)
            {
                Value += 1;
            }
            else
            {
                Value = 1;
            }
        }
    }
}