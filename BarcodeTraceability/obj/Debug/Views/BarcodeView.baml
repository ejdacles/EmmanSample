   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      S OLaborie.Synergy.Common, Version=1.0.2.113, Culture=neutral, PublicKeyToken=null_Dclr-namespace:Laborie.Synergy.Common;assembly=Laborie.Synergy.CommonLaborie.Synergy.Common 5      V RLaborie.Synergy.Common.UI, Version=1.0.2.113, Culture=neutral, PublicKeyToken=nullhJclr-namespace:Laborie.Synergy.Common.UI;assembly=Laborie.Synergy.Common.UILaborie.Synergy.Common.UI 5      ` \Laborie.Synergy.BarcodeTraceability, Version=1.0.2.113, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Laborie.Synergy.BarcodeTraceability.Views)Laborie.Synergy.BarcodeTraceability.Views 5	      m;clr-namespace:Laborie.Synergy.BarcodeTraceability.ViewModel-Laborie.Synergy.BarcodeTraceability.ViewModel 5
      e7clr-namespace:Laborie.Synergy.BarcodeTraceability.Model)Laborie.Synergy.BarcodeTraceability.Model 5      s>clr-namespace:Laborie.Synergy.BarcodeTraceability.Translations0Laborie.Synergy.BarcodeTraceability.Translations 5      o<clr-namespace:Laborie.Synergy.BarcodeTraceability.Converters.Laborie.Synergy.BarcodeTraceability.Converters 5      uOclr-namespace:Laborie.Synergy.Common.Converters;assembly=Laborie.Synergy.Common!Laborie.Synergy.Common.Converters 5      m;clr-namespace:Laborie.Synergy.BarcodeTraceability.Behaviors-Laborie.Synergy.BarcodeTraceability.Behaviors 5      uOclr-namespace:Laborie.Synergy.Common.Automation;assembly=Laborie.Synergy.Common!Laborie.Synergy.Common.Automation 5      yQclr-namespace:Laborie.Synergy.Common.HelpProvider;assembly=Laborie.Synergy.Common#Laborie.Synergy.Common.HelpProvider 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      ;   5Laborie.Synergy.BarcodeTraceability.Views.BarcodeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      WcommonDclr-namespace:Laborie.Synergy.Common;assembly=Laborie.Synergy.Common     5      YuiJclr-namespace:Laborie.Synergy.Common.UI;assembly=Laborie.Synergy.Common.UI     5      Ilocal7clr-namespace:Laborie.Synergy.BarcodeTraceability.Views     5	      Q	viewModel;clr-namespace:Laborie.Synergy.BarcodeTraceability.ViewModel     5
      Imodel7clr-namespace:Laborie.Synergy.BarcodeTraceability.Model     5      Vtranslation>clr-namespace:Laborie.Synergy.BarcodeTraceability.Translations     5      S
converters<clr-namespace:Laborie.Synergy.BarcodeTraceability.Converters     5      kcommonConverterOclr-namespace:Laborie.Synergy.Common.Converters;assembly=Laborie.Synergy.Common     5      UnumberTextBox;clr-namespace:Laborie.Synergy.BarcodeTraceability.Behaviors     5      f
automationOclr-namespace:Laborie.Synergy.Common.Automation;assembly=Laborie.Synergy.Common     5      bhelpQclr-namespace:Laborie.Synergy.Common.HelpProvider;assembly=Laborie.Synergy.Common     5      6sys&clr-namespace:System;assembly=mscorlib     5      1  +Laborie.Synergy.Common.HelpProvider.HelpIds    ConsumableTraceability.  (Laborie.Synergy.Common.HelpProvider.Help   HelpId# Z  5      {�5      �� *IsPatientSelected+ � 	Resources 5       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value	 �� 
TargetType
 �� 
Background �� Bullet    ButtonStyle.CommonGrayButton  DarkGrey  	LightGrey �� CornerRadius �� ContentStringFormat �� ContentStringFormat �� Triggers ]� 
Conditions �� Property �� Value  LaborieBlue  LowBackgroundBrush  MediumBorder1&clr-namespace:System;assembly=mscorlibSystem 5�        
dateFormat �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch �� 	Transform T� X T� Y !� Visual �� Empty  hintDate 	 CollectionViewSource �� Source �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyNameB  <Laborie.Synergy.BarcodeTraceability.Converters.DateConverter 
 dateConverterL  FLaborie.Synergy.BarcodeTraceability.Converters.ConsumableIconConverter  ConsumableIconConverterI  CLaborie.Synergy.BarcodeTraceability.Converters.StringEmptyConverter  StringEmptyConverterQ  KLaborie.Synergy.BarcodeTraceability.Converters.ConsumableLevelTypeConverter  ConsumableLevelConverter]  WLaborie.Synergy.BarcodeTraceability.Converters.ConsumableLevelTypeToVisibilityConverter ( $ConsumableLevelToVisibilityConverterV	  PLaborie.Synergy.Common.Converters.ButtonDisabledReasonTooltipVisibilityConverter 2 .ButtonDisabledReasonTooltipVisibilityConverter  DataGridControlTemplate1&
   System.Windows.Controls.DataGrid �� Padding  J� SnapsToDevicePixels! ��Name" � ColumnDefinitions# � RowDefinitions$ �� 
ResourceId% �� TypeInTargetAssembly& �� RelativeSource' �� AncestorLevel( �� AncestorType) �� Path* �� ConverterParameter7  1System.Windows.Controls.DataGridHeadersVisibilityG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter+  Name, ��Name- �� CanContentScroll. �� CanHorizontallyScroll/ �� CanVerticallyScroll0 ��Name1 �� ScrollableHeight2 � Maximum3 �� Orientation*4 �� #ComputedVerticalScrollBarVisibility5 �� ViewportHeight6 �� ViewportSize7 � Value8 �� Mode9 �� ScrollableWidth,: �� %ComputedHorizontalScrollBarVisibility; �� ViewportWidth��5      %�  '��       &	  �    7  7  7  7  7  &	 �    &	 �    &	 �    7  7  &		     &	
     &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    �� 5   
   " ��6*   CheckBoxStyle�� 5      P� 5       �@d�	IsChecked$
 trueY�6/   . �5      ��  � �� 5      �� 5      "	 ��6.   .R�5    "   �� 

 ����  5!   &   � 5"   *   $��13��6/   $��13��6:   .+�5#   .   �� $&�� /Images/ic_checkbox-selected.png��64   6`   5$   +   5&   #   5(      5*      5+      P� 5,       �@d�	IsChecked$ falseY�6/   . �5-      ��  � �� 5.      �� 5/      "	 ��6.   .R�50   "   �� 

 ����  51   &   � 52   *   $��13��6/   $��13��6:   .+�53   .   �� $��/Images/ic_checkbox.png��64   6X   54   +   56   #   58      5:      5;      5=      �� 5@   
   " ��65   .�5A      ��  � ��8   6,   �� 5B       � ��8  6+   �� 5C       � ��8  6,   �� 5D       � ��$ 1q�60   �� 5E       � �� . 6*   �� 5F       � ��$ Segoe UI Regular)�6+   �� 5G       � ��$ 14(�6)   �� 5H       �@J�SnapsToDevicePixels . 64   �� 5J       � �� 5K      �� 5L      "	 ��6&   .R�5M      �� $ 0��6!   #��z��5N   !   #��z��5O   !   #��z��5P   !   ._�5Q      �� #��z��6/   # z 5R   %   #��z��5S   %   #��z��5T   %   #��z��5U   %   5V       5W      ]� 5X       5Y   "   �� 5Z   &    �@��	IsDefault . 6F   �� 5[   &    �@J�IsMouseOver . 6H   ./�5]   "   ��  � �� �#c4c4c46Q   5^      ]� 5_       5`   "   �� 5a   &    �@��	IsDefault . 6F   �� 5b   &    �@J�IsMouseOver .  6H   ./�5d   "   �� 8   � ��6@   5e      P� 5f       �@J�IsMouseOver . . �5g   "   ��  � �� �#c4c4c46Q   5h      P� 5i       � �� . . �5j   "   ��  � �� �#4d4d4f6R   �� 5k   "    � �� �#c4c4c46Q   5l      P� 5m       � {� .  . �5n   "   ��  � �� �#ececec6Q   �� 5o   "   8   � ��6?   �� 5p   "    � �� �#ececec6R   5q      5s      5u      5v      ��5x   
   	White��6<   �� 5y   
   " ��6   .�5{      ��  � ��$ 1q�5|      �� 5}       � ��
 �����5~      �� 5       �@��CornerRadius$ 3��5�      5�      �� 5�   
   6sys&clr-namespace:System;assembly=mscorlib     5�      " ��5�       5�      ��!� 5�      hintDate $
 Left=�5�      $ Center=�5�      $
 None=�5�       5�      T� 5�      $ 0Q�6-   $ 0Q�5�   -   65    5�      � 5�      
