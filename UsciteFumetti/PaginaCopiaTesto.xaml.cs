namespace UsciteFumetti;

public partial class PaginaCopiaTesto : ContentPage
{
	public PaginaCopiaTesto()
	{
		InitializeComponent();

        CopiaButton.Pressed += async (s, e) =>
        {
            VisualStateManager.GoToState(CopiaButton, "Pressed");
            CopiaButton.Text = "Testo Copiato!";
            await Task.Delay(1000); // Attendi per 1 secondo
            CopiaButton.Text = "Copia";
            VisualStateManager.GoToState(CopiaButton, "Normal");
        };

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is string testoDaMostrare)
        {
            textBox.Text = testoDaMostrare;
        }
    }

    private void OnCopyClicked(object sender, EventArgs e)
    {
        // Copia il testo dalla TextBox negli Appunti del sistema
        Clipboard.SetTextAsync(textBox.Text);
        // Oppure puoi usare Clipboard.SetText(textBox.Text); per versioni sincrone
    }
}