   M S B A M L   `   `   `  ????F  BConnectFour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ConnectFourConnectFour  5          ConnectFour.Game   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ConnectFour     5        N? Title$
  Game??5	       ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value ?? 
TargetType??%?   '??       ?? 5   
   " ??6   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ? #??z??6   .+?5      ?? $??Center=?6/   $??Center=?6L   5      5      5      5      5      .??5      (? .??5   
   ?? $	??600??6   $	??450??6   .+?5      o? -   5         o?Name$ mnuInformation??5      ?? 5      $	??415??6   $	??590??6&   $
??Left=?62   $??Center=?6M   
 ?? Top$ 35??6h   .+?5      ?? -   5         ??Name$ bdrimgNought??5   %   $??50??6   $??2q?6;   ???	#01000000
???   ?$	??350??6z   ._?5      ?? -   5        	 ??Name$	 btnimgNought??5      $??0??63   $??0??6@   $?? ??6P   $??50??6v   $??0,0,0,0q?6?   5      ?? 5       $??2q?6   
???   ?$	??350??6A   $	??300??6M   ._?5!      ? -   5        
 ?Name$
 grdBoard??5!       ? ShowGridLines .  $??Center=?6C   $	??350??6`   $	??300??6l   $	??Top=?6y   5"      5#      ?? 5%      ???	#60000000$??1q?6,   ???	#BB000000 ?? Left$	 482??6X   $ 68??6j   $??Center=?6z   $	??Top=?6?   $??53??6?   ._?5&      ?? -   5         ??Name$ tblPlayer1Name??5&      $??Player1??64   $
??Bold"?6C   $??Center=?6U   $??Center=?6r   
???????6?   5'      ?? 5(      ???	#60000000$??1q?6,   ???	#BB000000$	 534??6X   $ 68??6j   $
??Left=?6z   $	??Top=?6?   $??47??6?   ._?5)      ?? -   5        $ tblPlayer2Name??5)      $??Player2??64   $
??Bold"?6C   $??Center=?6U   $??Center=?6r   
???????6?   5*      ?? 5-      ???	#60000000$??1q?6,   ???	#BB000000$	 482??6X   $ 85??6j   $??Center=?6z   $	??Top=?6?   $??53??6?   ._?5.      ?? -   5        $ tblPlayer1Score??5.      $??0??65   $
??Bold"?6>   $??Center=?6P   $??Center=?6m   
???????6?   5/      ?? 50      ???	#60000000$??1q?6,   ???	#BB000000$	 534??6X   $ 85??6j   $
??Left=?6z   $??Center=?6?   $??47??6?   ._?51      ?? -   5        $ tblPlayer2Score??51      $??0??65   $
??Bold"?6>   $??Center=?6P   $??Center=?6m   
???????6?   52      53      54      56      