�������$	��120��5�      $��25��5�      .+�5�      �� $��yy/mm/dd��6$   
�������$��Center=�5�   $   $��0,-5,0,0q�5�   $   5�      5�      5�       5�      P� 5�       � ��# Z 5�      . �5�      ��  � ��8   5�      5�      P� 5�       � �� 5�      Z� . �5�      ��  � ��8  5�      5�      5�      �� 5�   
    6<   �� *BarcodeList+ 5�        5�      $ QualifyLevelType��6+   5�        5�   
   6#     5�   
   6-     5�   
   6*     5�   
   62     5�   
   6>   	  5�   
   6I   �� 5�   
   "	 
 6;   .R�5�      �� #��z��6   #��z��6A   
������ # z��6�     . ._�5�      �� $! DG_ScrollViewer��6   |�.  ��5�      �� 5�      "	 ��6*   .R�5�      � " 5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   # 5�   "   �� 5�   &   $
��Auto �64   �� 5�   &   $��* �64   �� 5�   &   $
��Auto �64   .+�5�   "   �� $#��ApplicationCommands.SelectAll��6)   |�.  ��6c   C� *�� $"$ DataGridSelectAllButtonStyle��"% 
 +��6�   �� *CellsPanelHorizontalOffset+& �� *FindAncestor+$' 1��"( 
 y�5�   &   �� 5�   *   $) HeadersVisibility�62   & 6K   �� *FindAncestor+$' 1��"( 
 * 5�   .    5�   2   All=�6Q   5�   +   5�   #     5�   "   $!+ PART_ColumnHeadersPresenter��6A   $��1��6f   y�5�   &   �� 5�   *   $) HeadersVisibility�62   & 6K   �� *FindAncestor+$' 1��"( 
 * 5�   .    5�   2   
