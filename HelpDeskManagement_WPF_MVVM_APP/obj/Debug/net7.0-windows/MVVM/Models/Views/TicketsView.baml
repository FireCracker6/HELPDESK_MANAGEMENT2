   M S B A M L   `   `   `  ????Z  VHelpDeskManagement_WPF_MVVM_APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.ViewModels6HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.ViewModels  5      u?clr-namespace:HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views1HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views  5	      u?clr-namespace:HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views1HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views  5
      C    =HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views.TicketsView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      [
viewmodelsDclr-namespace:HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.ViewModels     5      Qviews?clr-namespace:HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views     5	      Qlocal?clr-namespace:HelpDeskManagement_WPF_MVVM_APP.MVVM.Models.Views     5
      .??5      ? $??40q?6     ? RowDefinitions  5   
   ?? 5      $
??auto ?6   ?? 5      ?? 5      $
??auto ?6   .+?5   
   ?? $??0??6   $??22(?6<   $??Medium"?6J   $??0 0 0 20q?6^   ??6!   ?? *	PageTitle+6^   ? 5   
   $??1??6     5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5$      ?   5%      ?? 5&      ?? 5'      ?? 5(      ?? 5)      ?? 5*      ?? 5+      ?? 5,      .+?50      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid??50      $??1??6/   $??20q?6<      AutoGenerateColumns$ False??6I      CanUserAddRows$ false??6?    ? 	Resources 51      *  $System.Windows.Controls.DataGridCell ?? 
TargetType ?? Property ?? Value??%Q   '        ?? 52      "  6    .?53      ??  ? ??$ 7q?68   54      55         ColumnHeaderStyle 56      ?? 57      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .?58      ??  ? ??$
 Bold"?6<   ?? 59       ? ??
 ??? ?6;   ?? 5:       ? ??$ 7q?68   ?? 5;       ? ??$ Center=?6D   ?? 5<       ? ??$ Center=?6K   ?? 5=       ? ??$ Stretch=?6D   ?? 5>       ? ??$ Center=?6K   5?      	   Columns	 5B      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 280 6.      Header$ User ID??6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   ?? *Id+  5G      $
 * 6-   $ 
First Name??68    6L   ?? *	FirstName+  5H      $
 * 6-   $ 	Last Name??67    6J   ?? *
LastName+  5I      $
 * 6-   $ Email-Address??67    6N   ?? *Email+  5J      $	
 100 6-   $ Phone Number??69    6O   ?? *PhoneNumber+  5K      $
 * 6-   $ 
Created At??67    6K   ?? *	CreatedAt+4  .System.Windows.Controls.DataGridTemplateColumn  5N      $ Remove User??61      CellTemplate 5P      ?? 5R   "   .R?5T   &   ?? -   5        $??2q?5T   -   $??5q?69   $	??100??6_   .??6k   Remove Client6z   5U   #   5X        5Y      $ Show Details??61    5Z      ?? 5[   "   .R?5\   &   ?? -   5        $??2q?5\   -   $??5q?69   $	??100??6D   $??View Details??6P   6g   5]   #   5_      5e        5g      -   5        $ myTicketDataGrid??5g      $??5??65   $??20q?6B   $ False??6O   $ false??6?    5h      ??%Q   '        ?? 5i      "  6    .?5j      ??  ? ??$ 7q?68   5k      5l       5m      ?? 5n      "  6    .?5o      ??  ? ??$
 Bold"?6<   ?? 5p       ? ??
 ??? ?6;   ?? 5q       ? ??$ 7q?68   ?? 5r       ? ??$ Center=?6D   ?? 5s       ? ??$ Center=?6K   ?? 5t       ? ??$ Stretch=?6D   ?? 5u       ? ??$ Center=?6K   5v      	 5y        5}      $	
 100 6.   $ 	Ticket ID??6;    6N   ?? *Id+  5~      $	
 280 6.   $ User ID??6;    6L   ?? *	UsersId+  5      $
 * 6.   $ User ID??69    6J   ?? *Title+  5?      $	
 150 6.   $ Ticket Category??6;    6T   ?? *TicketCategory+  5?      $
 * 6-   $ Description??68    6M   ?? *Description+  5?      $
 * 6-   $ 
Created At??67    6K   ?? *	CreatedAt+  5?      $	
 150 6-   $ Last Updated At??69    6R   ?? *LastUpdatedAt+  5?      $	
 100 6-   $ 	Closed At??69    6L   ?? *
ClosedAt+  5?      $ Remove Ticket??61    5?      ?? 5?   "   .R?5?   &   ?? -   5        $??2q?5?   -   $??5q?69   $	??100??6_   
???????$??1q?6?   
???z???.??6?   Remove Ticket6?   5?   #   5?      5?      5?      5?      ? 5?   
   $??1??6   .+?5?       ? -   5          ?Name$ myFrame??5?      5?      5?      5?      