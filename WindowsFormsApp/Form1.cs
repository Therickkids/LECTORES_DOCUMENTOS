using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


/*
 *Julian Manrique Cuervo
 *5/09/2024
 *Herramientas De Programacion_II
 */

namespace WindowsFormsApp
{
    public partial class frmMain : Form
    {
        private string pSelectedFileType;
        private string pFilePath;

        public frmMain()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = true; // Asegúrate de que las columnas se generen automáticamente
            dataGridView.ReadOnly = false; // Habilitar la edición
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Inicializar componentes
        }

        // Métodos para seleccionar el tipo de archivo (TXT, CSV, XML, RTF)
        private void cmdTxt_Click(object sender, EventArgs e)
        {
            pSelectedFileType = "TXT";
            lblStatus.Text = "Formato seleccionado: TXT";
            ResetForm();
        }

        private void cmdCsv_Click(object sender, EventArgs e)
        {
            pSelectedFileType = "CSV";
            lblStatus.Text = "Formato seleccionado: CSV";
            ResetForm();
        }

        private void cmdXml_Click(object sender, EventArgs e)
        {
            pSelectedFileType = "XML";
            lblStatus.Text = "Formato seleccionado: XML";
            ResetForm();
        }

        private void cmdRtf_Click(object sender, EventArgs e)
        {
            pSelectedFileType = "RTF";
            lblStatus.Text = "Formato seleccionado: RTF";
            ResetForm();
        }



