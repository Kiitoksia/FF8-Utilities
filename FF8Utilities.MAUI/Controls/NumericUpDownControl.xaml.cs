using System.Windows.Input;

namespace FF8Utilities.MAUI.Controls;

public partial class NumericUpDownControl : ContentView
{
    public static readonly BindableProperty PlusCommandProperty = BindableProperty.Create(nameof(PlusCommand), typeof(ICommand), typeof(NumericUpDownControl), null);
    public static readonly BindableProperty MinusCommandProperty = BindableProperty.Create(nameof(MinusCommand), typeof(ICommand), typeof(NumericUpDownControl), null);
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(int?), typeof(NumericUpDownControl), 0);
    public static readonly BindableProperty MinimumValueProperty = BindableProperty.Create(nameof(MinimumValue), typeof(int?), typeof(NumericUpDownControl), null);
    public static readonly BindableProperty MaximumValueProperty = BindableProperty.Create(nameof(MaximumValue), typeof(int?), typeof(NumericUpDownControl), null);


    public NumericUpDownControl()
	{
		InitializeComponent();
        

        MinusCommand = new Command(() =>
        {
            if (Value == null) Value = 0;

            if (MinimumValue != null && MinimumValue >= Value) return;
            Value--;
        });

        PlusCommand = new Command(() =>
        {
            if (Value == null) Value = 0;
            if (MaximumValue != null && MaximumValue <= Value) return;
            Value++;
        });
	}

    public int? Value
    {
        get => (int?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }



    public int? MinimumValue
    {
        get => (int?)GetValue(MinimumValueProperty);
        set => SetValue(MinimumValueProperty, value);
    }



    public int? MaximumValue
    {
        get => (int?)GetValue(MaximumValueProperty);
        set => SetValue(MaximumValueProperty, value);
    }


    public ICommand PlusCommand
    {
        get => (ICommand)GetValue(PlusCommandProperty);
        private set => SetValue(PlusCommandProperty, value);
    }



    public ICommand MinusCommand
    {
        get => (ICommand)GetValue(MinusCommandProperty);
        private set => SetValue(MinusCommandProperty, value);
    }
}