Column=�6T   5�   +   5�   #   �� 5�   "   $!, PART_ScrollContentPresenter��69   #- z��6^   . .  $��2��6�   / .  #��z��6�   #��z��6  # z 6:  $��1��6v  �� 5�   "   $0 PART_VerticalScrollBar��6,   $��2��6L   #2 z1 6\   $3 Vertical=�6�   $��1��6�   #y�z4 6�   #6 z5 6O  7 6�   �� *VerticalOffset+$8 OneWay=�& �� *TemplatedParent+6O  � 5�   "   $��1��6'   $��2��67   " 5�   &   �� 5�   *   ��6;   �� **(NonFrozenColumnsViewportHorizontalOffset+& �� *FindAncestor+$' 1��"( 
 �� 5�   *   $��* �6;   .+�5�   &   �� $0 PART_HorizontalScrollBar��60   $��1��6R   #2 z9 6b   $3 
Horizontal=�6�   #y�z: 6�   #6 z; 6M  7 6�   �� *HorizontalOffset+$8 OneWay=�& �� *TemplatedParent+6M  5�   #   5�      5�      .��5�      �� #  z  6%   5�      5�      5�      5�      .��5�      �� $��0,0,0,0q�6   $��0q�5�      #��[ 5�      #��[ 5�      ._�5�   
   � # 5�      �� 5�      $��* �6    �� 5�      $��42 �6    �� 5�      $
��Auto �6    .+�5�      �� -   5        $! ScrollViewer��5�      $
��Auto=�61   #��[ 6T   $��0,0,0,1q�6}   $��	0,0,-17,5q�6�   $��0��6�   .��5�      � $��0,0,0,0q�6   # 5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   " 5�      �� 5�      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5     $��* �6+   .+�5     �� -   5        $��StackPanel1��5  !   $��1��64   $��0��6A   $��3��6Q   $��0,2,0,0q�6e   .+�5     � $��6,0,5,0q�6   # 5     �� 5  "   $
��Auto �60   �� 5  "   $
��Auto �60   �� 5	  "   $
��Auto �60   �� 5
  "   $