        private void CargarArchivo(string filePath)
        {
            try
            {
                // Verificar la extensión del archivo
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension != ".rtf")
                {
                    MessageBox.Show("El archivo seleccionado no es un archivo RTF.");
                    return;
                }

                // Cargar el archivo RTF
                CargarRTF(filePath);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al cargar el archivo: {ex.Message}";
            }
        }



      

        private string ConvertirAFormatoRTF(string filePath)
        {
            try
            {
                // Crear un RichTextBox para convertir el archivo
                using (RichTextBox rtfBox = new RichTextBox())
                {
                    string extension = Path.GetExtension(filePath).ToLower();

                    // Verificar el tipo de archivo y cargarlo en el RichTextBox
                    if (extension == ".txt")
                    {
                        // Cargar archivo de texto plano
                        rtfBox.Text = File.ReadAllText(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Este formato no es compatible para conversión automática.");
                        throw new NotSupportedException("Formato no compatible.");
                    }

                    // Guardar el archivo en formato RTF
                    string newRtfPath = Path.ChangeExtension(filePath, ".rtf");
                    rtfBox.SaveFile(newRtfPath, RichTextBoxStreamType.RichText);

                    MessageBox.Show($"Archivo convertido a RTF: {newRtfPath}");

                    return newRtfPath; // Retornar la nueva ruta del archivo RTF
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir a RTF: {ex.Message}");
                throw;
            }
        }

        // Método para abrir un archivo usando OpenFileDialog
        private void SeleccionarArchivo()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configurar el filtro de archivos según el tipo seleccionado
                switch (pSelectedFileType)
                {
                    case "TXT":
                        openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                        break;
                    case "CSV":
                        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        break;
                    case "XML":
                        openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                        break;
                    case "RTF":
                        openFileDialog.Filter = "Rich Text Format files (*.rtf)|*.rtf|All files (*.*)|*.*";
                        break;
                    default:
                        openFileDialog.Filter = "All files (*.*)|*.*"; // Por si no se selecciona ningún tipo
                        break;
                }

                openFileDialog.Title = "Seleccionar archivo";

                // Mostrar el cuadro de diálogo y obtener la ruta seleccionada
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pFilePath = openFileDialog.FileName;
                    lblStatus.Text = $"Archivo seleccionado: {pFilePath}";
                    CargarContenidoArchivo(); // Cargar y mostrar el contenido del archivo
                }
                else
                {
                    lblStatus.Text = "No se seleccionó ningún archivo.";
                }
            }
        }

        // Método para cargar el contenido del archivo en el DataGridView
        private void CargarContenidoArchivo()
        {
            if (!string.IsNullOrEmpty(pFilePath))
            {
                try
                {
                    switch (pSelectedFileType)
                    {
                        case "CSV":
                            CargarCSV(pFilePath);
                            break;
                        case "XML":
                            CargarXML(pFilePath);
                            break;
                        case "RTF":
                            CargarRTF(pFilePath);
                            break;
                        case "TXT":
                            CargarTXT(pFilePath);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Error al cargar el archivo: {ex.Message}";
                }
            }
        }

        private void ResetForm()
        {
            pFilePath = string.Empty;
            dataGridView.DataSource = null;
            lblStatus.Text = "Formulario reiniciado. Selecciona un nuevo tipo de archivo.";
        }


        // Cargar datos desde un archivo CSV en el DataGridView
        private void CargarCSV(string filePath)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Contenido CSV"); // Añadir una única columna para mostrar el contenido del CSV

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Agregar cada línea completa en una sola columna
                        dataTable.Rows.Add(line);
                    }
                }

                dataGridView.DataSource = dataTable;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar el ancho de la columna
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al cargar el CSV: {ex.Message}";
            }
        }



        // Cargar datos desde un archivo XML en el DataGridView
        private void CargarXML(string filePath)
        {
            try
            {
                var dataSet = new DataSet(); // Crear un DataSet para cargar el XML

                // Cargar el archivo XML en el DataSet
                dataSet.ReadXml(filePath);

                // Verificar si hay tablas cargadas en el DataSet
                if (dataSet.Tables.Count > 0)
                {
                    // Asignar la primera tabla del DataSet al DataGridView
                    dataGridView.DataSource = dataSet.Tables[0];

                    // Ajustar el tamaño de las columnas al contenido
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.AutoResizeColumns();
                }
                else
                {
                    lblStatus.Text = "El archivo XML no contiene datos.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al cargar el XML: {ex.Message}";
            }
        }



        // Cargar datos desde un archivo RTF en el DataGridView
        private void CargarRTF(string filePath)
        {
            try
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Contenido RTF");

                using (RichTextBox rtfBox = new RichTextBox())
                {
                    // Cargar el archivo RTF en un RichTextBox
                    rtfBox.LoadFile(filePath, RichTextBoxStreamType.RichText);

                    // Obtener el texto sin formato
                    string plainText = rtfBox.Text;

                    // Dividir el texto en líneas y agregar cada línea como fila al DataTable
                    string[] lines = plainText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (var line in lines)
                    {
                        dataTable.Rows.Add(line);
                    }
                }

                // Asignar el DataTable al DataGridView
                dataGridView.DataSource = dataTable;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al cargar el RTF: {ex.Message}";
            }
        }




        // Cargar datos desde un archivo TXT en el DataGridView
        private void CargarTXT(string filePath)
        {
            var dataTable = new DataTable();
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    bool firstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Dividir la línea en palabras separadas por espacios o tabulaciones
                        var columns = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                        // Crear columnas en la primera línea
                        if (firstLine)
                        {
                            for (int i = 0; i < columns.Length; i++)
                            {
                                dataTable.Columns.Add($"Columna {i + 1}");
                            }
                            firstLine = false;
                        }

                        // Agregar las filas
                        dataTable.Rows.Add(columns);
                    }
                }

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al cargar el TXT: {ex.Message}";
            }
        }


        // Botones para crear, editar y borrar archivo
        private void cmdCrear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pFilePath))
            {
                SeleccionarArchivo(); // Llamar a SeleccionarArchivo para elegir el archivo si no se ha seleccionado
            }

            if (!string.IsNullOrEmpty(pFilePath))
            {
                CrearArchivo(); // Crear archivo vacío o basado en el DataGridView
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pFilePath))
            {
                SeleccionarArchivo(); // Llamar a SeleccionarArchivo para elegir el archivo si no se ha seleccionado
            }

            if (!string.IsNullOrEmpty(pFilePath))
            {
                EditarArchivo(); // Editar el archivo basado en el DataGridView
            }
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pFilePath))
            {
                BorrarArchivo(); // Llama a BorrarArchivo directamente
            }
            else
            {
                lblStatus.Text = "No se ha seleccionado ningún archivo para borrar.";
            }
        }

        // Crear un archivo en la ruta seleccionada
        private void CrearArchivo()
        {
            switch (pSelectedFileType)
            {
                case "CSV":
                    GuardarCSV(pFilePath);
                    break;
                case "XML":
                    GuardarXML(pFilePath);
                    break;
                case "TXT":
                    GuardarTXT(pFilePath);
                    break;
                case "RTF":
                    GuardarRTF(pFilePath);
                    break;
            }
            lblStatus.Text = $"{pSelectedFileType} creado exitosamente.";
        }

        // Editar el archivo existente (sobrescribir)
        private void EditarArchivo()
        {
            CrearArchivo(); // Sobrescribe el archivo
            lblStatus.Text = $"{pSelectedFileType} editado exitosamente.";
        }

        // Guardar el contenido del DataGridView en un archivo CSV
        private void GuardarCSV(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    // Escribir los encabezados
                    var columnNames = dataGridView.Columns.Cast<DataGridViewColumn>()
                                    .Select(column => column.HeaderText);
                    writer.WriteLine(string.Join(",", columnNames));

                    // Escribir las filas
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>()
                                        .Select(cell => cell.Value?.ToString());
                            writer.WriteLine(string.Join(",", cells));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al guardar el CSV: {ex.Message}";
            }
        }

        // Guardar el contenido del DataGridView en un archivo XML
        private void GuardarXML(string filePath)
        {
            try
            {
                var dataTable = new DataTable();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    dataTable.Columns.Add(column.HeaderText);
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var dataRow = dataTable.NewRow();
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            dataRow[i] = row.Cells[i].Value;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }

                var dataSet = new DataSet();
                dataSet.Tables.Add(dataTable);
                dataSet.WriteXml(filePath);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al guardar el XML: {ex.Message}";
            }
        }

        // Guardar el contenido del DataGridView en un archivo TXT
        private void GuardarTXT(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            writer.WriteLine(row.Cells[0].Value?.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al guardar el TXT: {ex.Message}";
            }
        }

        // Guardar el contenido del DataGridView en un archivo RTF
        private void GuardarRTF(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            writer.WriteLine(row.Cells[0].Value?.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al guardar el RTF: {ex.Message}";
            }
        }

        // Borrar el archivo seleccionado
        private void BorrarArchivo()
        {
            try
            {
                if (File.Exists(pFilePath))
                {
                    File.Delete(pFilePath);
                    dataGridView.DataSource = null; // Limpiar el DataGridView
                    lblStatus.Text = $"{pSelectedFileType} borrado exitosamente.";
                }
                else
                {
                    lblStatus.Text = "Archivo no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error al borrar el archivo: {ex.Message}";
            }
        }
    }
}