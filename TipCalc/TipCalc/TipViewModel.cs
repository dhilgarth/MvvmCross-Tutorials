﻿using Cirrious.MvvmCross.ViewModels;

namespace TipCalc.Core
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculation _calculation;
        public TipViewModel(ICalculation calculation)
        {
            _calculation = calculation;
        }

        public override void Start()
        {
            _subTotal = 100;
            _generosity = 10;
            Recalcuate();
            base.Start();
        }

        private double _subTotal;

        public double SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; RaisePropertyChanged(() => SubTotal); Recalcuate(); }
        }

        private int _generosity;

        public int Generosity
        {
            get { return _generosity; }
            set { _generosity = Limit(value); RaisePropertyChanged(() => Generosity); Recalcuate(); }
        }

        private int Limit(int value)
        {
            if (value < 0)
                value = 0;
            if (value > 40)
                value = 40;
            return value;
        }

        private double _tip;

        public double Tip
        {
            get { return _tip; }
            set { _tip = value; RaisePropertyChanged(() => Tip);}
        }

        private void Recalcuate()
        {
            Tip = _calculation.TipAmount(SubTotal, Generosity);
        }
    }
}