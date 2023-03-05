using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using HelpDeskManagement_WPF_MVVM_APP.Services;

namespace HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views
{
    /// <summary>
    /// Interaction logic for TicketsView.xaml
    /// </summary>
    public partial class TicketsView : UserControl
    {
       // private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Svart\Source\Repos\Webbutveckling\HelpDeskManagement_WPF_MVVM_APP\HelpDeskManagement_WPF_MVVM_APP\Contexts\sql_HelpDesk_DB.mdf;Integrated Security=True;Connect Timeout=30";
       // private readonly DataContext _context = null!;
       // private FrameworkElementFactory factory = new FrameworkElementFactory(typeof(TextBox));
       // private string firstName = string.Empty;
        private readonly UserService _userService;


        public TicketsView()
        {
            InitializeComponent();
            _userService = new UserService();

                ShowAllUsers();
                ShowAllTickets();
           
        }
        private async Task ShowAllUsers()
        {
            var userService = new UserService(); 
            var users = await userService.GetAllAsync();
            myDataGrid.ItemsSource = users;
        }
        private async Task ShowAllTickets()
        {
            var ticketService = new TicketUserService();
            var tickets = await ticketService.GetAllAsync();
            myTicketDataGrid.ItemsSource = tickets;
        }
       

        
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           
            var user = ((FrameworkElement)sender).DataContext as UsersEntity;

            if (user != null)
            {
                await _userService.DeleteAsync(user.Id);

                await ShowAllUsers();
            }
        }

        private async void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            UsersEntity editedRow = (UsersEntity)((DataGrid)sender).SelectedItem;

            // Get the updated values from the edited cell
            string propertyName = e.Column.SortMemberPath;
            object editedValue = ((TextBox)e.EditingElement).Text;

            // Update the entity with the new values
            PropertyInfo property = editedRow.GetType().GetProperty(propertyName) ?? null!;
            if (property != null)
            {
                property.SetValue(editedRow, Convert.ChangeType(editedValue, property.PropertyType));
                await _userService.UpdateRecordAsync(editedRow, editedRow.Id);
            }
        }





    }
}
