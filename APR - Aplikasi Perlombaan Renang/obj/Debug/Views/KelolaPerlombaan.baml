   M S B A M L   `   `   `  ����[  WAPR - Aplikasi Perlombaan Renang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:APR___Aplikasi_Perlombaan_Renang.Views&APR___Aplikasi_Perlombaan_Renang.Views  5      =    7APR___Aplikasi_Perlombaan_Renang.Views.KelolaPerlombaan   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:APR___Aplikasi_Perlombaan_Renang.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��Center=�6@   $��10q�6[   ���#1F7811��6   �� *BuatPerlombaanPageOpen+.��6|   Buat Perlombaan Baru6�   5      �� 5   
   $��1��6    �� Padding$ 10q�6   ._�5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     
IsReadOnly . ��6   �� *ListPerlombaan+ �� SelectedItem 6l   �� *SelectedPerlombaan+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Nama Lomba��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *NamaPerlombaan+  5      $ Tanggal Perlombaan��6)    6E   �� *TanggalPerlombaan+	 �� StringFormat$	 D��4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Edit��6-   
   CellTemplate
 5      �� 5      .R�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� ��6-   �� *$"DataContext.EditPerlombaanPageOpen+ �� RelativeSource ��  �� AncestorType$ UserControlL���6�   �� .��6�   
Edit Lomba6�   �� 5   &   ��6-   �� *!DataContext.KelolaAcaraPageOpen+ �� $ UserControlL���6�   �� .��6�   
Edit Acara6�   5   #   5      5      5!      5"      5$      5%      