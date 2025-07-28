using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiBrownianMotion.Models;

namespace MauiBrownianMotion.ViewModels;

public class BrownianViewModel : INotifyPropertyChanged
{
    private double _initialPrice;
    private double _sigma;
    private double _mean;
    private int _numDays;
    private ObservableCollection<double> _prices = new();

    public double InitialPrice
    {
        get => _initialPrice;
        set { _initialPrice = value; OnPropertyChanged(); }
    }

    public double Sigma
    {
        get => _sigma;
        set { _sigma = value; OnPropertyChanged(); }
    }

    public double Mean
    {
        get => _mean;
        set { _mean = value; OnPropertyChanged(); }
    }

    public int NumDays
    {
        get => _numDays;
        set { _numDays = value; OnPropertyChanged(); }
    }

    public ObservableCollection<double> Prices
    {
        get => _prices;
        set { _prices = value; OnPropertyChanged(); }
    }

    public Command GenerateCommand { get; }

    public BrownianViewModel()
    {
        GenerateCommand = new Command(GeneratePrices);
    }

    private void GeneratePrices()
    {
        var SigmaDecimal = Sigma / 100.0;
        var MeanDecimal = Mean / 100.0;
        var generated = BrownianModel.GenerateBrownianMotion(SigmaDecimal, MeanDecimal, InitialPrice, NumDays);
        Prices = new ObservableCollection<double>(generated);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
