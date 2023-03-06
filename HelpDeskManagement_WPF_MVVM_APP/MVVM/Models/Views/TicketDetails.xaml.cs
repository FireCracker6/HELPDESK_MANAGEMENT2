using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.ViewModels;
using HelpDeskManagement_WPF_MVVM_APP.Services;

namespace HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views
{
    /// <summary>
    /// Interaction logic for TicketDetails.xaml
    /// </summary>
    public partial class TicketDetails : UserControl
    {
     
        private readonly UserService _userService;
        private readonly Guid _userId;
        public string PageTitle2 { get; set; }

        public TicketDetails(Guid userId)
        {
            InitializeComponent();
            _userService = new UserService();
            _userId = userId;

            // Create an instance of the TicketDetailModel and set it as the DataContext
            var ticketDetailModel = new TicketDetailModel();
            DataContext = ticketDetailModel;

            // Set the SelectedId property of the TicketDetailModel
            ticketDetailModel.SelectedId = userId;

            // Load the ticket details and set them on the TicketDetailModel
            LoadTicketDetails(userId);
        }
        private async Task LoadTicketDetails(Guid userId)
        {
            // Retrieve the ticket details for the user
            var tickets = await _userService.GetAsync(t => t.Id == userId);

            // Set the ticket details on the TicketDetailModel
            var ticketDetailModel = (TicketDetailModel)DataContext;
            ticketDetailModel.Tickets = new ObservableCollection<TicketModel>((IEnumerable<TicketModel>)tickets);
        }


        private void ShowDefaultView()
        {
            // Get a reference to the Frame control that hosts this UserControl
            var frame = (Frame)Window.GetWindow(this).FindName("myFrame");

            // Navigate to the default view
            frame.Navigate(typeof(TicketsView));
        }

        private async Task ShowUser(Guid userId)
        {
            var item = await _userService.GetAsync(x => x.Id == userId);
            Debug.WriteLine(item.FirstName);

            // set the item as the DataContext of the UserControl
            this.DataContext = item;
            ((TicketDetailModel)this.DataContext).SelectedId = userId;

            // Set the ItemsSource property of the DataGrid control
            var ticketService = new UserService();
            var tickets = await ticketService.GetAsync(t => t.Id == userId);
            _myDetailsDataGrid.ItemsSource = (IEnumerable)tickets;
        }



    }

}

