using System.Collections.ObjectModel;
using System.Globalization;

namespace ShopApp;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<Product> products = new()
    {
        new FoodProduct("Молоко", 42.50m, "Україна", new DateTime(2026, 11, 18), "Пастеризоване, 2.5%", 7, 20, "л"),
        new FoodProduct("Сир гауда", 285m, "Нідерланди", new DateTime(2026, 11, 10), "Твердий сир", 90, 5, "кг"),
        new FoodProduct("Гречка", 56m, "Україна", new DateTime(2026, 9, 3), "Крупа ядриця", 365, 40, "кг"),
        new Book("Кобзар", 320m, "Україна", new DateTime(2026, 9, 1), "Збірка поезій", 704, "Основа",
            new List<string> { "Тарас Шевченко" }),
        new Book("Тигролови", 210m, "Україна", new DateTime(2026, 10, 12), "Роман", 480, "Фоліо",
            new List<string> { "Іван Багряний" })
    };

    public MainPage()
    {
        InitializeComponent();

        ProductsView.ItemsSource = products;
        TypePicker.ItemsSource = new[] { "Продукт", "Книга" };
        TypePicker.SelectedIndex = 0;
    }

    private void OnTypeChanged(object? sender, EventArgs e)
    {
        bool isFood = TypePicker.SelectedIndex == 0;

        FoodFields.IsVisible = isFood;
        BookFields.IsVisible = !isFood;
    }

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        try
        {
            products.Add(CreateProduct());
            ClearForm();
        }
        catch (ArgumentException ex)
        {
            await DisplayAlertAsync("Помилка", ex.Message, "OK");
        }
    }

    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        if (ProductsView.SelectedItem is Product selected)
        {
            products.Remove(selected);
        }
        else
        {
            await DisplayAlertAsync("Увага", "Спочатку виберіть товар у таблиці.", "OK");
        }
    }

    private Product CreateProduct()
    {
        string name = Required(NameEntry.Text, "Назва");
        decimal price = ParseDecimal(PriceEntry.Text, "Ціна");
        string country = Required(CountryEntry.Text, "Країна походження");
        string description = DescriptionEntry.Text?.Trim() ?? string.Empty;

        DateTime? picked = PackingDatePicker.Date;
        DateTime packingDate = picked ?? DateTime.Today;

        if (TypePicker.SelectedIndex == 0)
        {
            return new FoodProduct(name, price, country, packingDate, description,
                ParseInt(ShelfLifeEntry.Text, "Термін придатності"),
                ParseDecimal(QuantityEntry.Text, "Кількість"),
                Required(UnitEntry.Text, "Одиниця виміру"));
        }

        List<string> authors = (AuthorsEntry.Text ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .ToList();

        if (authors.Count == 0)
        {
            throw new ArgumentException("Вкажіть хоча б одного автора.");
        }

        return new Book(name, price, country, packingDate, description,
            ParseInt(PagesEntry.Text, "Кількість сторінок"),
            Required(PublisherEntry.Text, "Видавництво"),
            authors);
    }

    private void ClearForm()
    {
        Entry[] entries =
        {
            NameEntry, PriceEntry, CountryEntry, DescriptionEntry, ShelfLifeEntry,
            QuantityEntry, UnitEntry, PagesEntry, PublisherEntry, AuthorsEntry
        };

        foreach (Entry entry in entries)
        {
            entry.Text = string.Empty;
        }

        PackingDatePicker.Date = DateTime.Today;
    }

    private static string Required(string? text, string field)
    {
        string value = text?.Trim() ?? string.Empty;

        return value.Length > 0
            ? value
            : throw new ArgumentException($"Поле «{field}» не може бути порожнім.");
    }

    private static int ParseInt(string? text, string field)
    {
        if (int.TryParse(text, out int value) && value > 0)
        {
            return value;
        }

        throw new ArgumentException($"Поле «{field}» має містити додатне ціле число.");
    }

    private static decimal ParseDecimal(string? text, string field)
    {
        if (decimal.TryParse(text?.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value) && value > 0)
        {
            return value;
        }

        throw new ArgumentException($"Поле «{field}» має містити додатне число.");
    }
}