��Auto �60   " 5     �� 5  "   $
��Auto �63   �� 5  "   $
��Auto �63   �� 5  "   $��* �63   .+�5     �� $��1��6$   $��3��5  #   $��	01,-7,0,0q�67   $��0��6J   ?  9Laborie.Synergy.BarcodeTraceability.Translations.Language<   Label_Consumables#��Z< 5  #   $
��Left=�5  #   ���#4D4D4F$��Segoe UI Semibold)�6Z   $��14(�6y   �� 5     $��2��6+   $��3��5  +   $��0��6?   $��30��5  +   $��	0,8,-15,0q�6:   ��5  +   �� *RequiredConsumables+��5  "   �� 5  &   .R�5  *   � " 5  .   �� 5  2   $
��Auto �6C   �� 5  2   $
��Auto �6C   �� 5   2   $	��184 �6C   �� 5!  2   $
��Auto �6C   �� 5"  2   $	��145 �6C   .+�5%  .   �� $��0��65   $��40��6E   $��25��5&  4   $��03,0,0,0q�5'  4   #��[ 6G   $��0,0,0,1q�6p   $
��Left=�6�   ._�5(  2   �� $��0��68   $��13��5)  8   $��13��5*  8   $��0q�5+  8   $
��Left=�5-  8   ��5(  H   �� $) DisplayImagePath�4  .System.Windows.Automation.AutomationProperties=   AutomationId= 5,  8   �� $) 	IsScanned�> �� StringFormat$> CScanned_{0}��5-  8   5.  /   �� 50  .   $��2��64   $��0,0,0,0q�6D   $��0,0,0,0q�6U   #��[ 52  �   $��0,0,0,1q�6�   $��Center=�6�   $
��Left=�6  ���#4D4D4F$��Segoe UI Regular)�6>  $��13(�6\  ��51  4   �� $) ChannelName�= 52  4   �� $") RequiredCategory.ChannelType�$> ChannelName_{0}��6\  �� 53  .   $��3��65   $��40��6E   $	��268��6Q   $��0,0,0,0q�54  5   #��[ 6G   $��0,0,0,1q�6p   $��Right=�6�   ._�55  2   �� $��3��68   $��40��57  8   $	��130��6D   $
��Fill=�6P   $��-1,0,0,0q�58  8   $��Right=�6J   ��56  8   �� $) RequiredCategory.Category�? �� 	Converter#? [ 58  J   59  /   �� 5;  .   $��4��64   #��[ 5=  �   $��0,0,0,1q�6�   $��Center=�6�   $
��Left=�6�   ���#4D4D4F$��Segoe UI Regular)�65  $��14,0,0,0q�6S  $��0,0,0,0q�6f  $��11(�6w  ��5<  4   �� $) CategoryName�= 5=  4   �� $) RequiredCategory.Category�$> 	CName_{0}��6w  5>  +   5?  '   5A     �� 5B     $��3��6%   $��0��62   $��3��6B   $
��5,20q�6V   $��2q�6d   $ 5��6x   ���	#FF139E13._�5C  "   �� @ �� Orientation$@ 
Horizontal=�6-   $��Center=�6F   .+�5D  &   �� $��5q�6-   $��Right=�68   $K��E/Laborie.Synergy.BarcodeTraceability;component/Resources/rfidscan.png��6U   $
��Fill=�6�   $
��40px��6�   $
��52px��6�   �� 5E  &   5  /Laborie.Synergy.Common.Automation.AutomationIdsA   ScanningMessage#= ZA 60   B   IsScanningMessage#��ZB 6�   $��Center=�6�   $��20(�6�   5F  #   ��5G  "   �� 5H  &   .�5I  *   ��  � y�$ 	Collapsed=�6N    5J  *   �� 5K  .   C �� BindingC 6:   �� *DisplayScanningMessage+D �� ValueD true6e   .a�5L  2   ��  � y�$ Visible=�6V   5M  /   5O  '   5Q     5R     5S     -  'Laborie.Synergy.Common.UI.SmartDataGrid  5T     $��2��6'   $��3��64   $��0��6H   $��
3,22,-12,0q�5U  '   E 
  SelectionMode$E Single=�5V  '   #��[ 6>   $��0,0,0,1q�6g   F 
  
IsReadOnlyF . G 
  VerticalGridLinesBrush
