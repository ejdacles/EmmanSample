   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  S OLaborie.Synergy.Common, Version=1.0.2.113, Culture=neutral, PublicKeyToken=null_Dclr-namespace:Laborie.Synergy.Common;assembly=Laborie.Synergy.CommonLaborie.Synergy.Common V RLaborie.Synergy.Common.UI, Version=1.0.2.113, Culture=neutral, PublicKeyToken=nullhJclr-namespace:Laborie.Synergy.Common.UI;assembly=Laborie.Synergy.Common.UILaborie.Synergy.Common.UI ` \Laborie.Synergy.BarcodeTraceability, Version=1.0.2.113, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Laborie.Synergy.BarcodeTraceability.Views)Laborie.Synergy.BarcodeTraceability.Views m;clr-namespace:Laborie.Synergy.BarcodeTraceability.ViewModel-Laborie.Synergy.BarcodeTraceability.ViewModel e7clr-namespace:Laborie.Synergy.BarcodeTraceability.Model)Laborie.Synergy.BarcodeTraceability.Model s>clr-namespace:Laborie.Synergy.BarcodeTraceability.Translations0Laborie.Synergy.BarcodeTraceability.Translations o<clr-namespace:Laborie.Synergy.BarcodeTraceability.Converters.Laborie.Synergy.BarcodeTraceability.Converters uOclr-namespace:Laborie.Synergy.Common.Converters;assembly=Laborie.Synergy.Common!Laborie.Synergy.Common.Converters m;clr-namespace:Laborie.Synergy.BarcodeTraceability.Behaviors-Laborie.Synergy.BarcodeTraceability.Behaviors uOclr-namespace:Laborie.Synergy.Common.Automation;assembly=Laborie.Synergy.Common!Laborie.Synergy.Common.Automation yQclr-namespace:Laborie.Synergy.Common.HelpProvider;assembly=Laborie.Synergy.Common#Laborie.Synergy.Common.HelpProvider O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem ;   5Laborie.Synergy.BarcodeTraceability.Views.BarcodeView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     WcommonDclr-namespace:Laborie.Synergy.Common;assembly=Laborie.Synergy.Common     YuiJclr-namespace:Laborie.Synergy.Common.UI;assembly=Laborie.Synergy.Common.UI     Ilocal7clr-namespace:Laborie.Synergy.BarcodeTraceability.Views     Q	viewModel;clr-namespace:Laborie.Synergy.BarcodeTraceability.ViewModel     Imodel7clr-namespace:Laborie.Synergy.BarcodeTraceability.Model     Vtranslation>clr-namespace:Laborie.Synergy.BarcodeTraceability.Translations     S
converters<clr-namespace:Laborie.Synergy.BarcodeTraceability.Converters     kcommonConverterOclr-namespace:Laborie.Synergy.Common.Converters;assembly=Laborie.Synergy.Common     UnumberTextBox;clr-namespace:Laborie.Synergy.BarcodeTraceability.Behaviors     f
automationOclr-namespace:Laborie.Synergy.Common.Automation;assembly=Laborie.Synergy.Common     bhelpQclr-namespace:Laborie.Synergy.Common.HelpProvider;assembly=Laborie.Synergy.Common     6sys&clr-namespace:System;assembly=mscorlib     1  +Laborie.Synergy.Common.HelpProvider.HelpIds    ConsumableTraceability.  (Laborie.Synergy.Common.HelpProvider.Help   HelpId# Z  {��� *IsPatientSelected+ � 	Resources  �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value	 �� 
TargetType
 �� 
Background �� Bullet    ButtonStyle.CommonGrayButton  DarkGrey  	LightGrey �� CornerRadius �� ContentStringFormat �� ContentStringFormat �� Triggers ]� 
Conditions �� Property �� Value  LaborieBlue  LowBackgroundBrush  MediumBorder1&clr-namespace:System;assembly=mscorlibSystem   
dateFormat �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch �� 	Transform T� X T� Y !� Visual �� Empty  hintDate 	 CollectionViewSource �� Source �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyNameB  <Laborie.Synergy.BarcodeTraceability.Converters.DateConverter 
 dateConverterL  FLaborie.Synergy.BarcodeTraceability.Converters.ConsumableIconConverter  ConsumableIconConverterI  CLaborie.Synergy.BarcodeTraceability.Converters.StringEmptyConverter  StringEmptyConverterQ  KLaborie.Synergy.BarcodeTraceability.Converters.ConsumableLevelTypeConverter  ConsumableLevelConverter]  WLaborie.Synergy.BarcodeTraceability.Converters.ConsumableLevelTypeToVisibilityConverter ( $ConsumableLevelToVisibilityConverterV	  PLaborie.Synergy.Common.Converters.ButtonDisabledReasonTooltipVisibilityConverter 2 .ButtonDisabledReasonTooltipVisibilityConverter  DataGridControlTemplate1&
   System.Windows.Controls.DataGrid �� Padding  J� SnapsToDevicePixels! ��Name" � ColumnDefinitions# � RowDefinitions$ �� 
ResourceId% �� TypeInTargetAssembly& �� RelativeSource' �� AncestorLevel( �� AncestorType) �� Path* �� ConverterParameter7  1System.Windows.Controls.DataGridHeadersVisibilityG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter+  Name, ��Name- �� CanContentScroll. �� CanHorizontallyScroll/ �� CanVerticallyScroll0 ��Name1 �� ScrollableHeight2 � Maximum3 �� Orientation*4 �� #ComputedVerticalScrollBarVisibility5 �� ViewportHeight6 �� ViewportSize7 � Value8 �� Mode9 �� ScrollableWidth,: �� %ComputedHorizontalScrollBarVisibility; �� ViewportWidth��%�  '��       &	  R    7  7  7  7  7  &	 @    &	 O    &	 �    7  7  &		      &	
 >    &	 C    &	 H    &	 M    &	 R    &	 W    &	 \    �� " ��CheckBoxStyle�� P�  �@d�	IsChecked$
 trueY�. ���  � �� �� "	 ��.R��� 

 ����  � $��13��$��13��.+��� $&�� /Images/ic_checkbox-selected.png��P�  �@d�	IsChecked$ falseY�. ���  � �� �� "	 ��.R��� 

 ����  � $��13��$��13��.+��� $��/Images/ic_checkbox.png���� " ��.���  � ��8   ��  � ��8  ��  � ��8  ��  � ��$ 1q���  � �� . ��  � ��$ Segoe UI Regular)���  � ��$ 14(���  �@J�SnapsToDevicePixels . ��  � �� �� "	 ��.R��� $ 0��#��z��#��z��#��z��._��� #��z��# z #��z��#��z��#��z�� ]�  ��  �@��	IsDefault . ��  �@J�IsMouseOver . ./���  � �� �#c4c4c4]�  ��  �@��	IsDefault . ��  �@J�IsMouseOver .  ./��� 8   � ��P�  �@J�IsMouseOver . . ���  � �� �#c4c4c4P�  � �� . . ���  � �� �#4d4d4f��  � �� �#c4c4c4P�  � {� .  . ���  � �� �#ececec�� 8   � ����  � �� �#ececec��	White���� " ��.���  � ��$ 1q���  � ��
 �������  �@��CornerRadius$ 3���� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��!� hintDate $
 Left=�$ Center=�$
 None=� T� $ 0Q�$ 0Q� � 
�������$	��120��$��25��.+��� $��yy/mm/dd��
�������$��Center=�$��0,-5,0,0q� P�  � ��# Z . ���  � ��8   P�  � �� Z� . ���  � ��8  ��  �� *BarcodeList+   $ QualifyLevelType��          	  �� "	 
 .R��� #��z��#��z��
������ # z��  . ._��� $! DG_ScrollViewer��|�.  ���� "	 ��.R�� " �� $
��Auto ��� $��* ��� $
��Auto �# �� $
��Auto ��� $��* ��� $
��Auto �.+��� $#��ApplicationCommands.SelectAll��|�.  ��C� *�� $"$ DataGridSelectAllButtonStyle��"% 
 +���� *CellsPanelHorizontalOffset+& �� *FindAncestor+$' 1��"( 
 y��� $) HeadersVisibility�& �� *FindAncestor+$' 1��"( 
 *  All=�  $!+ PART_ColumnHeadersPresenter��$��1��y��� $) HeadersVisibility�& �� *FindAncestor+$' 1��"( 
 *  
Column=��� $!, PART_ScrollContentPresenter��#- z��. .  $��2��/ .  #��z��#��z��# z $��1���� $0 PART_VerticalScrollBar��$��2��#2 z1 $3 Vertical=�$��1��#y�z4 #6 z5 7 �� *VerticalOffset+$8 OneWay=�& �� *TemplatedParent+� $��1��$��2��" �� ���� **(NonFrozenColumnsViewportHorizontalOffset+& �� *FindAncestor+$' 1��"( 
 �� $��* �.+��� $0 PART_HorizontalScrollBar��$��1��#2 z9 $3 
Horizontal=�#y�z: #6 z; 7 �� *HorizontalOffset+$8 OneWay=�& �� *TemplatedParent+.���� #  z  .���� $��0,0,0,0q�$��0q�#��[ #��[ ._�� # �� $��* ��� $��42 ��� $
��Auto �.+��� -   $! ScrollViewer��$
��Auto=�#��[ $��0,0,0,1q�$��	0,0,-17,5q�$��0��.��� $��0,0,0,0q�# �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �" �� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��StackPanel1��$��1��$��0��$��3��$��0,2,0,0q�.+�� $��6,0,5,0q�# �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �" �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��1��$��3��$��	01,-7,0,0q�$��0��?  9Laborie.Synergy.BarcodeTraceability.Translations.Language<   Label_Consumables#��Z< $
��Left=����#4D4D4F$��Segoe UI Semibold)�$��14(��� $��2��$��3��$��0��$��30��$��	0,8,-15,0q����� *RequiredConsumables+���� .R�� " �� $
��Auto ��� $
��Auto ��� $	��184 ��� $
��Auto ��� $	��145 �.+��� $��0��$��40��$��25��$��03,0,0,0q�#��[ $��0,0,0,1q�$
��Left=�._��� $��0��$��13��$��13��$��0q�$
��Left=����� $) DisplayImagePath�4  .System.Windows.Automation.AutomationProperties=   AutomationId= �� $) 	IsScanned�> �� StringFormat$> CScanned_{0}���� $��2��$��0,0,0,0q�$��0,0,0,0q�#��[ $��0,0,0,1q�$��Center=�$
��Left=����#4D4D4F$��Segoe UI Regular)�$��13(����� $) ChannelName�= �� $") RequiredCategory.ChannelType�$> ChannelName_{0}���� $��3��$��40��$	��268��$��0,0,0,0q�#��[ $��0,0,0,1q�$��Right=�._��� $��3��$��40��$	��130��$
��Fill=�$��-1,0,0,0q�$��Right=����� $) RequiredCategory.Category�? �� 	Converter#? [ �� $��4��#��[ $��0,0,0,1q�$��Center=�$
��Left=����#4D4D4F$��Segoe UI Regular)�$��14,0,0,0q�$��0,0,0,0q�$��11(����� $) CategoryName�= �� $) RequiredCategory.Category�$> 	CName_{0}���� $��3��$��0��$��3��$
��5,20q�$��2q�$ 5�����	#FF139E13._��� @ �� Orientation$@ 
Horizontal=�$��Center=�.+��� $��5q�$��Right=�$K��E/Laborie.Synergy.BarcodeTraceability;component/Resources/rfidscan.png��$
��Fill=�$
��40px��$
��52px���� 5  /Laborie.Synergy.Common.Automation.AutomationIdsA   ScanningMessage#= ZA B   IsScanningMessage#��ZB $��Center=�$��20(����� .���  � y�$ 	Collapsed=� �� C �� BindingC �� *DisplayScanningMessage+D �� ValueD true.a���  � y�$ Visible=�-  'Laborie.Synergy.Common.UI.SmartDataGrid  $��2��$��3��$��0��$��
3,22,-12,0q�E 
  SelectionMode$E Single=�#��[ $��0,0,0,1q�F 
  
IsReadOnlyF . G 
  VerticalGridLinesBrush
G ���� H   BarcodeGrid#= ZH #���  $	��325������ I �� Source#I [	 J 
  ColumnsJ 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumnK   
VisibilityK �� $) 
Visibility�& �� *FindAncestor+"( >�L   CellTemplateL �� .R��� 
������ $��0q�$��Center=�$	��Top=�|�.  
������ $��-5 -8q�M   Tooltip_RemoveConsumableN � ToolTip#N ZM ���� $&)  DataContext.RemoveBarcodeCommand�& �� *FindAncestor+"( 
 ���� $) 	BarCodeId�= �� $) 	BarCodeId�$> DeleteBarcode_{0}��y��� $) QualifyLevelType�#? [ .��(� $��32��$��32��.���� $��76��$��76��O J� Clip4O ��        � ��    � �� ���     ���        .+�F� $��27.7083��$��35.625��P �� Left$P 24.1458��
Q �� Top$Q 19.7917��R �� Stretch$
R Fill=�
������������4��pej��pej�ltpej;t��;t��шopt��ӈopt���6upej4��pej�(�T�-��hT�-Ө�nT�-�;�H|?�;�(FӜ;���L��n@Q^�h@Q^�(�@Q^�X�@Q^ o��L o(F� oH|?X�T�-(�T�-��˦ ���� ��7� �8�D��8�H	�����n5���X�BP�|�ML��|�MѴ��|�MӰ��|�M�˦X�B�˦�n5�Ȣ�H	��Ȣ�D���s� ��˦ ����2��`��E��Z��EѸP�2����2��+2�Ѽ�+�E�D�[�E�D�[2�Ѽ�+2��HZ�2��0P��EѠ���E���2��HZ�2�S 
  ColumnHeaderStyleS �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �@�ContextMenu �� $y�	Collapsed=�@�m� ���� $@ 
Horizontal=�.+��� 
���**��	Column....@�m� $��to Info��m� $
��Hide��T �� 
GroupStyleT (  "System.Windows.Controls.GroupStyle  U   ContainerStyleU �� " ��.���  � ��$ 0,0,0,5q���  � �� �� "	 ��.R��� .+��� $
��Bold"�$��5,5,5,5q����� *Name+#? [ ��  V �� BasedOn*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow��%%  '��       7��'  }     '  @    �� " ��8V   .���  � ��$ 14(���  � ��$
 Left=���  � ��$ Segoe UI SemiBold)���  � ��
 � � ��� "  .���  � ��
 ���� ��  � ��
 ���� ��  � ��
 �   � P�  �@ 
IsSelected . . ���  � ��
 ���� ��  � ��
 ���� ��  � ��
 �   ��� "  .���  � ��
 ���� ��  � ��
 ���� ��  � ��
 �   � P�  �@ 
IsSelected . . ���  � ��
 ���� ��  � ��
 ���� ��  � ��
 �   ��� W   ArbitraryAdd#= ZW $��3��$��2��$	��200��$��32��$X   Action_AddArbitraryConsumable#��ZX $	��Top=�$��Right=�$��	5,15,25,0q�$y�Visible=�#��[  ���� $) AddArbitraryCommand��� $��	5,10,10,5q�$��4��$��0��$��3��y��� *ShowArbitrary+.��� # �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �" �� $
��Auto ��� $��* �.+��� Y   Label_Identifier#��ZY $��0��$��0���� $��1��$��0��Z   Label_CategoryName#��ZZ $ {0} :��$��Center=�$��Right=��� -   [ ��Name$[ ArbitraryCategoryName��\   ArbitraryName#= Z\ $��1��$��1��] �� 	MaxLength$] 50��$	��200��$��5,0,5,0q�  MidGrey#��[ $��1q����� *ArbitraryName+$8 TwoWay=�^ �� UpdateSourceTrigger$^ PropertyChanged=��� $��2��$��0��_   Label_ConsumableType#��Z_ $ {0} :��$��Center=�$��Right=��� -   $[ ArbitraryTypeName��`   ArbitraryType#= Z` $��2��$��1��$] 50��$	��200��$��5,0,5,0q�#��[ $��1q����� *ArbitraryType+$8 TwoWay=�$^ PropertyChanged=��� $��3��$��0��a   Label_Expiry_Date#��Za $ {0} :��$��Center=�$��Right=�� $��3��$��1��.+��� b J� IsHitTestVisibleb .  $��5,0,5,0q�c �� Padding$c 5,0,0,0q�
����������� *DateFormatAsPerLocalCulture+�� -   $[ ArbitraryExpiryDate��d   ArbitraryExpiry#= Zd $] 10��$	��200��#��[ $��1q�$��5,0,5,0q����� *ArbitraryExpiryDate+$8 TwoWay=�$^ PropertyChanged=�.������ " �� P�  � ��# Z . ���  � ��
 ���� P�  � �� Z� . ���  � ��
 ���� .���� $��4��$��0��e   	Label_Lot#��Ze $ {0} :��$��Center=�$��Right=��� -   $[ ArbitraryLot��f   ArbitraryLot#= Zf $��4��$��1��$] 20��$	��200��$��5,0,5,0q�#��[ $��1q����� *ArbitraryLot+$8 TwoWay=��� $��5��$��0��g   Label_Serial#��Zg $ {0} :��$��Center=�$��Right=��� -   $[ ArbitrarySerial��h   ArbitrarySerial#= Zh $��5��$��1��$] 20��$	��200��$��5,0,5,0q�#��[ $��1q����� *ArbitrarySerial+$8 TwoWay=�� $��6��$��0��$��2��" �� $	��.8* ��� $	��.2* �.+��� i   ArbitraryErrorMessage#= Zi $��0��$	��450��$��0,5,5,5q�$
��Left=�$��Center=�
���  ��$��Italic$�$
��Wrap=����� *ArbitraryErrorMessage+$8 TwoWay=��� j   ArbitrarySave#= Zj $��1��$��50��$��25��k   Action_Save#��Zk $	��Top=�$��Right=�$��0,5,4,5q����� $) SaveArbitraryCommand����� " ��.���  � {� .   ^� l ^� 
Conditionsl �� m �� Bindingm �� $
) Text�n �� ElementName$n ArbitraryCategoryName��#? [ 	 False.0���  � {� . ^� l �� m �� $
) Text�$n ArbitraryTypeName��#? [ 	 False.0���  � {� . ^� l �� m �� $
) Text�$n ArbitraryLot��#? [ 	 False.0���  � {� . ^� l �� m �� $
) Text�$n ArbitrarySerial��#? [ 	 False.0���  � {� . ^� l �� m �� $
) Text�$n ArbitraryExpiryDate��#? [ 	 False.0���  � {� . �� $��5��$��0��$��3��$��	5,10,10,5q�$��2q�$ 5��
���  ��y��� *ErrorMessageVisibility+._��� $��0��$��5,5,5,5q�$
��Left=�$��Center=�
���  ��$��Italic$�$
��Wrap=�o   ConsumableErrorMessage#= Zo ���� *ConsumableErrorMessage+�� -   p   BarcodeBypass#= Zp $��1��$��Bottom=�$��Right=�$��0,5,10,0q�#��[  $��32��$	��134������ $) BypassCommand����� *
BypassText+{��� *IsEnabledBypass+y��� *IsBypassVisible+q ^� ShowOnDisabledq �� *IsEnabledBypass+#? [ $* IsEnabledBypass��r ^� 	IsEnabledr �� *IsEnabledBypass+#? [ $* IsEnabledBypass��N �� $��-8,-3,-7,-3q�$ 10q����#f4f6f9s J� BitmapEffects O� ._��� ���� *ButtonDisabledReason+$8 TwoWay=�$^ PropertyChanged=��� $��2��$��0��$
��5,20q�$��2q�$ 5�����	#FF139E13._��� $@ 
Horizontal=�$��Center=�.+��� $��5q�$��Right=�$N��H/Laborie.Synergy.BarcodeTraceability;component/Resources/green-check.png��$
��Fill=�$
��32px��$
��32px���� t   BypassConsumableMessage#= Zt u   ConsumableBypass#��Zu $��Center=����� .���  � y�$ 	Collapsed=� �� C �� *DisplayBypassMessage+D true.a���  � y�$ Visible=