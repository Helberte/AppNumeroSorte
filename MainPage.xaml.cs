namespace AppNumeroSorte;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnGenerateLuckNumber(object sender, EventArgs e)
	{
		LblNameApp.IsVisible = false;
		VstContainerCenter.IsVisible = true;

		//GenerateLuckNumbers01();
        GenerateLuckNumbers02();
    }

    /// <summary>
    /// Gera numeros aleatorios e os ordena usando linq,
    /// não os deixa repetir na lista utilizando lógica de 
    /// programação.
    /// </summary>
    /// <remarks>Helberte Costa</remarks>
	private void GenerateLuckNumbers01()
	{
		Random random	  = new();
		List<int> numbers = [];

		for (int i = 0; i < 6; i++)
		{
			int atualNumber = random.Next(1, 60);

            while (numbers.Contains(atualNumber))            
                atualNumber = random.Next(1, 60);            
			
			numbers.Add(atualNumber);
        }

        numbers = (from c 
				     in numbers 
				orderby c ascending 
				 select c).ToList();

        lblNumero01.Text = numbers[0].ToString("D2");
        lblNumero02.Text = numbers[1].ToString().PadLeft(2, '0');
        lblNumero03.Text = numbers[2].ToString().PadLeft(2, '0');
        lblNumero04.Text = numbers[3].ToString("D2");
        lblNumero05.Text = numbers[4].ToString("D2");
        lblNumero06.Text = numbers[5].ToString("D2");
    }

    /// <summary>
    /// Gera numeros aleatorios e os ordena não deixando repetir
    /// nenhum número utilizando a classe SortedSet
    /// programação.
    /// </summary>
    /// <remarks>Helberte Costa</remarks>
    private void GenerateLuckNumbers02()
    {
        Random random = new();

        // o sortedset já deixa a lista ordenada e não deixa repetir elemento
        SortedSet<int> numbers = [];
                
        while (numbers.Count < 7)       
            numbers.Add(random.Next(1, 60));      

        lblNumero01.Text = numbers.ElementAt(0).ToString("D2");
        lblNumero02.Text = numbers.ElementAt(1).ToString().PadLeft(2, '0');
        lblNumero03.Text = numbers.ElementAt(2).ToString().PadLeft(2, '0');
        lblNumero04.Text = numbers.ElementAt(3).ToString("D2");
        lblNumero05.Text = numbers.ElementAt(4).ToString("D2");
        lblNumero06.Text = numbers.ElementAt(5).ToString("D2");
    }
}