G ���� H   BarcodeGrid#= ZH 5Y  '   #���  6{   $	��325��6�   ��5X  '   �� I �� Source#I [	 J 
  ColumnsJ 5Z     4  .System.Windows.Controls.DataGridTemplateColumn  5[     ,  &System.Windows.Controls.DataGridColumnK   
VisibilityK 65   �� $) 
Visibility�& �� *FindAncestor+"( >�L   CellTemplateL 5\  "   �� 5]  &   .R�5^  *   �� 
������ $��0q�6K   $��Center=�6_   $	��Top=�6|   |�.  
������ $��-5 -8q�5c  1   M   Tooltip_RemoveConsumableN � ToolTip#N ZM 6A   ��5_  1   �� $&)  DataContext.RemoveBarcodeCommand�& �� *FindAncestor+"( 
 ��5`  1   �� $) 	BarCodeId�= 5a  1   �� $) 	BarCodeId�$> DeleteBarcode_{0}��y�5d  1   �� $) QualifyLevelType�#? [ .��5e  .   (� $��32��66   $��32��6B   .��5f  2   �� $��76��69   $��76��6D   O J� Clip4O ��        � ��    � �� ���     ���        .+�5h  6   F� $��27.7083��6;   $��35.625��6K   P �� Left$P 24.1458��5i  G   
Q �� Top$Q 19.7917��6]   R �� Stretch$
R Fill=�5j  G   
������������4��pej��pej�ltpej;t��;t��шopt��ӈopt���6upej4��pej�(�T�-��hT�-Ө�nT�-�;�H|?�;�(FӜ;���L��n@Q^�h@Q^�(�@Q^�X�@Q^ o��L o(F� oH|?X�T�-(�T�-��˦ ���� ��7� �8�D��8�H	�����n5���X�BP�|�ML��|�MѴ��|�MӰ��|�M�˦X�B�˦�n5�Ȣ�H	��Ȣ�D���s� ��˦ ����2��`��E��Z��EѸP�2����2��+2�Ѽ�+�E�D�[�E�D�[2�Ѽ�+2��HZ�2��0P��EѠ���E���2��HZ�2�5k  G   5l  3   5m  /   5n  +   5o  '   5q     S 
  ColumnHeaderStyleS 5s     �� 5t     =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5v  "   ��  �@�ContextMenu 5w  &   �� 5x  *   $y�	Collapsed=�66   @�5y  .   m� 5z  2   ��5{  6   �� 5|  :   $@ 
Horizontal=�6E   .+�5}  >   �� 
���**��	Column...6f   5~  ;   .@�5�  6   m� $��to Info��6?   6R   m� 5�  6   $
��Hide��6?   6O   5�  3   5�  +   5�  #   5�     T �� 
GroupStyleT 5�     (  "System.Windows.Controls.GroupStyle  5�     U   ContainerStyleU 5�  "   �� 5�  &   " ��6,   .�5�  *   ��  � ��$ 0,0,0,5q�6C   �� 5�  *    � �� 5�  .   �� 5�  2   "	 ��6B   .R�5�  6   �� .+�5�  :   �� $
��Bold"�6�   $��5,5,5,5q�6�   ��6D   �� *Name+#? [ 6�   �� 5�  :   5�  7   5�  3   5�  +   5�  '   5�      5�     V �� BasedOn*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow��%�  '��       7��'  �     '      �� 5�     " ��6$   8V   .�5�  "   ��  � ��$ 14(�6=   �� 5�  "    � ��$
 Left=�6H   �� 5�  "    � ��$ Segoe UI SemiBold)�6?   �� 5�  "    � ��
 � � �6?   5�     �� 5�     "  6$   .�5�  "   ��  � ��
 ���� 6?   �� 5�  "    � ��
 ���� 6@   �� 5�  "    � ��
 �   �6?    5�  "   P� 5�  &    �@ 
IsSelected . . �5�  *   ��  � ��
 ���� 6G   �� 5�  *    � ��
 ���� 6H   �� 5�  *    � ��
 �   �6G   5�  '   5�     �� 5�     "  6$   .�5�  "   ��  � ��
 ���� 6?   �� 5�  "    � ��
 ���� 6@   �� 5�  "    � ��
 �   �6?    5�  "   P� 5�  &    �@ 
IsSelected . . �5�  *   ��  � ��
 ���� 6G   �� 5�  *    � ��
 ���� 6H   �� 5�  *    � ��
 �   �6G   5�  '   5�     5�     5�     �� 5�     W   ArbitraryAdd#= ZW 6   $��3��5�     $��2��5�     $	��200��5�     $��32��5�     $X   Action_AddArbitraryConsumable#��ZX 5�     $	��Top=�5�     $��Right=�5�     $��	5,15,25,0q�5�     $y�Visible=�60   #��[  6E   ��5�     �� $) AddArbitraryCommand�5�     �� 5�     $��	5,10,10,5q�6   $��4��5�     $��0��6*   $��3��6:   y�5�  2   �� *ShowArbitrary+.��5�     � # 5�     �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   �� 5�  "   $
��Auto �60   " 5�     �� 5�  "   $
��Auto �63   �� 5�  "   $��* �63   .+�5�     �� Y   Label_Identifier#��ZY 6$   $��0��5�  (   $��0��5�  (   �� 5�     $��1��6$   $��0��5�  (   Z   Label_CategoryName#��ZZ 5�  (   $ {0} :��5�  (   $��Center=�5�  (   $��Right=�5�  (   �� 5�     -   5        [ ��Name$[ ArbitraryCategoryName��5�  *   \   ArbitraryName#= Z\ 5�  &   $��1��5�  *   $��1��5�  *   ] �� 	MaxLength$] 50��5�  *   $	��200��5�  *   $��5,0,5,0q�5�  *     MidGrey#��[ 5�  *   $��1q�6Q   ��5�  *   �� *ArbitraryName+$8 TwoWay=�^ �� UpdateSourceTrigger$^ PropertyChanged=�5�  Q   �� 5�     $��2��6$   $��0��5�  (   _   Label_ConsumableType#��Z_ 5�  (   $ {0} :��5�  (   $��Center=�5�  (   $��Right=�5�  (   �� 5�     -   5        $[ ArbitraryTypeName��5�  *   `   ArbitraryType#= Z` 5�  &   $��2��5�  *   $��1��5�  *   $] 50��5�  *   $	��200��5�  *   $��5,0,5,0q�5�  *   #��[ 5�  *   $��1q�6Q   ��5�  *   �� *ArbitraryType+$8 TwoWay=�$^ PropertyChanged=�5�  Q   �� 5�     $��3��6$   $��0��5�  (   a   Label_Expiry_Date#��Za 5�  (   $ {0} :��5�  (   $��Center=�5�  (   $��Right=�5   (   � 5     $��3��6#   $��1��60   .+�5  "   �� b J� IsHitTestVisibleb .  $��5,0,5,0q�5  -   c �� Padding$c 5,0,0,0q�5  -   
���������5  -   �� *DateFormatAsPerLocalCulture+5  -   �� 5
  "   -   5        $[ ArbitraryExpiryDate��5  *   d   ArbitraryExpiry#= Zd 5
  *   $] 10��5  *   $	��200��5  *   #��[ 5  *   $��1q�5  *   $��5,0,5,0q�5  *   ��5  *   �� *ArbitraryExpiryDate+$8 TwoWay=�$^ PropertyChanged=�.��5  ;   ��5  &   �� 5  *   " ��60    5  .   P� 5  2    � ��# Z 6J   . �5  6   ��  � ��
 ���� 6S   5  3   P� 5  2    � �� 6J   Z� . �5  6   ��  � ��
 ���� 6S   5  3   5  +   .��5  5   5  #   5       �� 5"     $��4��6$   $��0��5#  (   e   	Label_Lot#��Ze 5$  (   $ {0} :��5%  (   $��Center=�5&  (   $��Right=�5'  (   �� 5(     -   5        $[ ArbitraryLot��5)  *   f   ArbitraryLot#= Zf 5(  &   $��4��5*  *   $��1��5+  *   $] 20��5,  *   $	��200��5.  *   $��5,0,5,0q�5/  *   #��[ 50  *   $��1q�6Q   ��5-  *   �� *ArbitraryLot+$8 TwoWay=�50  Q   �� 52     $��5��6$   $��0��53  (   g   Label_Serial#��Zg 54  (   $ {0} :��55  (   $��Center=�56  (   $��Right=�57  (   �� 58     -   5        $[ ArbitrarySerial��59  *   h   ArbitrarySerial#= Zh 58  &   $��5��5:  *   $��1��5;  *   $] 20��5<  *   $	��200��5>  *   $��5,0,5,0q�5?  *   #��[ 5@  *   $��1q�6Q   ��5=  *   �� *ArbitrarySerial+$8 TwoWay=�5@  Q   � 5A     $��6��6#   $��0��60   $��2��6@   " 5B  "   �� 5C  &   $	��.8* �67   �� 5D  &   $	��.2* �67   .+�5F  "   �� i   ArbitraryErrorMessage#= Zi 6,   $��0��5G  1   $	��450��5H  1   $��0,5,5,5q�5I  1   $
��Left=�5J  1   $��Center=�5K  1   
���  ��$��Italic$�5M  1   $
��Wrap=�5O  1   ��5N  1   �� *ArbitraryErrorMessage+$8 TwoWay=�5O  1   �� 5P  "   j   ArbitrarySave#= Zj 6)   $��1��5Q  -   $��50��5R  -   $��25��5S  -   k   Action_Save#��Zk 5U  -   $	��Top=�5V  -   $��Right=�5W  -   $��0,5,4,5q�5X  -   ��5T  -   �� $) SaveArbitraryCommand���5Y  &   �� 5Z  *   " ��60   .�5[  .   ��  � {� .  6J    5\  .   ^� 5]  2   l ^� 
Conditionsl 5^  6   �� 5_  :   m �� Bindingm 6D   �� $
) Text�n �� ElementName$n ArbitraryCategoryName��#? [ 	 False6�   .0�5a  6   ��  � {� . 6R   5b  3   ^� 5c  2   l 5d  6   �� 5e  :   m 6D   �� $
) Text�$n ArbitraryTypeName��#? [ 	 False6�   .0�5g  6   ��  � {� . 6R   5h  3   ^� 5i  2   l 5j  6   �� 5k  :   m 6D   �� $
) Text�$n ArbitraryLot��#? [ 	 False6�   .0�5m  6   ��  � {� . 6R   5n  3   ^� 5o  2   l 5p  6   �� 5q  :   m 6D   �� $
) Text�$n ArbitrarySerial��#? [ 	 False6�   .0�5s  6   ��  � {� . 6R   5t  3   ^� 5u  2   l 5v  6   �� 5w  :   m 6D   �� $
) Text�$n ArbitraryExpiryDate��#? [ 	 False6�   .0�5y  6   ��  � {� . 6R   5z  3   5|  +   5~  #   5     5�     5�     �� 5�     $��5��6   $��0��6*   $��3��6:   $��	5,10,10,5q�6N   $��2q�5�     $ 5��61   
���  ��y�6T   �� *ErrorMessageVisibility+._�5�     �� $��0��6$   $��5,5,5,5q�5�     $
��Left=�5�     $��Center=�5�     
���  ��$��Italic$�5�     $
��Wrap=�5�     o   ConsumableErrorMessage#= Zo 5�     ��5�     �� *ConsumableErrorMessage+5�     5�     5�     5�     �� 5�     -   5        p   BarcodeBypass#= Zp 5�     $��1��5�     $��Bottom=�5�     $��Right=�5�     $��0,5,10,0q�5�     #��[  5�     $��32��5�     $	��134��5�     ��5�     �� $) BypassCommand���5�     �� *
BypassText+{�5�     �� *IsEnabledBypass+y�5�     �� *IsBypassVisible+q ^� ShowOnDisabledq 5�     �� *IsEnabledBypass+#? [ $* IsEnabledBypass��r ^� 	IsEnabledr 5�     �� *IsEnabledBypass+#? [ $* IsEnabledBypass��N 5�     �� 5�     $��-8,-3,-7,-3q�6   $ 10q�62   ���#f4f6f9s J� BitmapEffects 5�     O� 5�     66   ._�5�     �� ��6$   �� *ButtonDisabledReason+$8 TwoWay=�$^ PropertyChanged=�5�     5�     �� 5�     $��2��6   $��0��6"   $
��5,20q�62   $��2q�6@   $ 5��6T   ���	#FF139E13._�5�     �� $@ 
Horizontal=�6   $��Center=�66   .+�5�     �� $��5q�6   $��Right=�6(   $N��H/Laborie.Synergy.BarcodeTraceability;component/Resources/green-check.png��6E   $
��Fill=�6�   $
��32px��6�   $
��32px��6�   �� 5�     t   BypassConsumableMessage#= Zt 6    u   ConsumableBypass#��Zu 6�   $��Center=�6�   5�     ��5�     �� 5�     .�5�     ��  � y�$ 	Collapsed=�6>    5�     �� 5�     C 6*   �� *DisplayBypassMessage+D true6S   .a�5�  "   ��  � y�$ Visible=�6F   5�     5�     5�     5�     5�     5�     