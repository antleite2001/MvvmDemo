   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel   DemoApp#   DemoApp.View.AllCustomersView   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml     Fscm8clr-namespace:System.ComponentModel;assembly=WindowsBase       � 	Resources     CustomerGroups �� Source �� Path �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName   	Direction(  "System.Windows.Controls.GroupStyle  CustomerGroupStyle   HeaderTemplate	 ��Name  Brush_HeaderBackground
 �� Padding �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value  CustomerItemStyle �� 
TargetType �� Mode �� Triggers ]� 
Conditions �� Property �� Value��%W  &	        &	 �     7  &	 ;    ��  �� $ AllCustomers�   $ 	IsCompany��   $ 	IsCompany��$ 
Descending=�  $ DisplayName��$ 	Ascending=�   �� .R��� $		 txt��8��  $
��Bold"�
�������$��1q�$
 4,2,0,2q�$��People�� �� $
 True�� �� $
 Name�.a��� $	 txt�� � ��$ 	Companies���� " ��.���  � ��$ Stretch=���  �@��
IsSelected �� $ 
IsSelected�$ TwoWay=� ]�  ��  �@��AlternationIndex$ 1����  �@��
IsSelected .  ��  �@J�IsMouseOver .  ./���  � �� �	#EEEEEEEE.��]� .+�� $��Bottom=�$��0,2,4,2q�.+��� $��Right=� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Total selected sales: ����  �� ContentStringFormat$ c������ $ TotalSelectedSales���  �� AlternationCount$ 2�� � DataContext# [  #��[ ����  �� 
GroupStyle ��  �� ResourceKey$ CustomerGroupStyle�� �� View �� .P��� $
��Name�� �� DisplayMemberBinding �� $ DisplayName��� $��E-mail�� �� $ Email��� $��Total Sales�� �� CellTemplate �� .R��� $ c��$��Right=����� $ 
TotalSales