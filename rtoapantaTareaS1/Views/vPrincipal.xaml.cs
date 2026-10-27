namespace rtoapantaTareaS1.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string edadStr = txtEdad.Text;
        string salarioStr = txtSalario.Text;
        if (validarCampos(nombre, apellido, edadStr, salarioStr))
        {
            double salario = double.Parse(salarioStr);
            double aporteMensual = calcularAporte(salario);
            string mensaje = mostrarMensaje(nombre, apellido, int.Parse(edadStr), aporteMensual);
            guardarDatos(mensaje);
            limpiarFormulario();
        }
    }

    private bool validarCampos(string nombre, string apellido, string edadStr, string salarioStr)
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
            string.IsNullOrWhiteSpace(edadStr) || string.IsNullOrWhiteSpace(salarioStr))
        {
            DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
            return false;
        }
        if (!int.TryParse(edadStr, out int edad) || edad <= 0)
        {
            DisplayAlert("Error", "La edad debe ser un número entero positivo.", "Aceptar");
            return false;
        }
        if (!double.TryParse(salarioStr, out double salario) || salario <= 0)
        {
            DisplayAlert("Error", "El salario debe ser un número positivo.", "Aceptar");
            return false;
        }
        return true;
    }

    private double calcularAporte(double salario)
    {
        return salario * 0.0945;
    }

    private string mostrarMensaje(string nombre, string apellido, int edad, double aporteMensual)
    {
        String mensaje = $"Bienvenido: {nombre} {apellido}\nTienes: {edad} años\nTu aporte mensual es: {aporteMensual}";
        DisplayAlert("Detalle IESS", mensaje, "Aceptar");
        return mensaje;
    }

    private void limpiarFormulario()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtEdad.Text = string.Empty;
        txtSalario.Text = string.Empty;
    }

    private void guardarDatos(string mensaje)
    {
        string rutaProyecto = AppDomain.CurrentDomain.BaseDirectory;
        string carpeta = Path.Combine(rutaProyecto, "Archivos");
        string rutaArchivo = Path.Combine(carpeta, "tareaSemana1.txt");
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }
        if (!File.Exists(rutaArchivo))
        {
            File.Create(rutaArchivo).Dispose();
        }
        using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
        {
            writer.WriteLine(mensaje);
        }
    }
}