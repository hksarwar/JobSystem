   M S B A M L   `   `   `  ����  Administrator&     Adminidtrator.AssignJobsToAccMan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Reassign Jobs��5   	   $	��424��6   $	��597��6,    � WindowStartupLocation$ CenterScreen=�6O    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5      � .+�5   
   �� -   5        $��AssignJobHeadinglbl��5	   J   $Q��KThe account manager you want to delete has the following job(s) assigned to��5      $��31��5      $
��Left=�5	      $��	12,12,0,0q�67   $	��Top=�5
      $��Shruti)�64   $��14(�6H   $��Black"�6V   ���	#FF96367E J� 	AllowDrop .  5   3   �� 5   
   -   5        $��jobListHeadinglbl��5   J   $"��Step 1: Click on a job below��5      $��28��67   $
��Left=�5      $��	11,62,0,0q�67   $	��Top=�5      $��Shruti)�64   $��14(�6H   $
��Thin"�6V   ���	#FF96367E5      �� 5   
   -   5        $��AccManJobList��5      $	��105��5      $
��Left=�6    $��	12,92,0,0q�6;   $	��Top=�5   4   $	��550��6L   $��Disabled=�5   E   ��6   �� *JobCollection+ � 	Resources 5       �� 
TargetType �� Property �� Value��%V   '��       �� 5      " ��6   .�5      ��  � ��$ Center=�6C   5      5      	 �� View	 5      �� 5      .P�5      �� 
 �� Width$	
 200��6!   $��	Job Title��6-    �� DisplayMemberBinding 5   1   �� *Title+�� 5      $	
 100��6!   $��Company��6-    5   1   �� *	Company+�� 5      $	
 100��6!   $��Location��6-    5   1   �� *
Location+�� 5       $	
 147��6!   $��Date Posted��6-    5!   1   �� *
DatePosted+5"      5$      �� 5%   
   -   5        $��AvalAccManHeadinglbl��5&   J   $0��*Step 2: Click on an account manager below ��5%      $��28��6E   $
��Left=�5&      $��	9,199,0,0q�67   $	��Top=�5'      $��Shruti)�64   $��14(�6H   $
��Thin"�6V   ���	#FF96367E5(      �� 5)   
   -   5        $��AvailAccManList��5*      $��98��5)      $
��Left=�6   $��
12,229,0,0q�6:   $	��Top=�5*   6   $	��550��6N   $��Disabled=�5+   D   ��6   �� *AMCollection+ 5,      ��%V   '��       �� 5-      " ��6   .�5.      ��  � ��$ Center=�6C   5/      50      	 51      �� 52      .P�53      �� $	
 100��6%   $��
First Name��61    54   1   �� *	FirstName+�� 55      $	
 100��6%   $��	Last Name��61    56   1   �� *
LastName+�� 57      $	
 200��6%   $��Username��61    58   1   �� *
Username+�� 59      $	
 147��6%   $��Location��61    5:   1   �� *
Location+5;      5=      �� 5>   
   -   5        $��	assignBtn��5?   2   $��
Assign Job��5>      $��27��6&   $
��Left=�62   $��228,337,0,0q�5?      $	��Top=�6C   $��97��6[   $��Times New Roman)�5@      $��13(�5A      $��SemiBold"�6+   6A   �� 5B   
   -   5        $��	cancelBtn��5C   1   $��Cancel��5B      $��27��6"   $��Right=�6.   $��
0,337,24,0q�5C      $	��Top=�6B   $��97��6Z   $��Times New Roman)�5D      $��13(�5E      $��SemiBold"�6+   6A   �� 5F   
   -	   5        $��errLbl��5F   [   $��Label��6   $��28��6    $
��Left=�6,   $��
15,361,0,0q�6G   $	��Top=�6i   $y�Hidden=�6�   ���	#FFFA00006�   �� 5G   
   -
   5        $��label1��5G   u   $%��Step 3: Click to assign the job��6   $��28��6:   $
��Left=�6F   $��
11,334,0,0q�6a   $	��Top=�6�   $��Shruti)�6�   $��14(�6�   $
��Thin"�6�   ���	#FF96367E5H      �� 5I   
   -   5        $��AssignJobHeadinglbl2��5K   J   $@��:them. Please reassign the job(s) to other account managers��5I      $��31��5J      $
��Left=�5K      $��	12,35,0,0q�67   $	��Top=�5L      $��Shruti)�64   $��14(�6H   $��Black"�6V   ���	#FF96367E .  5M   3   5N      5O      